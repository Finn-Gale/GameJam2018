using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerButton : MonoBehaviour
{
    public float powerVal;
    private bool Active = false;

    public PowerPuzzleController Console;

    public GameObject led;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (Active == false)
        {
            Console.chargeConsole(powerVal);
            Active = true;
            Debug.Log("charging console");
            led.SetActive(true);
        }

        else if (Active == true)
        {
            Console.drainConsole(powerVal);
            Active = false;
            Debug.Log("Powering down Console");
            led.SetActive(false);
        }
    }

}