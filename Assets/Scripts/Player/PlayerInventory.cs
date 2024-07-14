using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class PlayerInventory : MonoBehaviour
{

    public List<Item> items = new List<Item>();
    private PlayerEconomy _playerEconomy;
    private PlayerInput _playerInput;
    [SerializeField] private GameObject _player;

    void Start()
    {
        _playerEconomy = FindObjectOfType<PlayerEconomy>();
        _playerInput = FindObjectOfType<PlayerInput>();
        if (!_player)
        {
            Debug.LogError("Player game object not found");
        }
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        Debug.Log("Added " + item.itemName + " to inventory");
    }
    public void RemoveItem(Item item)
    {
        foreach(Item i in items)
        {
            if (i.itemName == item.itemName)
            {
                items.Remove(i);
                Debug.Log("Removed " + i.itemName + " from inventory");
                return;
            }
        }
    }

    public void EquipItem(Item item)
    {
        SpriteLibrary[] playerChildrenSL = _player.GetComponentsInChildren<SpriteLibrary>();
        switch (item.itemType)
        {
            case "Outfit":
                Debug.Log("Equipping " + item.itemName + " outfit");
                foreach (SpriteLibrary sl in playerChildrenSL)
                {
                    string parentName = sl.gameObject.transform.name;
                    if (parentName == "Outfit")
                    {
                        sl.spriteLibraryAsset = item.spriteLibrary;
                    }
                }
                break;
            case "Hair":
                Debug.Log("Equipping " + item.itemName + " hair");
                foreach (SpriteLibrary sl in playerChildrenSL)
                {
                    string parentName = sl.gameObject.transform.name;
                    if (parentName == "Hair")
                    {
                        if (item.itemName == "NoHair")
                        {
                            sl.spriteLibraryAsset = null;
                            sl.gameObject.GetComponent<SpriteResolver>().SetCategoryAndLabel("No Category", "No Label");
                            sl.gameObject.GetComponent<SpriteRenderer>().sprite = null;
                            break;
                        }
                        sl.spriteLibraryAsset = item.spriteLibrary;
                    }
                }
                break;
            case "Hat":
                Debug.Log("Equipping " + item.itemName + " hat");
                foreach (SpriteLibrary sl in playerChildrenSL)
                {
                    string parentName = sl.gameObject.transform.name;
                    if (parentName == "Hat")
                    {
                        if (item.itemName == "NoHat")
                        {
                            sl.spriteLibraryAsset = null;
                            sl.gameObject.GetComponent<SpriteResolver>().SetCategoryAndLabel("No Category", "No Label");
                            sl.gameObject.GetComponent<SpriteRenderer>().sprite = null;
                            break;
                        }
                        sl.spriteLibraryAsset = item.spriteLibrary;
                    }
                }
                break;
            default:
                Debug.LogError("Item type not found");
                break;
        }
    }

    public bool EquipedItem(Item item)
    {
        SpriteLibrary[] playerChildrenSL = _player.GetComponentsInChildren<SpriteLibrary>();
        foreach (SpriteLibrary sl in playerChildrenSL)
        {
            if (sl.spriteLibraryAsset == item.spriteLibrary)
            {
                return true;
            }
        }
        return false;
    }

    public bool CheckIfHasItem(Item item)
    {
        foreach (Item i in items)
        {
            if (i.itemName == item.itemName)
            {
                return true;
            }
        }
        return false;
    }
}
