using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    private bool _isPlayerTouchingDoor;
    private PlayerInteractionEvent _playerInteraction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isPlayerTouchingDoor && _playerInteraction.isInteracting) {
            Debug.Log("Player is interacting with shopkeeper");
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            _playerInteraction = other.gameObject.GetComponent<PlayerInteractionEvent>();
            _isPlayerTouchingDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            _playerInteraction = null;
            _isPlayerTouchingDoor = false;
        }
    }
}
