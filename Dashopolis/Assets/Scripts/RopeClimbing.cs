using UnityEngine;
using System.Collections;

public class RopeClimbing : MonoBehaviour {

    public PlayerController player1;
    public PlayerController player2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player_0")
        {
            player1.onRope = true;
            Debug.Log("Player_0 came into contact with rope.");
        }
        else if (other.name == "Player_1")
        {
            player2.onRope = true;
            Debug.Log("Player_1 came into contact with rope.");
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player_0")
        {
            player1.onRope = false;
            Debug.Log("Player_0 not on rope anymore.");
        }
        else if (other.name == "Player_1")
        {
            player2.onRope = false;
            Debug.Log("Player_1 not on rope anymore.");
        }
    }


}
