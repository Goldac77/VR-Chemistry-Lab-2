using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Debugger : MonoBehaviour
{
    public TextMeshProUGUI debugText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayMessage(string message)
    {
        debugText.text = message;
    }
}
