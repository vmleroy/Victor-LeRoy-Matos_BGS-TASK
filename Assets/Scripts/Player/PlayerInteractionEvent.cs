using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionEvent : MonoBehaviour
{
    public bool isInteracting;
    private PlayerInput _playerInput;

    void Start() {
        _playerInput = FindObjectOfType<PlayerInput>();
    }

    // Update is called once per frame
    void Update() { 
        if (!_playerInput.isDisabled && Input.GetKeyDown(_playerInput.keyBindings["Interact"])) isInteracting = true;
        else isInteracting = false;     
    }
}
