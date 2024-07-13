using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class BuyItems : MonoBehaviour
{
    [SerializeField] private GameObject _buyItemObject;
    [SerializeField] private string _itemType = "All";

    void Start()
    {
        if (!_buyItemObject)
        {
            Debug.LogError("Buy Item Object is not assigned in the inspector");
            return;
        }

        GameObject[] itemsObject = Resources.LoadAll<GameObject>("Items");
        Debug.Log(itemsObject.Length);
        

        float spawnObjectY = 0;

        for (int i = 0; i < itemsObject.Length; i++)
        {
            Item item = itemsObject[i].GetComponent<Item>();
            if (item && (item.itemType == _itemType || _itemType == "All"))
            {
                GameObject buyItem = Instantiate(_buyItemObject, transform.Find("Viewport").transform.Find("Content").transform);
                buyItem.transform.localScale = new Vector3(0.06f, 0.05f, 1);
                buyItem.GetComponent<ShopBuyItem>().item = item;
                spawnObjectY -= 50;
            }
        }
    }
}
