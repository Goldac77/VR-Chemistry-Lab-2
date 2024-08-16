using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class PauseMenuTrigger : MonoBehaviour
{
    [SerializeField] InputActionReference pauseMenu;
    [SerializeField] GameObject pauseMenuCanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pauseMenu.action.triggered && !pauseMenuCanvas.activeInHierarchy)
        {
            pauseMenuCanvas.SetActive(true);
        } else
        {
            pauseMenuCanvas.SetActive(false);
        }
        
    }
}
