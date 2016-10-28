using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float lifetime = Random.Range(0.5f,2f);
		Destroy(gameObject,lifetime);
	}
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.up * Time.deltaTime * 10);	
	}
	
	void OnTriggerEnter2D(Collider2D other){
		Destroy(gameObject);
	}
}
