using UnityEngine;
using System.Collections;

public class FlameProjectile : MonoBehaviour {

	// Use this for initialization
	void Update () {
		transform.Translate(Vector2.down * Time.deltaTime * 10);
	}
}
