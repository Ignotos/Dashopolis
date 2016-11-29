using UnityEngine;
using System.Collections;

public class Cobra : MonoBehaviour {

	private Rigidbody2D rb;
    public float Speed;
    public int timer;
    public SpriteRenderer flip;
	public int minTime;
	public int maxTime;
	public static bool timeFreezeActivated;
	
	private int initialTimer;
    // Use this for initialization
    void Start () {
		timeFreezeActivated = false;
        rb = GetComponent<Rigidbody2D>();
		initialTimer = timer;
    }


	
	// Update is called once per frame
	void Update () {
		if (timeFreezeActivated){
			rb.velocity = Vector2.zero;
		}
		else{	
			//Debug.Log(timer);
			timer--;
			flip.flipX = true;

			rb.velocity = -transform.right * Speed;

			if (timer > minTime && timer < maxTime)
			{
				rb.velocity = transform.right * Speed;
				flip.flipX = false;
			}
		   
			if(timer < 0)
			{       
				timer = initialTimer;
			}
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
