using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour {
	private GameObject wayPoint;
	private Vector2 wayPointPos;
	public float speed = 20.0f;

	// Use this for initialization
	void Start()
	{
		wayPoint = GameObject.FindGameObjectWithTag("Player");
		wayPointPos = new Vector2(wayPoint.transform.position.x, wayPoint.transform.position.y);
	}

	// Update is called once per frame
	void Update()
	{
		Vector3 precPos = transform.position;
		transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
		if (precPos == transform.position)
			Destroy(gameObject);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		print(other.name);
		if (other.tag == "Player")
		{
			other.GetComponent<MainCharacterStat>().charaterHitPoint -= 1;
			Destroy(gameObject);

		}
	}
}
