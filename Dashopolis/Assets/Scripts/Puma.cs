using UnityEngine;
using System.Collections;

public class Puma : MonoBehaviour {

    private Rigidbody2D rb;
    public float Speed;
    public int timer;
    public SpriteRenderer flip;
	public int timerReset;
	public static bool timeFreezeActivated;
    // Use this for initialization
    void Start () {
		timeFreezeActivated = false;
        rb = GetComponent<Rigidbody2D>();
    }


	
	// Update is called once per frame
	void Update () {
		if (timeFreezeActivated){
			rb.velocity = Vector2.zero;
            GetComponent<Animator>().enabled = false;
		}
		else{
            GetComponent<Animator>().enabled = true;
            //Debug.Log(timer);
            timer--;
			flip.flipX = false;

			rb.velocity = -transform.right * Speed;

			if (timer > 0 && timer < 150)
			{
				rb.velocity = transform.right * Speed;
				flip.flipX = true;



			}
		   
			if(timer < 0)
			{
				
				timer=timerReset;

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
