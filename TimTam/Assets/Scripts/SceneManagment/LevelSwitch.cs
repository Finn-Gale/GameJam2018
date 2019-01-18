using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSwitch : MonoBehaviour {
    //This class is used to switch between scenes based on a timmer count down


    //DECLARE a Scene name string that will define the name of the scene that the Application will load, call it _myScene
    public string _myScene;

    //DECLARE a Timer object that will hold the value of the endtime value, call it _mTimer
    public Timer _myTimer;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //this checks if the End timmer has been reached, if so it will unload the scene and load onther scene
        if(_myTimer.EndTimer)
        {
            SceneManager.LoadScene(_myScene);
        }
	}
}
