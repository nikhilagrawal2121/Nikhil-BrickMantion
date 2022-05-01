using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    int health; // to check the health of brick 
     SpriteRenderer SpriteRendarer; // Refrance to the spriteRendere
    public Sprite[] States; // Show states of bricks
     public bool unBreakable;

    public int points = 100;

    public void Awake()
    {
        this.SpriteRendarer = GetComponent<SpriteRenderer>();
    }

    public void Start()
    {
        if(! this.unBreakable)
        {
            this.health = this.States.Length; // Health is equal to which state have a breck
            this.SpriteRendarer.sprite = this.States[this.health - 1];
        }
    }

    private void Hit()
    {
        if(this.unBreakable) // if the brick is unbreakable it will return
        {
            return;
        }
        this.health--; // Reduce the health by one

        if(this.health <= 0 )  // if the heath of breck is 0 then distroy the bbrick
        {
            this.gameObject.SetActive(false); 
        }
        else
        {
            this.SpriteRendarer.sprite = this.States[this.health - 1]; // update the sprite Rendrer
        }

       FindObjectOfType<GameManager>().Hit(this); // Calling the fuction of other scripts 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Ball") // When the brick hit by a ball calls hit function
        {
            Hit();
        }
    }
}
