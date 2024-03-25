using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorDropperScript : MonoBehaviour
{
    [SerializeField] GameObject dropperPosition;

    // Start is called before the first frame update
    void Start()
    {

    }

    //Bring dropper back when released
    public void OnGrabExited()
    {
        transform.position = dropperPosition.transform.position;
    }

    private void Update()
    {
        //always move dropper with bottle
        transform.position = dropperPosition.transform.position;
    }
}
