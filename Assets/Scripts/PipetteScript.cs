using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipetteScript : MonoBehaviour
{
    public GameObject pipetteSolution;
    Material startingMaterial;

    //beaker properties
    [SerializeField] BeakerSolutionScript beakerSolutionScript;


    public bool solutionPicked;
    // Start is called before the first frame update
    void Start()
    {
        solutionPicked = false;
        startingMaterial = pipetteSolution.GetComponent<Renderer>().material; //same material for buretteSolution
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //drawing solution
        if(other.gameObject.tag == "reagent" && !solutionPicked)
        {
            pipetteSolution.GetComponent<Renderer>().material = other.GetComponent<Renderer>().material;
            solutionPicked = true;
        }

        //emptying solution in beaker
        if(other.gameObject.tag == "beakerSolution" && solutionPicked)
        {
            //only empty if beaker is empty
            if(!beakerSolutionScript.isFilled)
            {
                other.GetComponent<Renderer>().material = pipetteSolution.GetComponent<Renderer>().material;
                pipetteSolution.GetComponent<Renderer>().material = startingMaterial;
                solutionPicked = false;
            } else
            {
                Debug.Log("nice try lol");
            }
            
        }
    }
}
