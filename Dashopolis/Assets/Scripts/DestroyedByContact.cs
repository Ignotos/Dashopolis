using UnityEngine;
using System.Collections;

public class DestroyedByContact : MonoBehaviour {


    public int Powervalue;
    private PlayerController Player;

    // Use this for initialization
    void Start ()
    {
        GameObject GameControlerObject = GameObject.FindWithTag("Player");
        if (GameControlerObject != null)
        {
            Player = GameControlerObject.GetComponent<PlayerController>();
        }
        if (Player == null)
        {
            Debug.Log("cannot find GameController script");
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.CompareTag("Player"))
        {
            //Instantiate(playerexplosion, other.transform.position, other.transform.rotation); for later when we have effects
        }

        Player.AddPower(Powervalue);
        //Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
