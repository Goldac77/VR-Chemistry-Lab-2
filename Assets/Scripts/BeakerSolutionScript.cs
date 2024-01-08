using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeakerSolutionScript : MonoBehaviour
{
    public bool isFilled;
    Material startingMaterial;

    //colour changes
    [SerializeField] Color indicatorColor;
    [SerializeField] Color endPointColor;

    public bool isReacting;

    float count = 0;
    // Start is called before the first frame update
    void Start()
    {
        isFilled = false;
        isReacting = false;
        startingMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Renderer>().material != startingMaterial)
        {
            isFilled = true;
        }
        else
        {
            isFilled = false;
        }

        if(isReacting)
        {
            //it takes 10.5 seconds for the burette to be empty
            count += Time.deltaTime;
            if(count >= 8)
            {
                GetComponent<Renderer>().material.color = endPointColor;
            } else if (count > 4 && count < 5)
            {
                //temporary color change
                GetComponent<Renderer>().material.color = endPointColor;
                Invoke("ReturnColor", 2f);
            }
        }

    }

    private void OnParticleCollision(GameObject other)
    {
        //not sure what to do here yet...
        //Debug.Log(other.gameObject.tag);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "indicator")
        {
            if(isFilled)
            {
                GetComponent<Renderer>().material.color = indicatorColor;
            }
        }
    }

    //return to endpoint color
    private void ReturnColor()
    {
        GetComponent<Renderer>().material.color = indicatorColor;
    }
}
