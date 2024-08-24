using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class HeightControllerScript : MonoBehaviour
{
    [SerializeField] InputActionReference primaryButtonReference;
    [SerializeField] InputActionReference secondaryButtonReference;
    [SerializeField] AudioSource pressed;
    bool primaryButtonPressed;
    bool secondaryButtonPressed;
    float playerHeight;
    Vector3 initialPosition;

    // Start is called before the first frame update
    void Start()
    {
        playerHeight = initialPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        initialPosition = transform.position;

        primaryButtonPressed = primaryButtonReference.action.triggered;
        secondaryButtonPressed = secondaryButtonReference.action.triggered;

        if (primaryButtonPressed)
        {
            if(playerHeight + 0.2f > 1.60f)
            {
                playerHeight = 1.60f;
            } else
            {
                playerHeight += 0.2f;
                pressed.Play();
            }
            UpdateHeight();
        }
        else if (secondaryButtonPressed)
        {
            if (playerHeight - 0.2f > 0.0f)
            {
                playerHeight -= 0.2f;
            }
            else
            {
                playerHeight = 0.0f;
            }
            UpdateHeight();
        }
    }

    void UpdateHeight()
    {
        Vector3 newPosition = initialPosition;
        newPosition.y = playerHeight;
        transform.position = newPosition;
    }
}
