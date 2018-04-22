using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterCreation : MonoBehaviour {

	public GameObject turretSelected;
	public bool canBuild = false;
	public Hammer hammer;
	public List<GameObject> predefinedTurret = new List<GameObject>();
	private int index = 0;
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
		if (Input.GetKeyDown ("n")) {
			if (canBuild == true && hammer.isSpotFree == false && hammer.associatedTurret.GetComponent<TurretStats> ().level < 3 && GetComponent<MainCharacterStat> ().gold >= turretSelected.GetComponent<TurretStats> ().turretCost * (turretSelected.GetComponent<TurretStats> ().level + 1) * (turretSelected.GetComponent<TurretStats> ().upgradeRatio)) {
				hammer.turret = turretSelected;
				hammer.associatedTurret.GetComponent<TurretStats> ().level += 1;
				hammer.Upgrade ();
				source.PlayOneShot (clip);
				GetComponent<MainCharacterStat> ().gold -= (int)Mathf.Round (turretSelected.GetComponent<TurretStats> ().turretCost * (turretSelected.GetComponent<TurretStats> ().level + 1) * (turretSelected.GetComponent<TurretStats> ().upgradeRatio));
			}
		}
		if (Input.GetKeyDown ("c")) {
			if (canBuild == true && hammer.isSpotFree == false) {
				GetComponent<MainCharacterStat> ().gold +=  (int)Mathf.Round (hammer.turret.GetComponent<TurretStats> ().turretCost * hammer.turret.GetComponent<TurretStats> ().level * 0.6f );
				hammer.RemoveTurret ();
				hammer.isSpotFree = true;
				source.PlayOneShot (clip);
			}
		}
		if (Input.GetKeyDown ("s")) {
			turretSelected = predefinedTurret [index];
			index++;
			if (index > 3)
				index = 0;
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Hammer")
		{
			canBuild = true;
			hammer = other.GetComponent<Hammer>();
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Hammer")
		{
			canBuild = false;
			hammer = null;
		}
	}
}
