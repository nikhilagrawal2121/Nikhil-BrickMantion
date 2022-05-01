using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ShopManager : MonoBehaviour
{
    public int[,] shopItems = new int[5,5];
    public float coins;
    public Text CoinsText;



    // Start is called before the first frame update
    void Start()
    {
        CoinsText.text = "Coins:" + coins.ToString();

        shopItems[1, 1] = 1;
        shopItems[1, 2] = 2;
        shopItems[1, 3] = 3;
        shopItems[1, 4] = 4;

        //price

        shopItems[2, 1] = 100;
        shopItems[2, 2] = 120;
        shopItems[2, 3] = 130;
        shopItems[2, 4] = 140;

    }

    public void buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (coins >= shopItems[2, ButtonRef.GetComponent<Shop>().itemId])
        {
            coins -= shopItems[2, ButtonRef.GetComponent<Shop>().itemId];

            CoinsText.text = "Coins:" + coins.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
