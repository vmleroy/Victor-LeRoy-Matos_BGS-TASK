using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellItems : MonoBehaviour
{
    
    private PlayerInventory _playerInventory;
    [SerializeField] private GameObject _sellItemObject;

    void Start()
    {
        _playerInventory = FindObjectOfType<PlayerInventory>();
        if (!_sellItemObject)
        {
            Debug.LogError("Sell Item Object is not assigned in the inspector");
            return;
        }

        float spawnObjectY = 0;
        foreach (Item item in _playerInventory.items)
        {
            GameObject sellItem = Instantiate(_sellItemObject, transform.Find("Viewport").transform.Find("Content").transform);
            sellItem.transform.localScale = new Vector3(0.06f, 0.05f, 1);
            Item shopItem = item.Clone();        
            shopItem.itemValue = item.itemValue / 2;           
            sellItem.GetComponent<ShopSellItem>().item = shopItem;
            Destroy(shopItem);
            spawnObjectY -= 50;
        }

    }
}
