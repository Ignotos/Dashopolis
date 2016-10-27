using UnityEngine;
using System.Collections;

public class LaserBeam : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.down * Time.deltaTime);
	}
	
	void OnTriggerEnter2D(Collider2D other){
		Debug.Log("collision");
		Destroy(gameObject);
	}
}
