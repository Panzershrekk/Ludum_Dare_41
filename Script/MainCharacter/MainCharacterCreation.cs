using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterCreation : MonoBehaviour {

	public GameObject turretSelected;
	public bool canBuild = false;
	public Hammer hammer;
	public AudioClip clip;
	AudioSource source;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("b")) {
			if (canBuild == true && hammer.isSpotFree == true && GetComponent<MainCharacterStat> ().gold >= turretSelected.GetComponent<TurretStats> ().turretCost) {
				hammer.turret = turretSelected;
				hammer.CreateTurret ();
				source.PlayOneShot (clip);
				GetComponent<MainCharacterStat> ().gold -= turretSelected.GetComponent<TurretStats> ().turretCost;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Hammer")
		{
			Debug.Log ("Entering Hammer Zone");
			canBuild = true;
			hammer = other.GetComponent<Hammer>();
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Hammer")
		{
			Debug.Log ("Leaving Hammer Zone");
			canBuild = false;
			hammer = null;
		}
	}
}
