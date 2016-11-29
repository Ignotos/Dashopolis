using UnityEngine;
using System.Collections;

public class Banana : MonoBehaviour {

    public static bool timeFreezeActivated;

    void Start()
    {
        timeFreezeActivated = false;
    }

	void OnCollisionEnter2D(Collision2D other){
        if (!timeFreezeActivated)
        {
            //GetComponent<Rigidbody2D>().isKinematic = false;
            if (other.gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
            }
        }
        else
        {
            
            //GetComponent<Rigidbody2D>().isKinematic = true;
            //GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
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
