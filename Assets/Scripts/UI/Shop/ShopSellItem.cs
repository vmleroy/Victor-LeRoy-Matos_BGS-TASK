using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class ShopSellItem : MonoBehaviour
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

        Button buyButton = transform.Find("SellButton").GetComponent<Button>();
        buyButton.onClick.AddListener(Sell);
    }

    public void Sell() 
    {
        if (_playerEconomy.Sell(item.itemValue))
        {
            if (_playerInventory.EquipedItem(item)) {
                switch (item.itemType) {
                    case "Outfit":
                        _playerInventory.EquipItem(Resources.Load<Item>("Items/BoxerOutfit")); 
                        break;
                    case "Hat":
                        _playerInventory.EquipItem(Resources.Load<Item>("Items/NoHat")); 
                        break;
                    case "Hair":                          
                        _playerInventory.EquipItem(Resources.Load<Item>("Items/NoHair")); 
                        break;
                }
            }
            _playerInventory.RemoveItem(item);
            Destroy(gameObject);
        }
    }
}
