using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    private bool _isPlayerAbleToBuy;
    private PlayerInteractionEvent _playerInteraction;

    private GameObject _questionMarkBaloon;
    [SerializeField] private GameObject _shopUI;
    private GameObject _shopUIInstance;

    // Start is called before the first frame update
    void Start()
    {
        _questionMarkBaloon = transform.Find("QuestionMarkBaloon").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPlayerAbleToBuy && _playerInteraction.isInteracting) {
            Debug.Log("Player is interacting with shopkeeper");
            OpenShopUI();   
        }
    }

    void OpenShopUI() {
        if (_shopUIInstance && _shopUIInstance.activeSelf) return;
        _shopUIInstance = Instantiate(_shopUI, Vector3.zero, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            _questionMarkBaloon.SetActive(true);
            _playerInteraction = other.gameObject.GetComponent<PlayerInteractionEvent>();
            _isPlayerAbleToBuy = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            _questionMarkBaloon.SetActive(false);
            _playerInteraction = null;
            _isPlayerAbleToBuy = false;
        }
    }
}
