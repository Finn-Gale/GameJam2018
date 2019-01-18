using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    //This Manager is used to manage the scene as the timer in the game ticks down leadign to the time reset

    //Instance Variables

    //DECLARE a public String variable for the time remaining before time event, Call it _timeRemain
    public string _timeRemain;

    //DECLARE a private float Variable for the time remaingin before the time event, Call it _floatTimeRemain
    private float _floatTimeRemain;

    //DECLARE a Public float for the start Time, this will be inputted to the class to set the initial time. Call it _startTime
    public float _startTime;

    //DECLARE a private bool to signify if the timmer has reaced 0, call it _endTime
    private bool _endTime;

    //DECLARE a private float for the screenshot interval
    public float _screenshotInt;

    //DECLARE a private float for holding the screenshot timer
    private float _screenshotTimer;

    //DECLARE a varaible to hold a reference to the screenshot system
    public ScreenshotCamera _screenCam;

    public bool EndTimer
    {
        get { return _endTime; }
    }
    // Use this for initialization
    void Start()
    {
        //this sets the remaining time
        _floatTimeRemain = _startTime;

        //this sets the _endTime
        _endTime = false;

    }

    // Update is called once per frame
    void Update()
    {
        //This will take time away from the start time 
        _floatTimeRemain -= Time.deltaTime;

        if (_floatTimeRemain < 0)
        {
            //this sets the end time to true
            _endTime = true;
        }

        ConvertTime();

        // Screenshot subsystem
        // Update the timer with the current delta time
        _screenshotTimer += Time.deltaTime;

        // If the timer is greater than the interval, take screenshot and reset timer
        if (_screenshotInt < _screenshotTimer)
        {
            _screenCam.TakeScreenshot();
            _screenshotTimer = 0;
        }

    }

    //This method is used to convert the remaingin time to a string value, which is then stored as _timeRemain, call it ConvertTime
    private void ConvertTime()
    {
        //This rounds the _timeRemain float to a whole int
        int rounded = (int)Mathf.Round(_floatTimeRemain);

        //This gives the _timeRemain a strign value for the  remaingin time
        _timeRemain = rounded.ToString();

        //Debug.Log(_timeRemain);
    }

}
