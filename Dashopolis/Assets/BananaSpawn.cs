using UnityEngine;
using System.Collections;

public class BananaSpawn : MonoBehaviour {

    public GameObject Banana;
    public Transform BananaShot;
    public float fireRate;
    public float delay;
    public Vector2 Speed;
    public static bool timeFreezeActivated;
    static GameObject Banana1 = null;
    static Vector2 Banana_velocity = new Vector2();

    // Use this for initialization
    void Start () {

        timeFreezeActivated = false;
        InvokeRepeating("Fire", delay, fireRate);
  

    }


    void Fire()
    {
        if (!timeFreezeActivated)
        {
            Banana1 = null;

            Banana1 = (GameObject)Instantiate(Banana, BananaShot.position, BananaShot.rotation);
            Banana1.GetComponent<Rigidbody2D>().velocity = Speed;
            Banana_velocity = Banana1.GetComponent<Rigidbody2D>().velocity;
            
        }
    }


    public static void ActivateTimeFreeze()
    {
        timeFreezeActivated = true;
        if (timeFreezeActivated)
        {
            Banana1.GetComponent<Rigidbody2D>().gravityScale = 0;
            Banana1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }


    public static void DeactivateTimeFreeze()
    {
        timeFreezeActivated = false;
        if (Banana1 != null)
        {
            Banana1.GetComponent<Rigidbody2D>().gravityScale = 1;
            Banana1.GetComponent<Rigidbody2D>().velocity = Banana_velocity;
        }
    }


    // Update is called once per frame
    void Update () {
	
	}
}
