using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTurretShot : MonoBehaviour {


    public GameObject projectile;
    private double nextAttackAllowed = 1.0f;
    private TurretStats stats;

    // Use this for initialization
    void Start()
    {
        stats = GetComponent<TurretStats>();
    }

    // Update is called once per frame
    void Update()
    {
		if (GameObject.FindGameObjectWithTag ("Enemy") != null) {
			if (Time.time > nextAttackAllowed) {
				foreach (GameObject enemy in GameObject.FindGameObjectsWithTag ("Enemy")) {
					float dist = Vector3.Distance (transform.position, enemy.transform.position);
					if (dist < stats.range) {
						if (Time.time > nextAttackAllowed) {
							nextAttackAllowed = Time.time + stats.fireRate;
							CreateProjectile ();
						}
					}
				}
			}
		}
    }

    void CreateProjectile()
    {
        Instantiate(projectile, new Vector2(transform.position.x, transform.position.y - 0.3f), Quaternion.identity);
    }
}
