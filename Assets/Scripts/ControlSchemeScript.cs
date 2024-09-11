using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSchemeScript : MonoBehaviour
{
    public GameObject leftRayInteractor;
    public GameObject rightRayInteractor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CloseUI()
    {
        gameObject.SetActive(false);
        if(leftRayInteractor.activeInHierarchy || rightRayInteractor.activeInHierarchy)
        {
            leftRayInteractor.SetActive(false);
            rightRayInteractor.SetActive(false);
        } 
    }
}
