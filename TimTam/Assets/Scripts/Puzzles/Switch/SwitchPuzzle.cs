using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPuzzle : MonoBehaviour
{
    private bool[] mSwitches;
    private bool mSolved;
	// Use this for initialization
	void Start ()
    {
        mSwitches = new bool[5];
        mSwitches[0] = true;
        mSwitches[1] = true;
        mSwitches[2] = false;
        mSwitches[3] = true;
        mSwitches[4] = false;
    }
	
    public bool[] Switches
    {
        get { return mSwitches; }
    }
	// Update is called once per frame
	void Update ()
    {
        mSolved = true;
        Checkifsolved();
	}

    void Checkifsolved()
    {
        foreach (bool b in mSwitches)
        {
            if (b==false)
                mSolved = false;
        }

        if (mSolved == true)
            PuzzleComplete();
    }

    void PuzzleComplete()
    {

    }

    public void SwitchToggled(int i)
    {
        mSwitches[i] = !mSwitches[i];
    }
}
