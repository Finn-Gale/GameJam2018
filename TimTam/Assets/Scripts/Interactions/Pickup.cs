using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : Interactable {

    //BUG with this Code, if your holding an object you can pass an object through a collision box and it will fall past the collision box
    //This variab is the hand object that the pickup object will recognize as itsnew location, call it hand pos

    private Transform _handPos;

    //this bool is used to identify if the item has been grabbed, call it _InHand
    private bool _inHand;

    private float _mSpeed;
	// Use this for initialization
	void Start () {
        _inHand = false;

        _mSpeed = 5;

	}
	
	// Update is called once per frame
	void Update () {

        //this checsk if an object is being held by the player 
        if (_inHand)
        {
            //this calls the holding method
            Holding();

            //if the button is pressed the item is droped
            if (Input.GetMouseButtonUp(0))
            {
                Drop();
            }
        }

        //if nothing in hand 
        else if (crosshair.Active)
        {

            //if the button is pressed the player will pick up the object
            if (Input.GetMouseButtonUp(0)&& _inHand ==false)
            {
                Grabbed();
            }
            
        }


        
    }

    //This metthod is ucalled when the object is picked up
    private void Grabbed()
    {
        //this turns of the gravity of the object so that it does not fall as it is picked up by the player
        GetComponent<Rigidbody>().useGravity = false;

        _inHand = true;

        
    }

    //this method 
    private void Holding()
    {
        //This finds the 
        _handPos = GameObject.Find("FPSHand").transform;

        float change = _mSpeed * Time.deltaTime;
        //this changesposition of the object to be the location of the hand
        transform.position = Vector3.MoveTowards(transform.position, _handPos.position,change);

        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
    }

    private void Drop()
    {
        _inHand = false;

        //turns on gravity
        GetComponent<Rigidbody>().useGravity = true;

        //sets velocity to 0
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
    }
}
