using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour {

	public GameObject associatedTurretSpot;
	public GameObject turret;
	public bool isSpotFree = true;
	// Use this for initialization

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CreateTurret()
	{
		Instantiate(turret, new Vector2(associatedTurretSpot.transform.position.x, associatedTurretSpot.transform.position.y), Quaternion.identity);
		isSpotFree = false;
	}
}
