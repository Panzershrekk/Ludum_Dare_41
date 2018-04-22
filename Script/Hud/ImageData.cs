using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ImageData : MonoBehaviour, IPointerClickHandler {

	public GameObject associatedTurret;
	public MainCharacterCreation selectedTurret;

	// Use this for initialization
	void Start () {
		selectedTurret = GameObject.FindGameObjectWithTag ("Player").GetComponent<MainCharacterCreation> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		Debug.Log ("I'm clicked");
		selectedTurret.turretSelected = associatedTurret;
	}
}
