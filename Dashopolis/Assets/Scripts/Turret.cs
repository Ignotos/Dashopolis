using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
	public GameObject projectile;
	public Transform projectileSpawnPoint;
	public float fireRate;
	public float delay;
	
	// Use this for initialization
	void Start () {
		fireRate = 3f;
		delay = 0.5f;
		InvokeRepeating ("Shoot", delay, fireRate);
	}
	
	// Update is called once per frame
	void Shoot () {
		Instantiate(projectile,projectileSpawnPoint.position, projectileSpawnPoint.rotation);
		//GetComponent<AudioSource>().Play();
	}
}
