using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReagentBottleScript_cap : MonoBehaviour
{
    [SerializeField] BoxCollider boxCollider;
    Vector3 restPosition;
    // Start is called before the first frame update
    void Start()
    {
        restPosition = gameObject.transform.position;
        boxCollider.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGrabbed()
    {
        boxCollider.enabled = false;
    }

    public void OnGrabbExited()
    {
        boxCollider.enabled = true;
    }
}
