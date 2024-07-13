using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class Shop : MonoBehaviour
{

    [SerializeField] private GameObject _shopUI;
    [SerializeField] private Button _closeButton;
    private PlayerInput _playerInput;

    // Start is called before the first frame update
    void Start()
    {   
        if (!_shopUI) {
            Debug.LogError("Shop UI is not assigned in the inspector");
            return;
        }
        if (!_closeButton) {
            Debug.LogError("Close Button is not assigned in the inspector");
            return;
        }

        _closeButton.onClick.AddListener(CloseShopUI);

        _playerInput = FindObjectOfType<PlayerInput>();
        _playerInput.isDisabled = true;
    }

    void CloseShopUI() {
        _playerInput.isDisabled = false;
        Destroy(_shopUI);
    }
}
