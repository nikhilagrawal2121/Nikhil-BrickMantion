using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip BallMiss;

    private void Awake()
    {

        Audio = GetComponent<AudioSource>();

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Audio.clip = BallMiss;
        Audio.Play();




        if (collision.gameObject.name == "Ball") // When the brick hit by a ball calls hit function
        {
            FindObjectOfType<GameManager>().Miss(); // Calling the fuction of other scripts 
        }
    }
}
