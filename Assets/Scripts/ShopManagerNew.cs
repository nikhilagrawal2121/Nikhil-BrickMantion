using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ShopManagerNew : MonoBehaviour
{
    public int itemindex;
    public GameObject[] PaddleModel;
    public int Coin = 0; //Use to calculate score
    public Text CoinText;
    public Button BuyButton;

    public PaddleBlueprint[] paddleBlue;

    void Start()
    {
        foreach (PaddleBlueprint paddle in paddleBlue)
        {
            if (paddle.price == 0)
                paddle.isUnlocked = true;
            else
                paddle.isUnlocked = PlayerPrefs.GetInt(paddle.name, 0) == 0 ? false : true;
        }


        itemindex = PlayerPrefs.GetInt("selected Model", 0);
        foreach (GameObject paddle in PaddleModel)
            paddle.SetActive(false);
        PaddleModel[itemindex].SetActive(true);


        Coin = PlayerPrefs.GetInt("Coin1");
        CoinText.text = "Coins " + Coin.ToString();
    }



    public void ChangeNext()
    {
        PaddleModel[itemindex].SetActive(false);
        itemindex++;

        if (itemindex == PaddleModel.Length)
            itemindex = 0;
        PaddleModel[itemindex].SetActive(true);
        PaddleBlueprint Padd = paddleBlue[itemindex];

        if (!Padd.isUnlocked)
            return;


        PlayerPrefs.SetInt("selected Model", itemindex);
    }

    public void ChangePrivious()
    {
        PaddleModel[itemindex].SetActive(false);
        itemindex--;

        if (itemindex == -1)
            itemindex = PaddleModel.Length - 1;
        PaddleModel[itemindex].SetActive(true);


        PaddleBlueprint Padd = paddleBlue[itemindex];

        if (!Padd.isUnlocked)
            return;




        PlayerPrefs.SetInt("selected Model", itemindex);
    }

    //public void Buy()
    //{
    //    GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

    //}

    //public void Use()
    //{

    //    PlayerPrefs.SetInt("selected Model", itemindex);
    //    SceneManager.LoadScene("LevelSelecotor");
    //}

    private void Update()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        PaddleBlueprint Padd = paddleBlue[itemindex];
        if (Padd.isUnlocked) //check paddle is enable or not
        {
            BuyButton.gameObject.SetActive(false); // if inable buy button not active
        }
        else
        {
            BuyButton.gameObject.SetActive(true); //buy button enable
            BuyButton.GetComponentInChildren<TextMeshProUGUI>().text = "BUY -" + Padd.price;


                if(Padd.price > PlayerPrefs.GetInt("Coin1", 0))
            {
                BuyButton.interactable = false;
            }
            else
            {
                BuyButton.interactable = true;
               

            }               
            
        }

    }


    public void UnlockPaddle()
    {
        PaddleBlueprint Padd = paddleBlue[itemindex];
        PlayerPrefs.SetInt(Padd.name, 1);
        PlayerPrefs.SetInt("selected Model", itemindex);
        Padd.isUnlocked = true;
        PlayerPrefs.SetInt("Coin1", PlayerPrefs.GetInt("Coin1", 0) - Padd.price); // cut the price from the current coin 
    }

    public void NextScene()
    {
        SceneManager.LoadScene("LevelSelecotor");

    }

}






