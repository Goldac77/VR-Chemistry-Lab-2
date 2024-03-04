using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuretteTapScript_Back : MonoBehaviour
{
    [SerializeField] ParticleSystem liquidFlowing;
    [SerializeField] GameObject buretteSolution;

    [SerializeField] BuretteScript_Back buretteScript_back;

    [SerializeField] BeakerSolutionScript_Back beakerSolutionScript_back;

    bool tapGrabbed;

    private void Start()
    {
        tapGrabbed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(tapGrabbed)
        {
            float volume = buretteSolution.GetComponent<Renderer>().material.GetFloat("_Fill");

            //reduce volume of burette solution
            if(volume > 0.42f && volume <= 0.63f)
            {
                volume -= 0.02f * Time.deltaTime;

                //edge case bug fix, not ideal lol
                if(volume < 0.42f)
                {
                    volume = 0.42f;
                    liquidFlowing.Stop();
                }
            } else
            {
                buretteScript_back.isFilled = false;
            }
            
            buretteSolution.GetComponent<Renderer>().material.SetFloat("_Fill", volume);
        }
    }

    public void OnGrabbed()
    {
        //get the material of the liquid in the burette and apply to particle system
        var main = liquidFlowing.main;
        main.startColor = buretteSolution.GetComponent<Renderer>().material.color;
        if(buretteScript_back.isFilled)
        {
            if(beakerSolutionScript_back.indicatorAdded)
            {
                liquidFlowing.Play();
                beakerSolutionScript_back.isReacting = true;
            } else
            {
                Debug.Log("Add indicator first lol");
            }
            
        } else
        {
            Debug.Log("I'm empty :/");
        }
        tapGrabbed = true;
        
    }

    public void OnGrabExited()
    {
        tapGrabbed = false;
        liquidFlowing.Stop();
        beakerSolutionScript_back.isReacting = false;
    }
}