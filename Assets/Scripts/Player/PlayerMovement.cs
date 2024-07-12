using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 3.5f;
    private Rigidbody2D _rb;
    

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
    }

    void Walk() {
      float horizontalInput = Input.GetAxis("Horizontal");
      float verticalInput = Input.GetAxis("Vertical");
      Vector2 direction = new Vector2(horizontalInput, verticalInput);
      _rb.velocity = direction * _speed;
    }
}
