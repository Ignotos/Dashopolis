using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
	public GameObject projectile;
	public Transform projectileSpawnPoint;
	public float fireRate;
	public float delay;
    public static bool timeFreezeActivated;
	
	// Use this for initialization
	void Start () {
		//fireRate = 0.5f;
		//delay = 0.5f;
        timeFreezeActivated = false;
		InvokeRepeating ("Shoot", delay, fireRate);
	}
	
	// Update is called once per frame
	void Shoot () {
        if (!timeFreezeActivated)
        {
            int random = Random.Range(0, 8);
            if (random == 0)
            {
                Instantiate(projectile, projectileSpawnPoint.position, projectileSpawnPoint.rotation);
            }
            //GetComponent<AudioSource>().Play();
        }
    }

    public static void ActivateTimeFreeze()
    {
        timeFreezeActivated = true;
    }

    public static void DeactivateTimeFreeze()
    {
        timeFreezeActivated = false;
    }
}
