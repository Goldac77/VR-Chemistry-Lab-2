using LiquidVolumeFX;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReagentBottleLiquidScript_Back : MonoBehaviour
{
    [SerializeField] BeakerSolutionScript_Back beakerSolutionScript_Back;
    [SerializeField] BuretteScript_Back buretteScript_Back;

    [SerializeField] Color acidColor;
    [SerializeField] Color baseColor;

    [SerializeField] bool isAcid;
    [SerializeField] bool isBase;

    [SerializeField] LiquidVolume buretteLiquidScript_Back;
    [SerializeField] LiquidVolume conicalFlaskLiquidScript_Back;

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
        if (buretteScript_Back.funnelSnapped)
        {
            //Possible bug?
            //The logic here has a LOT of issues, and edge cases that need to be fixed
            if (buretteScript_Back.isFilled)
            {
                Debug.Log("burette is filled");
                //play a different sound
                //actionDeniedSound.Play();
            }
            else
            {
                if (isAcid)
                {
                    buretteLiquidScript_Back.liquidColor1 = acidColor;
                }
                else
                {
                    buretteLiquidScript_Back.liquidColor1 = baseColor;
                }
                if(currentCoroutine == null)
                {
                    currentCoroutine = StartCoroutine(FillBurette());
                }   
            }
        }
        else
        {
            if (beakerSolutionScript_Back.isFilled)
            {
                Debug.Log("Conical flask filled");
                //play a different sound
                //actionDeniedSound.Play();
            }
            else
            {
                if (!buretteScript_Back.funnelSnapped)
                {
                    if(currentCoroutine == null)
                    {
                        currentCoroutine = StartCoroutine(FillConicalFlask());
                    }
                    if (isAcid)
                    {
                        conicalFlaskLiquidScript_Back.liquidColor1 = acidColor;
                        beakerSolutionScript_Back.isAcidFilled = true;
                    }
                    else
                    {
                        conicalFlaskLiquidScript_Back.liquidColor1 = baseColor;
                        beakerSolutionScript_Back.isBaseFilled = true;
                    }
                }
            }
        }

    }

    IEnumerator FillBurette()
    {
        float volume = buretteLiquidScript_Back.level;
        float maxFill = 1.0f;
        while (volume < maxFill)
        {
            if(isPouring)
            {
                volume += fillRate * Time.deltaTime;
                volume = Mathf.Min(volume, maxFill);
                buretteLiquidScript_Back.level = volume;
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
        float volume = conicalFlaskLiquidScript_Back.level;
        float maxFill = 0.36f;
        while (volume < maxFill)
        {
            if(isPouring)
            {
                volume += fillRate * Time.deltaTime;
                volume = Mathf.Min(volume, maxFill);
                conicalFlaskLiquidScript_Back.level = volume;
                yield return null;
            } else
            {
                break;
            }
            
        }
        currentCoroutine = null;
    }
}

