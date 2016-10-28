using UnityEngine;
using System.Collections;

public class DestroyedByContact : MonoBehaviour {


    public int Powervalue;
	private PlayerController player;
    // Use this for initialization
    void Start ()
    {
		
		//will not work when both players have same tag
		/*
        GameObject GameControllerObject = GameObject.Find("Player");
		

        if (GameControllerObject != null)
        {
            player = GameControllerObject.GetComponent<PlayerController>();
        }
        if (player == null)
        {
            Debug.Log("cannot find GameController script");
        }
		*/
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
		if (other.gameObject.CompareTag("Player"))
		{
			PlayerController player = other.GetComponentInParent<PlayerController>();
			if(gameObject.CompareTag("PowerUp")){
				player.AddPower(Powervalue);
				Destroy(gameObject);
			}	
			else{
			player.RemovePower(player.GetPower());
			player.Die();
			}
		}
    }
}
