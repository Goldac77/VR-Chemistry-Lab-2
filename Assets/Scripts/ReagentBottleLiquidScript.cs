using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReagentBottleLiquidScript : MonoBehaviour
{
    [SerializeField] GameObject beakerSolution;
    [SerializeField] GameObject buretteSolution;
    [SerializeField] BeakerSolutionScript beakerSolutionScript;
    [SerializeField] BuretteScript buretteScript;
    [SerializeField] Material reagentMaterial;
    ParticleSystem reagentParticleSystem;
    // Start is called before the first frame update
    void Start()
    {
        reagentParticleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleTrigger()
    {
        if (buretteScript.funnelSnapped && !beakerSolutionScript.isFilled)
        {
            //Possible bug?
            //Filling the beaker when funnel is snapped will fill burette instead
            if (buretteScript.isFilled)
            {
                Debug.Log("burette is filled");
            }
            else
            {
                buretteSolution.GetComponent<Renderer>().material = reagentMaterial;
                buretteScript.isFilled = true;
            }
        } else
        {
            beakerSolution.GetComponent<Renderer>().material = reagentMaterial;
        }
    }
}
