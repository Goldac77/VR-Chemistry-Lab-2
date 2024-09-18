using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IndicatorDropperScript : MonoBehaviour
{
    Vector3 dropperPosition;
    Quaternion dropperRotation;

    [HideInInspector] public bool dropperPicked;

    [SerializeField] IndicatorBottleScript indicatorBottleScript;

    // Start is called before the first frame update
    void Start()
    {
        dropperPosition = transform.position;
        dropperRotation = transform.rotation;
        dropperPicked = false;
    }

    public void OnGrabbed()
    {
        dropperPicked = true;
    }

    public void OnGrabExited()
    {
        dropperPicked = false;
    }

    private void FixedUpdate()
    {
        if(!dropperPicked)
        {
            transform.position = dropperPosition;
            transform.rotation = dropperRotation;
            if(indicatorBottleScript.shifted)
            {
                transform.position = dropperPosition;
                transform.rotation = dropperRotation;
            }
        }
    }
}
