using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ChipPriorityScript : MonoBehaviour
{
    XRDirectInteractor directInteractor;
    [SerializeField] GameObject weighingBoat;
    XRGrabInteractable weighingBoatGrabInteractable;
    // Start is called before the first frame update
    void Start()
    {
        directInteractor = GetComponent<XRDirectInteractor>();
        weighingBoatGrabInteractable = weighingBoat.GetComponent<XRGrabInteractable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHoverChip()
    {
        bool boatHovered = directInteractor.interactablesHovered.Any(interactor => interactor.transform.name == "weighing boat");
        bool solubleHovered = directInteractor.interactablesHovered.Any(interactor => interactor.transform.CompareTag("soluble"));

        if (boatHovered && solubleHovered)
        {
            weighingBoatGrabInteractable.enabled = false;
        }
    }

    public void OnHoverChipExit()
    {
        if (!directInteractor.interactablesHovered.Any(interactor =>
        interactor.transform.name == "weighing boat" ||
        interactor.transform.CompareTag("soluble")))
        {
            weighingBoatGrabInteractable.enabled = true;
        }
    }
}
