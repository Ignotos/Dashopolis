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

    // Use this for initialization
    void Start ()
    {

        InvokeRepeating("Fire", delay, fireRate);

    }
	
	// Update is called once per frame
	void Fire()
    {
        no = Random.Range(0, 10);
        no1 = Random.Range(0.0f, 1.0f);

        //Debug.Log(no1);

        switch (no)
        {
            case 0:
                break;
            case 1:
                Instantiate(Rock, RockSpawn.position, RockSpawn.rotation);
                Instantiate(Rock, RockSpawn1.position, RockSpawn1.rotation);
                break;
            case 2:
                Instantiate(Rock, RockSpawn3.position, RockSpawn3.rotation);
                Instantiate(Rock, RockSpawn4.position, RockSpawn4.rotation);
                break;
            case 3:
                Instantiate(Rock, RockSpawn4.position, RockSpawn4.rotation);
                Instantiate(Rock, RockSpawn1.position, RockSpawn1.rotation);
                break;
            case 4:
                Instantiate(Rock, RockSpawn2.position, RockSpawn2.rotation);
                Instantiate(Rock, RockSpawn3.position, RockSpawn3.rotation);
                Instantiate(Rock, RockSpawn4.position, RockSpawn4.rotation);
                break;
            case 5:
                Instantiate(Rock, RockSpawn.position, RockSpawn.rotation);
                Instantiate(Rock, RockSpawn1.position, RockSpawn1.rotation);
                Instantiate(Rock, RockSpawn4.position, RockSpawn4.rotation);
                break;
            case 6:
                Instantiate(Rock, RockSpawn1.position, RockSpawn1.rotation);
                Instantiate(Rock, RockSpawn2.position, RockSpawn2.rotation);
                break;
            case 7:
                Instantiate(Rock, RockSpawn.position, RockSpawn.rotation);
                Instantiate(Rock, RockSpawn2.position, RockSpawn2.rotation);
                Instantiate(Rock, RockSpawn3.position, RockSpawn3.rotation);
                Instantiate(Rock, RockSpawn4.position, RockSpawn4.rotation);
                break;
            case 8:
                Instantiate(Rock, RockSpawn.position, RockSpawn.rotation);
                Instantiate(Rock, RockSpawn1.position, RockSpawn1.rotation);
                Instantiate(Rock, RockSpawn2.position, RockSpawn2.rotation);
                Instantiate(Rock, RockSpawn4.position, RockSpawn4.rotation);
                break;
            case 9:
                Instantiate(Rock, RockSpawn.position, RockSpawn.rotation);
                Instantiate(Rock, RockSpawn1.position, RockSpawn1.rotation);
                Instantiate(Rock, RockSpawn2.position, RockSpawn2.rotation);
                Instantiate(Rock, RockSpawn3.position, RockSpawn3.rotation);
                Instantiate(Rock, RockSpawn4.position, RockSpawn4.rotation);
                break;
            case 10:
                break;
        }
                      
    }
}
