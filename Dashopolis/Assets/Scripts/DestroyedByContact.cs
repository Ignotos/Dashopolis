using UnityEngine;
using System.Collections;

public class DestroyedByContact : MonoBehaviour {


    public int Powervalue;
	private PlayerController player;

	
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
            player.ResetPower();
			player.Die();
			}
		}
    }
	
	 void OnCollisionEnter2D(Collision2D other){
		if(other.gameObject.CompareTag("Player")){
			GameObject playerObject = GameObject.Find(other.gameObject.name);
			player = playerObject.GetComponent<PlayerController>();
            player.ResetPower();
			player.Die();	
		}
	 }
}
