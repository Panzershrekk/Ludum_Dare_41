using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyStats : MonoBehaviour {

	// Use this for initialization
    public int hitpoint = 3;
    public float movementSpeed = 2.0f;
    public float fireRate = 4.0f;
	public int goldValue = 10;
	public int damageOnObjective = 1;
	public bool canShoot = false;
	public bool isBoss = false;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (hitpoint <= 0) {
			/*AudioSource audio = GetComponent<AudioSource> ();
			audio.Play ();*/
			GameObject.FindGameObjectWithTag("Player").GetComponent<MainCharacterStat>().gold += goldValue;
			if (isBoss == true) {
				SceneManager.LoadScene ("MainMenu");
			}
			Destroy (gameObject);
		}
	}
}
