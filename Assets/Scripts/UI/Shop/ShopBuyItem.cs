using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ShopBuyItem : MonoBehaviour
{

    public Item item;
    private PlayerEconomy _playerEconomy;
    private PlayerInventory _playerInventory;

    // Start is called before the first frame update
    void Start()
    {
        if (!item)
        {
            Debug.LogError("Item not set on " + gameObject.name);
            return;
        }

        _playerEconomy = FindObjectOfType<PlayerEconomy>();
        _playerInventory = FindObjectOfType<PlayerInventory>();

        TMP_Text price = transform.Find("Price").Find("Text").GetComponent<TMP_Text>();
        price.text = item.itemValue.ToString();

        Image imagePic = transform.Find("ItemPic").Find("Image").GetComponent<Image>();
        imagePic.sprite = item.itemIcon;

        TMP_Text name = transform.Find("Name").GetComponent<TMP_Text>();
        name.text = item.itemName;

        Button buyButton = transform.Find("BuyButton").GetComponent<Button>();
        buyButton.onClick.AddListener(Buy);

        if (_playerInventory.CheckIfHasItem(item))
        {
            BlockBuy();
        }
    }

    public void Buy()
    {
        if (_playerEconomy.Buy(item.itemValue))
        {
            _playerInventory.AddItem(item);
            BlockBuy();
        }
    }

    void BlockBuy()
    {
        Button buyButton = transform.Find("BuyButton").GetComponent<Button>();
        buyButton.interactable = false;
        TMP_Text buyButtonText = buyButton.GetComponentInChildren<TMP_Text>();
        buyButtonText.text = "Owned";
    }
}
