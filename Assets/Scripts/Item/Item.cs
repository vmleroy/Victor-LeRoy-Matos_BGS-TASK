using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class Item : MonoBehaviour
{
    public string itemName;
    public string itemDescription;
    public int itemValue;
    public string itemType;
    public Sprite itemIcon;
    public SpriteLibraryAsset spriteLibrary;

    public Item Clone()
    {
        Item item = new GameObject().AddComponent<Item>();
        item.itemName = itemName;
        item.itemDescription = itemDescription;
        item.itemValue = itemValue;
        item.itemType = itemType;
        item.itemIcon = itemIcon;
        item.spriteLibrary = spriteLibrary;
        return item;
    }

    public void Sell()
    {
        Debug.Log("Selling " + itemName);
    }

    public void Equip()
    {
        switch (itemType)
        {
            case "Outfit":
                Debug.Log("Equipping " + itemName + " as a outfit");
                break;
            case "Hair":
                Debug.Log("Equipping " + itemName + " as hair");
                break;
            case "Hat":
                Debug.Log("Equipping " + itemName + " as a hat");
                break;
            default:
                Debug.Log("Equipping " + itemName);
                break;
        }
    }
}
