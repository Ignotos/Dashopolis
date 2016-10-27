using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
	public GameObject projectile;
	public float fireRate;
	public float delay;
	
	// Use this for initialization
	void Start () {
		//InvokeRepeating ("Shoot", delay, fireRate);
	}
	
	// Update is called once per frame
	void Update () {
		//Instantiate(projectile,transform.position, transform.rotation);
		//GetComponent<AudioSource>().Play();
	}
}
