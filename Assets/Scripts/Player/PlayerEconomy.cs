using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEconomy : MonoBehaviour
{
    public int money = 500;

    public void AddMoney(int amount)
    {
        money += amount;
    }

    public void RemoveMoney(int amount)
    {
        money -= amount;
    }

    public bool Buy(int amount)
    {
        if (money >= amount)
        {
            Debug.Log("Bought item for " + amount);
            RemoveMoney(amount);
            return true;
        }
        Debug.Log("Not enough money to buy item for " + amount);
        return false;
    }

    public bool Sell (int amount)
    {
        Debug.Log("Sold item for " + amount);
        AddMoney(amount);
        return true;
    }
}
