using UnityEngine;
using System.Collections;

public class AnimalFactory : MonoBehaviour {

	[SerializeField]
	GameObject pteraPrefab;
	bool pteraAlive;

	public static bool timeFreezeActivated;
	float time;

	// Use this for initialization
	void Start () {
		pteraAlive = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(!timeFreezeActivated){
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
	public static void ActivateTimeFreeze()
	{
		timeFreezeActivated = true;
	}

	public static void DeactivateTimeFreeze()
	{
		timeFreezeActivated = false;
	}
			
}
