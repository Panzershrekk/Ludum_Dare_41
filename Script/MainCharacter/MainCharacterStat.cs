using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainCharacterStat : MonoBehaviour
{

    public int charaterHitPoint = 5;
    public int gold = 300;

	public Text goldText;
	public Text hitpointText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		goldText.text = "Gold: " + gold;
		hitpointText.text = "Hitpoint: " + charaterHitPoint;
		if (charaterHitPoint <= 0) {
			SceneManager.LoadScene ("MainMenu");
		}
			
	}
}
