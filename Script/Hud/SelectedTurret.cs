using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectedTurret : MonoBehaviour {

	public MainCharacterCreation selectedTurret;
	public ImageData[] images;
	private GameObject currentTurret;

	// Use this for initialization
	void Start () {
		//GetComponent<Image>().sprite = selectedTurret.turretSelected;
	}
	
	// Update is called once per frame
	void Update () {
		selectedTurret = GameObject.FindGameObjectWithTag ("Player").GetComponent<MainCharacterCreation>();
		foreach (ImageData image in images)
		{
			if (image.associatedTurret == selectedTurret.turretSelected) {
				currentTurret = selectedTurret.turretSelected;
				GetComponent<Image> ().sprite = image.GetComponent<Image> ().sprite;
			}
		}
	}
}
