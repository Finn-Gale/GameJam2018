using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour {

    protected bool PlayerInProximity;

    public GUICrosshair crosshair;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {

    }

    #region Crosshair Controls
    // Only Set crosshair to active if the player is close to the terminal
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            PlayerInProximity = true;
    }

    protected virtual void OnMouseOver()
    {
        if (PlayerInProximity)
            crosshair.SetActive();
    }
    // Set crosshair inactive if crosshair leaves terminal
    protected virtual void OnMouseExit()
    {
        crosshair.setNotActive();
    }
    // Or if the player leaves terminal proximity
    protected virtual void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerInProximity = false;
            crosshair.setNotActive();
        }
    }
    #endregion
}
