using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class BoardController : MonoBehaviour
{
    public InputActionReference toggleMarker = null;

    private void Start()
    {
        toggleMarker.action.started += Toggle;
    }

    private void Update()
    {

    }

    void Toggle(InputAction.CallbackContext context)
    {
        if(gameObject.layer == LayerMask.NameToLayer("Marker"))
        {
            gameObject.layer = LayerMask.NameToLayer("Default");
        } else
        {
            gameObject.layer = LayerMask.NameToLayer("Marker");
        }
        
    }
}
