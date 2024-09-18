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

    [SerializeField] float flowRate;

    [SerializeField] AudioSource actionDeniedSound;

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
                volume -= flowRate * Time.deltaTime;

                //edge case bug fix
                if(volume < 0.0f)
                {
                    volume = 0.0f;
                    liquidFlowing.Stop();
                    buretteScript.isFilled = false;
                }
            }
            buretteLiquidScript.level = volume;
        }
    }

    public void OnGrabbed()
    {
        //get the material of the liquid in the burette and apply to particle system
        var main = liquidFlowing.main;
        main.startColor = buretteLiquidScript.liquidColor1;
        if(buretteLiquidScript.level > 0)
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
                    actionDeniedSound.Play();
                }
            } else
            {
                Debug.Log("You need to remove the funnel");
                actionDeniedSound.Play();
            }    
        } else
        {
            Debug.Log("I'm empty :/");
            actionDeniedSound.Play();
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
