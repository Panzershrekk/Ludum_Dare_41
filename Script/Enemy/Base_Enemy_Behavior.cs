using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Enemy_Behavior : MonoBehaviour {

	public GameObject projectile;
	private GameObject wayPoint;
	private Vector2 wayPointPos;
	private EnemyStats stats;
	private double nextAttackAllowed = 2.0f;
	public AudioClip clip;
	AudioSource source;


	// Use this for initialization
	void Start () {
		wayPoint = GameObject.FindGameObjectWithTag("Objective");
		wayPointPos = new Vector2(wayPoint.transform.position.x, wayPoint.transform.position.y);
		stats = GetComponent<EnemyStats> ();
		source = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 precPos = transform.position;
		transform.position = Vector3.MoveTowards(transform.position, wayPointPos, stats.movementSpeed * Time.deltaTime);
		if (stats.canShoot == true) {
			if (Time.time > nextAttackAllowed) {
				nextAttackAllowed = Time.time + stats.fireRate;
				CreateProjectile ();
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Objective")
		{
			GameObject.FindGameObjectWithTag ("Objective").GetComponent<Objective> ().hitpoint -= 1;
			Destroy (gameObject);
		}
	}

	void CreateProjectile()
	{
		Instantiate(projectile, new Vector2(transform.position.x, transform.position.y + 0.3f), Quaternion.identity);
	}
}
