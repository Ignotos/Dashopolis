using UnityEngine;
using System.Collections;

public class LaserBeam : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.down * Time.deltaTime);
	}
}
