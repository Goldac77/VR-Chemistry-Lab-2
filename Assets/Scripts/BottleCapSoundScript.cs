using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BottleCapSoundScript : MonoBehaviour
{
    [SerializeField] AudioClip capSelectAudio;
    AudioSource audioSource;
    XRGrabInteractable grabInteractable;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCapGrabbed()
    {
        IXRSelectInteractor interactor = grabInteractable.firstInteractorSelecting;
        if(interactor.transform.name != "capAttach")
        {
            audioSource.PlayOneShot(capSelectAudio, 1.0f);
        }
    }
}
