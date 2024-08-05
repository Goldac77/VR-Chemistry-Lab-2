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
        initialPosition = transform.position;
        playerHeight = initialPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        primaryButtonPressed = primaryButtonReference.action.triggered;
        secondaryButtonPressed = secondaryButtonReference.action.IsPressed();

        if (primaryButtonPressed)
        {
            pressed.Play();
            playerHeight += 0.2f;
            UpdateHeight();
        }
        else if (secondaryButtonPressed)
        {
            if (playerHeight - 0.2f > 0.0f)
            {
                playerHeight -= 0.2f;
                UpdateHeight();
            }
            else
            {
                playerHeight = 0.0f;
            }
        }
    }

    void UpdateHeight()
    {
        Vector3 newPosition = initialPosition;
        newPosition.y = playerHeight;
        transform.position = newPosition;
    }
}
