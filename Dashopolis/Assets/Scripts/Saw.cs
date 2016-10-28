using UnityEngine;
using System.Collections;

public class Saw : MonoBehaviour {

    public float speed;
  
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, speed * Time.deltaTime);
	}

    void OnTriggerEnter2D(Collider2D other)
    {

          if (other.gameObject.CompareTag("Player"))
          {
              //Instantiate(playerexplosion, other.transform.position, other.transform.rotation); for later when we have effects
              PlayerController player = other.GetComponentInParent<PlayerController>();
              player.RemovePower(player.GetPower());
              player.Die();
          }

    }
}
