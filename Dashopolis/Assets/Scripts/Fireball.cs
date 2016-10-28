using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

    public float fireballSpeed;

	// Use this for initialization
	void Start () {
		float lifetime = Random.Range(0.5f,2f);
		Destroy(gameObject,lifetime);
	}
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.up * Time.deltaTime * fireballSpeed);	
	}
	
	void OnTriggerEnter2D(Collider2D other){
		Destroy(gameObject);
	}
}
