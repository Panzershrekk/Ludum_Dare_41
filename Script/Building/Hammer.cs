using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour {

	public GameObject associatedTurretSpot;
	public GameObject turret;
	public GameObject associatedTurret;
	public bool isSpotFree = true;
	// Use this for initialization

	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CreateTurret()
	{
		associatedTurret = Instantiate(turret, new Vector2(associatedTurretSpot.transform.position.x, associatedTurretSpot.transform.position.y), Quaternion.identity);
		isSpotFree = false;
	}

	public void Upgrade()
	{
		if (associatedTurret.GetComponent<TurretStats> ().level == 2) {
			associatedTurret.GetComponent<SpriteRenderer> ().color = Color.yellow;
			associatedTurret.GetComponent<TurretStats> ().damage += 1;
			associatedTurret.GetComponent<TurretStats> ().fireRate -= 0.1f;
			associatedTurret.GetComponent<TurretStats> ().range += 1;


		}
		if (associatedTurret.GetComponent<TurretStats> ().level == 3) {			
			associatedTurret.GetComponent<SpriteRenderer> ().color = Color.red;
			associatedTurret.GetComponent<TurretStats> ().damage += 1;
			associatedTurret.GetComponent<TurretStats> ().fireRate -= 0.1f;
			associatedTurret.GetComponent<TurretStats> ().range += 1;
		}
	}

	public void RemoveTurret()
	{
		Destroy(associatedTurret);
	}
}
