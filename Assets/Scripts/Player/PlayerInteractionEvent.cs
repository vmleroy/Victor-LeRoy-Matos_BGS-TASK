using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionEvent : MonoBehaviour
{
    public bool isInteracting;
    // Update is called once per frame
    void Update() { 
        if (Input.GetKeyDown(KeyCode.E)) isInteracting = true;
        else isInteracting = false;     
    }
}
