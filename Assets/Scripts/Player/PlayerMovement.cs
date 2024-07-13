using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;
    private Rigidbody2D _rb;
    private PlayerInput _playerInput;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerInput = FindObjectOfType<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    void Walk() {
        float horizontalInput = 0;
        float verticalInput = 0;
        if (!_playerInput.isDisabled) {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
        }
        Vector2 direction = new Vector2(horizontalInput, verticalInput);
        _rb.velocity = direction * _speed;
    }
}
