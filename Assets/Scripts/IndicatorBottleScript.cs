using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicatorBottleScript : MonoBehaviour
{
    [Tooltip("Indicator Dropper GameObject")]
    [SerializeField] GameObject dropper;

    [Tooltip("Indicator Dropper Script")]
    [SerializeField] IndicatorDropperScript dropperScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGrabbed()
    {
        //make dropper child if dropper is not currently being held
        if(!dropperScript.dropperPicked)
        {
            dropper.transform.parent = transform;
        }
        
    }

    public void OnGrabExited()
    {
        if (dropperScript.dropperParent != dropper.transform.parent)
        {
            dropper.transform.parent = dropperScript.dropperParent;
        }
        //bug fix?
        //dropper.transform.rotation = dropperScript.dropperParent.rotation;
    }
}
