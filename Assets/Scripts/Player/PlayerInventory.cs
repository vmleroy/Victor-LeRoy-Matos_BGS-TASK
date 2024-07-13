using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{

    public List<Item> items = new List<Item>();
    private PlayerEconomy _playerEconomy;
    private PlayerInput _playerInput;

    void Start()
    {
        _playerEconomy = FindObjectOfType<PlayerEconomy>();
        _playerInput = FindObjectOfType<PlayerInput>();
    }

    void Update()
    {
        if (!_playerInput.isDisabled && Input.GetKeyDown(_playerInput.keyBindings["Inventory"]))
        {
            OpenInventory();
        }
    }

    public void AddItem(Item item)
    {
        items.Add(item);
        Debug.Log("Added " + item.itemName + " to inventory");
    }
    public void RemoveItem(Item item)
    {
        items.Remove(item);
        Debug.Log("Removed " + item.itemName + " from inventory");
    }
    void OpenInventory()
    {
        Debug.Log("Inventory:");
        foreach (Item item in items)
        {
            Debug.Log("item: " + item.itemName + " value: " + item.itemValue);
        }
        Debug.Log("Money: " + _playerEconomy.money);
    }
}
