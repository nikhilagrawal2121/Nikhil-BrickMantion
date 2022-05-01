using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb; // To acss the rigidBody
    public float speed = 500f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // getcomponent search the rigidbody2D in the paddle 
                                          //RigidBody is used to move the obj 
    }

    private void Start()
    {
        
        ResetBall();
    }

    public void ResetBall()
    {
        this.transform.position = new Vector2(0,-4); //position of the ball goes to ideal state
        this.rb.velocity = Vector2.zero; //Rigidbody goes to inition state
        Invoke(nameof(Trijectory), 2f);
    }

    public void Trijectory()
    {
        Vector2 force = Vector2.zero; // to add the force
        force.x = Random.Range(-1f, 1f); // it goes to any direction
        force.y = -1f; // ball always go down to y axiss

        this.rb.AddForce(force.normalized * this.speed); // add this force to ball rigidbody
    }
}
