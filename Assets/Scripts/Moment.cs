using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moment : MonoBehaviour
{
    public Rigidbody2D rb; // To acss the rigidBody
    public Vector2 direction; // Used for the directio of the movement
    public float speed = 30f;
    public float MaxBounceAngle = 75f;
    public AudioSource Audio;
    public AudioClip BallTap;
    public bool left, right;



    private void Awake()
    {

        Audio = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>(); // getcomponent search the rigidbody2D in the paddle 
                                          //RigidBody is used to move the obj 
    }


    public void hold_left()
    {
        left = true;
        right = false;
    }

    public void hold_right()
    {
        left = false;
        right = true;
    }
    public void nohold()
    {
        left = false;
        right = false;
    }

    public void movePlayerRight()
    {
     

        rb.transform.Translate(Vector3.right * speed*Time.deltaTime );

        // rb.transform.position += Vector3.right * speed;
        if (transform.position.x > 10)
        {
            this.transform.position = new Vector2(10, -6);
        }

    }
    public void movePlayerLeft()
    {
        rb.transform.Translate(Vector3.left * speed *Time.deltaTime  );

        //    rb.transform.position += Vector3.left * speed  ;

        if (transform.position.x < -10)
        {
            this.transform.position = new Vector2(-10, -6);
        }

    }










    private void FixedUpdate()
    {

        //RunCharacter(Input.GetAxis("Horizontal"));
        //if (this.direction != Vector2.zero)
        //{
        //    rb.AddForce(this.direction * this.speed); // this add the speed in the direction
        //}

        if (right)
        {
            movePlayerRight();
        }
        else if (left)
        {
            movePlayerLeft();
        }
        else
        {
            nohold();
        }

    }
    private void RunCharacter(float horizontalInput)
    {
        //move player    
        rb.AddForce(new Vector2(horizontalInput * speed * Time.deltaTime, 0));
    }
    public void ResetPaddle()
    {
        this.transform.position = new Vector2(0f, this.transform.position.y); // new vector becouse we have to maintain position of paddle to middle 
                                                                              //thats what x =0 and y == start position

        this.rb.velocity = Vector2.zero;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>(); // To check paddle collide with ball
                                                               // GetComponent G is capital becouse to acess global veriable

        Audio.clip = BallTap;
        Audio.Play();

        if (ball != null)
        {
            Vector3 paddlePosition = this.transform.position; // Used to find the position of paddle
            Vector2 ContactPoint = collision.GetContact(0).point; //used to find the contact point of ball with paddle

            float offset = paddlePosition.x - ContactPoint.x;

            float width = collision.otherCollider.bounds.size.x / 2; // Used to calculate width of the paddle (Half )


            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rb.velocity); // this will give actual direction of the ball

            float BounceAngle = (offset = width) * this.MaxBounceAngle; // this is disired angle of the ball

            float NewAngle = Mathf.Clamp(currentAngle + BounceAngle, -MaxBounceAngle, MaxBounceAngle);

            Quaternion rotation = Quaternion.AngleAxis(NewAngle, Vector3.forward); //Quaternion used for rotation

            ball.rb.velocity = rotation * Vector2.up * ball.rb.velocity.magnitude;

        }
    }





}
