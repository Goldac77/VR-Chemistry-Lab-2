using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;

public class SolutionContainer : MonoBehaviour
{
    [Range(0.46f, 0.63f)]
    [SerializeField] float fill;

    [SerializeField] Material solution;

    // Update is called once per frame
    void Update()
    {
        //in update, incase it needs to changed by other processes
        solution.SetFloat("_Fill", fill);
    }
}
