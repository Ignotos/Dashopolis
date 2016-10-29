using UnityEngine;
using System.Collections;

public class CaveFlamePit : MonoBehaviour {
	public GameObject projectile;
	//public Transform projectileSpawnPoint;
	public float fireRate;
	public float delay;
	
	// Use this for initialization
	void Start () {
		//fireRate = 0.25f;
		//delay = 0.5f;
		InvokeRepeating ("Shoot", delay, fireRate);
	}
	
	// Update is called once per frame
	void Shoot () {
		int randomXoffset = Random.Range(-13,13);	
		Instantiate(projectile,new Vector3(transform.position.x + randomXoffset + 0.5f, transform.position.y,transform.position.z), transform.rotation);
	}
}
