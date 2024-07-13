using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public bool isDisabled = false;
    public Dictionary<string, KeyCode> keyBindings = new Dictionary<string, KeyCode>();

    // Start is called before the first frame update
    void Start()
    {
        keyBindings.Add("Interact", KeyCode.E);
        keyBindings.Add("Inventory", KeyCode.I);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
