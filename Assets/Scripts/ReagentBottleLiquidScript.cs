using LiquidVolumeFX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReagentBottleLiquidScript : MonoBehaviour
{
    [SerializeField] BeakerSolutionScript beakerSolutionScript;
    [SerializeField] BuretteScript buretteScript;

    [SerializeField] Color acidColor;
    [SerializeField] Color baseColor;

    [SerializeField] bool isAcid;
    [SerializeField] bool isBase;

    [SerializeField] LiquidVolume buretteLiquidScript;
    [SerializeField] LiquidVolume conicalFlaskLiquidScript;

    [SerializeField] float fillRate;

    [SerializeField] AudioSource actionDeniedSound;

    bool isPouring;

    ParticleSystem particleSystemMain;

    Coroutine currentCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        particleSystemMain = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(particleSystemMain.isEmitting)
        {
            isPouring = true;
        } else
        {
            isPouring = false;
            if(currentCoroutine != null)
            {
                StopCoroutine(currentCoroutine);
                currentCoroutine = null;
            }
        }
    }

    private void OnParticleTrigger()
    {
        if (buretteScript.funnelSnapped)
        {
            //Possible bug?
            //The logic here has a LOT of issues, and edge cases that need to be fixed
            if (buretteScript.isFilled)
            {
                Debug.Log("burette is filled");
                //play a different sound
                //actionDeniedSound.Play();
            }
            else
            {
                if (isAcid)
                {
                    buretteLiquidScript.liquidColor1 = acidColor;
                }
                else
                {
                    buretteLiquidScript.liquidColor1 = baseColor;
                }
                if(currentCoroutine == null)
                {
                    currentCoroutine = StartCoroutine(FillBurette());
                }
            }
        } else
        {
            if(beakerSolutionScript.isFilled)
            {
                Debug.Log("Conical flask filled");
                //play a different sound
                //actionDeniedSound.Play();
            } else
            {
                if(!buretteScript.funnelSnapped)
                {
                    if(currentCoroutine == null)
                    {
                        currentCoroutine = StartCoroutine(FillConicalFlask());
                    }
                    
                    if (isAcid)
                    {
                        conicalFlaskLiquidScript.liquidColor1 = acidColor;
                        beakerSolutionScript.isAcidFilled = true;
                    }
                    else
                    {
                        conicalFlaskLiquidScript.liquidColor1 = baseColor;
                        beakerSolutionScript.isBaseFilled = true;
                    }
                }
            } 
        }
    }

    IEnumerator FillBurette()
    {
        float volume = buretteLiquidScript.level;
        float maxFill = 1.0f;
        while(volume < maxFill)
        {
            if(isPouring)
            {
                volume += fillRate * Time.deltaTime;
                volume = Mathf.Min(volume, maxFill);
                buretteLiquidScript.level = volume;
                yield return null;
            } else
            {
                break;
            }
        }
        currentCoroutine = null;
    }

    IEnumerator FillConicalFlask()
    {
        float volume = conicalFlaskLiquidScript.level;
        float maxFill = 0.36f;
        while(volume < maxFill)
        {
            if(isPouring)
            {
                volume += fillRate * Time.deltaTime;
                volume = Mathf.Min(volume, maxFill);
                conicalFlaskLiquidScript.level = volume;
                yield return null;
            } else
            {
                break;
            }
        }
        currentCoroutine = null;
    }
}
