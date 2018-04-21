using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

	public float spawnRate = 5.0f;
	public GameObject enemyType;
	private double nextSpawnAllowed = 1.0f;

	// Use this for initialization
	void Start()
	{
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
		Instantiate(enemyType, new Vector2(transform.position.x, transform.position.y), Quaternion.identity);
	}
}
