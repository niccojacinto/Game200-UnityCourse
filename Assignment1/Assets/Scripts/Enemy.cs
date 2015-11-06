using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public Transform bulletSpawn;
    public Rigidbody projectile;
    public float bulletSpeed;
    public float cooldown;
    public Transform player;
    public float playerDistance;
    public float rotationDamping;
    public float moveSpeed;

	void Start () {
        cooldown = 0.0f;
	}
	

	void Update () {
	    
	}

    void FixedUpdate() {
        UpdateCoolDown();
        playerDistance = Vector3.Distance(player.position, transform.position);

        if (playerDistance < 15.0f) {
            lookAtPlayer();
            shoot();
        }
        if (playerDistance < 12.0f) {
            chasePlayer();
        }
    }

    void UpdateCoolDown() {
        if (cooldown > 0) cooldown -= Time.deltaTime;
    }

    void lookAtPlayer() {
        Quaternion rotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationDamping);
    }

    void chasePlayer() {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }

    void shoot() {
        if (cooldown <= 0) { 
            Rigidbody instantiateProjectile = Instantiate(projectile, bulletSpawn.position, transform.rotation) as Rigidbody;
            instantiateProjectile.velocity = transform.TransformDirection(new Vector3(0, 0, bulletSpeed));
            cooldown = 2.0f;
        }
    }
}
