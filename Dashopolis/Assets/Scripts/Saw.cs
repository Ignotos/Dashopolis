using UnityEngine;
using System.Collections;

public class Saw : MonoBehaviour {

    public float speed;
    public static bool timeFreezeActivated;
    public Vector2 target;
    private Vector2 oriPosition;
  
	// Use this for initialization
	void Start () {
        timeFreezeActivated = false;
        oriPosition = new Vector2(transform.position.x, transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
        if (!timeFreezeActivated)
        {
            transform.Rotate(0, 0, speed * Time.deltaTime);
        }

        Vector2 direction;
        float time = Mathf.Ceil(Time.time);
        if (time % 2 == 0)
        {
             direction = target - getCurrentPosition2D();
             transform.Translate(direction * Time.deltaTime * 5.0f, Space.World);
        }
        else if (time % 2 != 0)
        {
            direction = oriPosition - getCurrentPosition2D();
            transform.Translate(direction * Time.deltaTime * 5.0f, Space.World);
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

    private Vector2 getCurrentPosition2D()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }
}

