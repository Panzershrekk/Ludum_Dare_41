using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Enemy_Behavior : MonoBehaviour {

	public GameObject projectile;
	public string target;
	private GameObject[] checkPoints;
	private int currentIndex = 0;
	private GameObject wayPoint;
	private Vector2 wayPointPos;
	private EnemyStats stats;
	private double nextAttackAllowed = 2.0f;
	public AudioClip clip;
	AudioSource source;


	// Use this for initialization
	void Start () {

		checkPoints = new GameObject[GameObject.FindGameObjectsWithTag ("Checkpoint").Length];
		int i = 0;
		foreach (GameObject checkpoint in GameObject.FindGameObjectsWithTag("Checkpoint")) {
			checkPoints [i] = checkpoint;
			i++;
		}
			


		if (checkPoints.Length != 0)
			wayPoint = checkPoints [0];
		else
			wayPoint = GameObject.FindGameObjectWithTag(target);
		wayPointPos = new Vector2(wayPoint.transform.position.x, wayPoint.transform.position.y);
		stats = GetComponent<EnemyStats> ();
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 precPos = transform.position;
		transform.position = Vector3.MoveTowards(transform.position, wayPointPos, stats.movementSpeed * Time.deltaTime);
		if ((transform.position - checkPoints [currentIndex].transform.position).sqrMagnitude <= 0.2f * 0.2f && currentIndex < checkPoints.Length -1) {
			currentIndex++;
			wayPoint = checkPoints [currentIndex];
			wayPointPos = new Vector2 (wayPoint.transform.position.x, wayPoint.transform.position.y);
		} else if ((transform.position - checkPoints [currentIndex].transform.position).sqrMagnitude <= 0.2f * 0.2f && currentIndex >= checkPoints.Length -1){
			wayPoint = GameObject.FindGameObjectWithTag(target);
			wayPointPos = new Vector2(wayPoint.transform.position.x, wayPoint.transform.position.y);
		}
		if (stats.canShoot == true) {
			if (Time.time > nextAttackAllowed) {
				source.PlayOneShot (clip);
				nextAttackAllowed = Time.time + stats.fireRate;
				CreateProjectile ();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == target)
		{
			GameObject.FindGameObjectWithTag (target).GetComponent<Objective> ().hitpoint -= 1;
			Destroy (gameObject);
		}
	}

	void CreateProjectile()
	{
		Instantiate(projectile, new Vector2(transform.position.x, transform.position.y + 0.3f), Quaternion.identity);
	}
}
