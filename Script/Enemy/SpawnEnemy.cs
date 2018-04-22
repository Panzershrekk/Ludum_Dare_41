using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

	public float spawnRate = 5.0f;
	public GameObject enemyType;
	public double nextSpawnAllowed = 1.0f;
	public string ObjectiveTarget = "Objective";
	// Use this for initialization
	void Start()
	{
		if (enemyType.GetComponent<EnemyStats> ().isBoss == true) {
			nextSpawnAllowed = 120f;
		} else {
			nextSpawnAllowed = 10f;

		}
	}

	// Update is called once per frame
	void Update()
	{

		if (Time.time > nextSpawnAllowed) {
			nextSpawnAllowed = Time.time + spawnRate;
			CreateEnemy ();
		}
	}
	

	void CreateEnemy()
	{
		GameObject monster = Instantiate(enemyType, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
		monster.GetComponent<Base_Enemy_Behavior> ().target = ObjectiveTarget;
	}
}
