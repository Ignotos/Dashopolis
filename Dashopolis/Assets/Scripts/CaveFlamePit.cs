using UnityEngine;
using System.Collections;

public class CaveFlamePit : MonoBehaviour {
	public GameObject projectile;
	//public Transform projectileSpawnPoint;
	public float fireRate;
	public float delay;
    public static bool timeFreezeActivated;
	
	// Use this for initialization
	void Start () {
        //fireRate = 0.25f;
        //delay = 0.5f;
        timeFreezeActivated = false;
		InvokeRepeating ("Shoot", delay, fireRate);
	}
	
	// Update is called once per frame
	void Shoot () {
        if (!timeFreezeActivated)
        {
            int randomXoffset = Random.Range(-13, 13);
            Instantiate(projectile, new Vector3(transform.position.x + randomXoffset + 0.5f, transform.position.y, transform.position.z), transform.rotation);
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
