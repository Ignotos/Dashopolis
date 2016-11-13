using UnityEngine;
using System.Collections;

public class LaserBeam : MonoBehaviour {

    public static bool timeFreezeActivated;

    void Start()
    {
        timeFreezeActivated = false;
    }

    // Update is called once per frame
    void Update () {
        if (!timeFreezeActivated)
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
            transform.Translate(Vector2.down * Time.deltaTime);
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
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
