using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleSelector : MonoBehaviour
{
    public int itemindex;
    public GameObject[] Paddles;

    void Start()
    {
        itemindex = PlayerPrefs.GetInt("selected Model", 0);
        foreach (GameObject paddle in Paddles)
            paddle.SetActive(false);
        Paddles[itemindex].SetActive(true);
    }
}
