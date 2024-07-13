using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{

    private Animator[] _animators;
    private PlayerInput _playerInput;

    // Start is called before the first frame update
    void Start()
    {
        _animators = GetComponentsInChildren<Animator>();
        _playerInput = FindObjectOfType<PlayerInput>();
    }

    // Update is called once per frame
    void Update()
    {
        WalkAnimation();
    }

    void WalkAnimation () {
        float horizontalInput = 0;
        float verticalInput = 0;
        if (!_playerInput.isDisabled) {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
        }
        Vector2 direction = new Vector2(horizontalInput, verticalInput);
        foreach (var animator in _animators)
        {
            animator.SetFloat("Horizontal", direction.x);
            animator.SetFloat("Vertical", direction.y);
            animator.SetFloat("Speed", direction.sqrMagnitude);
        }
    }
}
