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

    //Only detects beakerSolution; check particle system trigger module
    private void OnParticleTrigger()
    {
        List<ParticleSystem.Particle> particleInside = new List<ParticleSystem.Particle>();
        if(beakerSolutionScript.isFilled)
        {
            Debug.Log("can't add another solution to beakker");
        } else
        {
            beakerSolution.GetComponent<Renderer>().material = reagentMaterial;
        }
        
        Debug.Log(reagentParticleSystem.GetTriggerParticles(ParticleSystemTriggerEventType.Inside, particleInside));

        if(buretteScript.funnelSnapped)
        {
            if(buretteScript.isFilled)
            {
                Debug.Log("burette is filled");
            } else
            {
                buretteSolution.GetComponent<Renderer>().material = reagentMaterial;
                buretteScript.isFilled = true;
            }
        }
    }
}
