using LiquidVolumeFX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuretteTapScript_Back : MonoBehaviour
{
    [SerializeField] ParticleSystem liquidFlowing;

    [SerializeField] BuretteScript_Back buretteScript_back;

    [SerializeField] BeakerSolutionScript_Back beakerSolutionScript_back;

    [SerializeField] LiquidVolume buretteSolutionScript_Back;

    bool tapGrabbed;

    private void Start()
    {
        tapGrabbed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(tapGrabbed && beakerSolutionScript_back.isReacting)
        {
            float volume = buretteSolutionScript_Back.level;

            //reduce volume of burette solution
            if(volume > 0.0f && volume <= 1.0f)
            {
                volume -= 0.02f * Time.deltaTime;

                //edge case bug fix, not ideal lol
                if(volume < 0.0f)
                {
                    volume = 0.0f;
                    liquidFlowing.Stop();
                }
            } else
            {
                buretteScript_back.isFilled = false;
            }

            buretteSolutionScript_Back.level = volume;
        }
    }

    public void OnGrabbed()
    {
        //get the material of the liquid in the burette and apply to particle system
        var main = liquidFlowing.main;
        main.startColor = buretteSolutionScript_Back.liquidColor1;
        if(buretteScript_back.isFilled)
        {
            if(!buretteScript_back.funnelSnapped)
            {
                if (beakerSolutionScript_back.indicatorAdded)
                {
                    liquidFlowing.Play();
                    beakerSolutionScript_back.isReacting = true;
                }
                else
                {
                    Debug.Log("Add indicator first lol");
                }
            } else
            {
                Debug.Log("You need to remove the funnel");
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
