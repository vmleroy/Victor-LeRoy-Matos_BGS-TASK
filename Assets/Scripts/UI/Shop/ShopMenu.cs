using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : MonoBehaviour
{

    private Button _buyButton;
    private Button _sellButton;
    [SerializeField] private GameObject _buyMenu;
    [SerializeField] private GameObject _sellMenu;

    // Start is called before the first frame update
    void Start()
    {
        _buyButton = transform.Find("BuyButton").GetComponent<Button>();
        _sellButton = transform.Find("SellButton").GetComponent<Button>();

        _buyButton.onClick.AddListener(Buy);
        _sellButton.onClick.AddListener(Sell);
    }

    void Buy()
    {
        _buyMenu.SetActive(true);
        gameObject.SetActive(false);
    }

    void Sell()
    {
        _sellMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
