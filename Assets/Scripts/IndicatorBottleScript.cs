using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorBottleScript : MonoBehaviour
{
    Vector3 startingTransformPosition;
    Quaternion startingTransformRotation;
    [HideInInspector] public bool shifted;
    // Start is called before the first frame update
    void Start()
    {
        startingTransformPosition = transform.position;
        startingTransformRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if(startingTransformPosition != transform.position || startingTransformRotation != transform.rotation)
        {
            shifted = true;
            transform.position = startingTransformPosition;
            transform.rotation = startingTransformRotation;
        } else
        {
            shifted = false;
        }
    }
}
