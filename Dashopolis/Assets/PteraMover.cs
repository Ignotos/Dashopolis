using UnityEngine;
using System.Collections;

public class PteraMover : MonoBehaviour {

	Rigidbody2D rb;
	int yMin = -400;
	Animator anim;

	public static bool timeFreezeActivated;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		timeFreezeActivated = false;
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!timeFreezeActivated) {
			//transform.Translate (Vector2.left * 5 * Time.deltaTime);
			rb.velocity = Vector2.left * 20;//* Time.deltaTime;
			//Debug.Log(rb.position.x);
			if (rb.position.x < yMin)
				Destroy (this.gameObject);
			anim.speed = 1;

		} else {
			anim.speed = 0;
			rb.velocity = Vector2.zero;
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
