using UnityEngine;
using System.Collections;

public class AnimalFactory : MonoBehaviour {

	[SerializeField]
	GameObject pteraPrefab;
	bool pteraAlive;

	float time;

	// Use this for initialization
	void Start () {
		pteraAlive = false;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.fixedDeltaTime;

		if ((int)time % 9 == 0) {
			if (!pteraAlive) {
				Instantiate (pteraPrefab, pteraPrefab.transform.position, Quaternion.identity);
				pteraAlive = true;
			}
		} else
			pteraAlive = false;
	}
}
