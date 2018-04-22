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
							Vector3 diff = enemy.transform.position - transform.position;
							diff.Normalize();

							float rot_z = Mathf.Atan2 (diff.y, diff.x) * Mathf.Rad2Deg;
							transform.rotation = Quaternion.Euler (0f, 0f, rot_z + 90);
							/*Quaternion rotation = Quaternion.LookRotation (enemy.transform.position - transform.position, transform.TransformDirection(Vector3.down));
							transform.rotation = new Quaternion (0, 0, rotation.z, rotation.w);*/
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
        GameObject shot = Instantiate(projectile, new Vector2(transform.position.x, transform.position.y - 0.3f), Quaternion.identity);
		shot.GetComponent<ProjectileMovement> ().projectileDamage = stats.damage;
    }
}
