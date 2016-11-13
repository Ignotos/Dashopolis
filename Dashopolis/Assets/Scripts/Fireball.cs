using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

    public float fireballSpeed;
    public static bool timeFreezeActivated;
    private float lifetime;

    // Use this for initialization
    void Start () {
        timeFreezeActivated = false;
        lifetime = Random.Range(0.5f,2f);
		//Destroy(gameObject,lifetime);
	}
	// Update is called once per frame
	void Update () {
        if (!timeFreezeActivated)
        {
            lifetime -= Time.deltaTime;
            if (lifetime <= 0)
            {
                Destroy(gameObject);
            }
            transform.Translate(Vector2.up * Time.deltaTime * fireballSpeed);
        }
    }
	
	void OnTriggerEnter2D(Collider2D other){
		Destroy(gameObject);
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
