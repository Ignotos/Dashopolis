using UnityEngine;
using System.Collections;

public class RockController : MonoBehaviour {

    public GameObject Rock;
    public Transform RockSpawn;
    public Transform RockSpawn1;
    public Transform RockSpawn2;
    public Transform RockSpawn3;
    public Transform RockSpawn4;
    public float fireRate;
    public float delay;
    private int no;
    private float no1;
    public static bool timeFreezeActivated;
    static GameObject rock1 = null;
    static GameObject rock2 = null;
    static GameObject rock3 = null;
    static GameObject rock4 = null;
    static GameObject rock5 = null;
    static Vector2 rock1_velocity = new Vector2();
    static Vector2 rock2_velocity = new Vector2();
    static Vector2 rock3_velocity = new Vector2();
    static Vector2 rock4_velocity = new Vector2();
    static Vector2 rock5_velocity = new Vector2();


    // Use this for initialization
    void Start ()
    {
        timeFreezeActivated = false;
        InvokeRepeating("Fire", delay, fireRate);
    }
	
	// Update is called once per frame
	void Fire()
    {
        if (!timeFreezeActivated)
        {
            no = Random.Range(0, 10);
            no1 = Random.Range(0.0f, 1.0f);

            //Debug.Log(no1);

            rock1 = null;
            rock2 = null;
            rock3 = null;
            rock4 = null;
            rock5 = null;
            rock1_velocity = new Vector2();
            rock2_velocity = new Vector2();
            rock3_velocity = new Vector2();
            rock4_velocity = new Vector2();
            rock5_velocity = new Vector2();


            switch (no)
            {
                case 0:
                    break;
                case 1:
                    rock1 = (GameObject)Instantiate(Rock, RockSpawn.position, RockSpawn.rotation);
                    rock1_velocity = rock1.GetComponent<Rigidbody2D>().velocity;
                    rock2 = (GameObject)Instantiate(Rock, RockSpawn1.position, RockSpawn1.rotation);
                    rock2_velocity = rock2.GetComponent<Rigidbody2D>().velocity;
                    break;
                case 2:
                    rock1 = (GameObject)Instantiate(Rock, RockSpawn3.position, RockSpawn3.rotation);
                    rock1_velocity = rock1.GetComponent<Rigidbody2D>().velocity;
                    rock2 = (GameObject)Instantiate(Rock, RockSpawn4.position, RockSpawn4.rotation);
                    rock2_velocity = rock2.GetComponent<Rigidbody2D>().velocity;
                    break;
                case 3:
                    rock1 = (GameObject)Instantiate(Rock, RockSpawn4.position, RockSpawn4.rotation);
                    rock1_velocity = rock1.GetComponent<Rigidbody2D>().velocity;
                    rock2 = (GameObject)Instantiate(Rock, RockSpawn1.position, RockSpawn1.rotation);
                    rock2_velocity = rock2.GetComponent<Rigidbody2D>().velocity;
                    break;
                case 4:
                    rock1 = (GameObject)Instantiate(Rock, RockSpawn2.position, RockSpawn2.rotation);
                    rock1_velocity = rock1.GetComponent<Rigidbody2D>().velocity;
                    rock2 = (GameObject)Instantiate(Rock, RockSpawn3.position, RockSpawn3.rotation);
                    rock2_velocity = rock2.GetComponent<Rigidbody2D>().velocity;
                    rock3 = (GameObject)Instantiate(Rock, RockSpawn4.position, RockSpawn4.rotation);
                    rock3_velocity = rock3.GetComponent<Rigidbody2D>().velocity;
                    break;
                case 5:
                    rock1 = (GameObject)Instantiate(Rock, RockSpawn.position, RockSpawn.rotation);
                    rock1_velocity = rock1.GetComponent<Rigidbody2D>().velocity;
                    rock2 = (GameObject)Instantiate(Rock, RockSpawn1.position, RockSpawn1.rotation);
                    rock2_velocity = rock2.GetComponent<Rigidbody2D>().velocity;
                    rock3 = (GameObject)Instantiate(Rock, RockSpawn4.position, RockSpawn4.rotation);
                    rock3_velocity = rock3.GetComponent<Rigidbody2D>().velocity;
                    break;
                case 6:
                    rock1 = (GameObject)Instantiate(Rock, RockSpawn1.position, RockSpawn1.rotation);
                    rock1_velocity = rock1.GetComponent<Rigidbody2D>().velocity;
                    rock2 = (GameObject)Instantiate(Rock, RockSpawn2.position, RockSpawn2.rotation);
                    rock2_velocity = rock2.GetComponent<Rigidbody2D>().velocity;
                    break;
                case 7:
                    rock1 = (GameObject)Instantiate(Rock, RockSpawn.position, RockSpawn.rotation);
                    rock1_velocity = rock1.GetComponent<Rigidbody2D>().velocity;
                    rock2 = (GameObject)Instantiate(Rock, RockSpawn2.position, RockSpawn2.rotation);
                    rock2_velocity = rock2.GetComponent<Rigidbody2D>().velocity;
                    rock3 = (GameObject)Instantiate(Rock, RockSpawn3.position, RockSpawn3.rotation);
                    rock3_velocity = rock3.GetComponent<Rigidbody2D>().velocity;
                    rock4 = (GameObject)Instantiate(Rock, RockSpawn4.position, RockSpawn4.rotation);
                    rock4_velocity = rock4.GetComponent<Rigidbody2D>().velocity;
                    break;
                case 8:
                    rock1 = (GameObject)Instantiate(Rock, RockSpawn.position, RockSpawn.rotation);
                    rock1_velocity = rock1.GetComponent<Rigidbody2D>().velocity;
                    rock2 = (GameObject)Instantiate(Rock, RockSpawn1.position, RockSpawn1.rotation);
                    rock2_velocity = rock2.GetComponent<Rigidbody2D>().velocity;
                    rock3 = (GameObject)Instantiate(Rock, RockSpawn2.position, RockSpawn2.rotation);
                    rock3_velocity = rock3.GetComponent<Rigidbody2D>().velocity;
                    rock4 = (GameObject)Instantiate(Rock, RockSpawn4.position, RockSpawn4.rotation);
                    rock4_velocity = rock4.GetComponent<Rigidbody2D>().velocity;
                    break;
                case 9:
                    rock1 = (GameObject)Instantiate(Rock, RockSpawn.position, RockSpawn.rotation);
                    rock1_velocity = rock1.GetComponent<Rigidbody2D>().velocity;
                    rock2 = (GameObject)Instantiate(Rock, RockSpawn1.position, RockSpawn1.rotation);
                    rock2_velocity = rock2.GetComponent<Rigidbody2D>().velocity;
                    rock3 = (GameObject)Instantiate(Rock, RockSpawn2.position, RockSpawn2.rotation);
                    rock3_velocity = rock3.GetComponent<Rigidbody2D>().velocity;
                    rock4 = (GameObject)Instantiate(Rock, RockSpawn3.position, RockSpawn3.rotation);
                    rock4_velocity = rock4.GetComponent<Rigidbody2D>().velocity;
                    rock5 = (GameObject)Instantiate(Rock, RockSpawn4.position, RockSpawn4.rotation);
                    rock5_velocity = rock5.GetComponent<Rigidbody2D>().velocity;
                    break;
                case 10:
                    break;
            }
        }
    }

    public static void ActivateTimeFreeze()
    {
        timeFreezeActivated = true;
        if (timeFreezeActivated)
        {
            if (rock1 != null)
            {
                rock1.GetComponent<Rigidbody2D>().gravityScale = 0;
                rock1.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            if (rock2 != null)
            {
                rock2.GetComponent<Rigidbody2D>().gravityScale = 0;
                rock2.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            if (rock3 != null)
            {
                rock3.GetComponent<Rigidbody2D>().gravityScale = 0;
                rock3.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            if (rock4 != null)
            {
                rock4.GetComponent<Rigidbody2D>().gravityScale = 0;
                rock4.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
            if (rock5 != null)
            {
                rock5.GetComponent<Rigidbody2D>().gravityScale = 0;
                rock5.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }

    public static void DeactivateTimeFreeze()
    {
        timeFreezeActivated = false;
        if (rock1 != null)
        {
            rock1.GetComponent<Rigidbody2D>().gravityScale = 1;
            rock1.GetComponent<Rigidbody2D>().velocity = rock1_velocity;
        }
        if (rock2 != null)
        {
            rock2.GetComponent<Rigidbody2D>().gravityScale = 1;
            rock2.GetComponent<Rigidbody2D>().velocity = rock2_velocity;
        }
        if (rock3 != null)
        {
            rock3.GetComponent<Rigidbody2D>().gravityScale = 1;
            rock3.GetComponent<Rigidbody2D>().velocity = rock3_velocity;
        }
        if (rock4 != null)
        {
            rock4.GetComponent<Rigidbody2D>().gravityScale = 1;
            rock4.GetComponent<Rigidbody2D>().velocity = rock4_velocity;
        }
        if (rock5 != null)
        {
            rock5.GetComponent<Rigidbody2D>().gravityScale = 1;
            rock5.GetComponent<Rigidbody2D>().velocity = rock5_velocity;
        }
    }

}
