using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour {

	public int hitpoint = 50;
	public Text hitpointText;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		hitpointText.text = "Remaining: " + hitpoint;
	}
}
