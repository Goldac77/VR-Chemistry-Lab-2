using LiquidVolumeFX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuretteTapScript : MonoBehaviour
{
    [SerializeField] ParticleSystem liquidFlowing;

    [SerializeField] BuretteScript buretteScript;

    [SerializeField] BeakerSolutionScript beakerSolutionScript;

    [SerializeField] LiquidVolume buretteLiquidScript;

    bool tapGrabbed;

    private void Start()
    {
        tapGrabbed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(tapGrabbed && beakerSolutionScript.isReacting)
        {
            float volume = buretteLiquidScript.level;

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
                buretteScript.isFilled = false;
            }

            buretteLiquidScript.level = volume;
        }
    }

    public void OnGrabbed()
    {
        //get the material of the liquid in the burette and apply to particle system
        var main = liquidFlowing.main;
        main.startColor = buretteLiquidScript.liquidColor1;
        if(buretteScript.isFilled)
        {
            if(!buretteScript.funnelSnapped)
            {
                if (beakerSolutionScript.indicatorAdded)
                {
                    liquidFlowing.Play();
                    beakerSolutionScript.isReacting = true;
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
        beakerSolutionScript.isReacting = false;
    }
}
