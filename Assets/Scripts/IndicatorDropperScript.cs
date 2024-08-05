using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorDropperScript : MonoBehaviour
{
    [Tooltip("Indicator dropper stationary position")]
    [SerializeField] Transform dropperPosition;

    [Tooltip("Indicator dropper bottle")]
    [SerializeField] GameObject dropperBottle;

    [HideInInspector] public Transform dropperParent;
    [HideInInspector] public bool dropperPicked;

    //Make dropper child of bottle when bottle is grabbed and dropper is not grabed
    //else maintain current heirachy
    //

    // Start is called before the first frame update
    void Start()
    {
        dropperParent = gameObject.transform.parent;
        dropperPicked = false;
    }

    public void OnGrabbed()
    {
        dropperPicked = true;
    }

    //Bring dropper back when released
    public void OnGrabExited()
    {
        transform.rotation = dropperPosition.rotation;
        transform.position = dropperPosition.position;
        dropperPicked = false;
    }

    private void Update()
    {
        //always move dropper with bottle
        transform.position = dropperPosition.transform.position;
    }
}
