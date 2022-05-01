using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





public class Shop : MonoBehaviour
{

    public int itemId;
    public Text Prise;
    public GameObject ShopManager;


    void Update()
    {
        
        Prise.text = "price: $" + ShopManager.GetComponent<ShopManager>().shopItems[2, itemId].ToString();
    }
}
