using UnityEngine;
using System.Collections;

public class Saw : MonoBehaviour {

    public float speed;
    public static bool timeFreezeActivated;
  
	// Use this for initialization
	void Start () {
        timeFreezeActivated = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!timeFreezeActivated)
        {
            transform.Rotate(0, 0, speed * Time.deltaTime);
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
