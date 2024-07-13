using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScrollableContent : MonoBehaviour
{

    private PlayerEconomy _playerEconomy;
    private TMP_Text _moneyText;

    // Start is called before the first frame update
    void Start()
    {
        _playerEconomy = FindObjectOfType<PlayerEconomy>();
        _moneyText = transform.Find("PlayerMoney").Find("Quantity").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        _moneyText.text = _playerEconomy.money.ToString();
    }
}
