using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Interactable
{
    // Switch ID for puzzle controller
    public int mSwitchID;
    public SwitchPuzzle PuzzleController;
    private GameObject mCylinder;
    private string mCylinderID;
    // Use this for initialization
    void Start()
    {
        mCylinderID = "pCylinder" + mSwitchID.ToString();
        PlayerInProximity = false;
        mCylinder = GameObject.Find(mCylinderID).GetComponentInParent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        // Only Interact if crosshair 
        if (crosshair.Active)
            if (Input.GetMouseButtonUp(0))
                PuzzleController.SwitchToggled(mSwitchID);

        Setpos();

    }

    void Setpos()
    {
        if (PuzzleController.Switches[mSwitchID])
        {
            mCylinder.transform
        }
    }
}
