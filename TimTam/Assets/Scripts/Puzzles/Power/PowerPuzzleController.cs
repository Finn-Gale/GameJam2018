using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerPuzzleController : MonoBehaviour
{
    public float Target = 10;
    public float Power = 0;

    public Text ChargeLevel;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CheckSolution();
    }

    public void CheckSolution()
    {
        if (Power == Target)
        {
            //Puzzle Complete
            Debug.Log("SUCCESS");
           
        }
        else if (Power != Target)
        {
            Debug.Log("FAIL");
        }

        if (Power > Target)
        {
            Power = 0;
        }

    }

    #region CONSOLE POWER MANAGEMENT

    //ADD power to console
    public void chargeConsole(float transfer)
    {
        //INCREASE POWER BASED ON BUTTON VALUE
        Power += transfer;
    }

    //Remove power from console
    public void drainConsole(float incomingPower)
    {
        Power -= incomingPower;
    }
    #endregion
}