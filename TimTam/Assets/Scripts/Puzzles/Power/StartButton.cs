using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    public PowerPuzzleController Console;

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        Console.CheckSolution();
        Debug.Log("START BUTTON PRESSED");

    }
}