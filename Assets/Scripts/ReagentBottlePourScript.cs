using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ReagentBottlePourScript : MonoBehaviour
{
    [SerializeField] ParticleSystem liquidPouring;
    [SerializeField] XRSocketInteractor capSocket;
    [HideInInspector] public bool capAttached;
    [SerializeField] Debugger debugger;

    [HideInInspector] public bool grabbed;

    Vector3 bottleRotation;

    Transform bottleTransform;

    [SerializeField] float pourAngleThreshold = 45f;

    // Start is called before the first frame update
    void Start()
    {
        capAttached = false;
        bottleTransform = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!capAttached)
        {
            CheckTiltAndPour();
        }
    }

    public void OnGrabbed()
    {
        CheckObjectInSocket();
        grabbed = true;
    }

    public void OnGrabExited()
    {
        grabbed = false;
    }

    private void CheckObjectInSocket()
    {
        IXRSelectInteractable objectInSocket = capSocket.GetOldestInteractableSelected();

        if (objectInSocket != null && objectInSocket.transform.tag == "cap")
        {
            capAttached = true;
        } else
        {
            capAttached = false;
        }

    }

    void CheckTiltAndPour()
    {
        Vector3 bottleUp = bottleTransform.up;

        float tiltAngle = Vector3.Angle(bottleUp, Vector3.up);

        if (tiltAngle >= pourAngleThreshold)
        {
            liquidPouring.transform.localRotation = Quaternion.LookRotation(bottleTransform.up);
            if (!liquidPouring.isEmitting)
            {
                liquidPouring.Play();
            }
        }
        else
        {
            if (liquidPouring.isEmitting)
            {
                liquidPouring.Stop();
            }
        }
    }
}
