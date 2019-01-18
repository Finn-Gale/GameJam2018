using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlickerLight : MonoBehaviour {


	public Light Neon;
	public float minWaitTime;
	public float maxWaitTime;

	void Start()
	{
		Neon = GetComponent<Light> ();
		StartCoroutine (Flashing ());

	}


	IEnumerator Flashing()
	{
		while (true) 
		{
			yield return new WaitForSeconds(Random.Range(minWaitTime,maxWaitTime));
			Neon.enabled = ! Neon.enabled;
		}


	}


	public void TurnLightOn()
	{
		Neon.enabled = ! Neon.enabled;
	}

	public void TurnLightOff()
	{
		Neon.enabled = ! Neon.enabled;
	}


	// Update is called once per frame
	void Update () {

	}

}
