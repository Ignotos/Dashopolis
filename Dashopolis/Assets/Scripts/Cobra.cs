using UnityEngine;
using System.Collections;

public class Cobra : MonoBehaviour {

	private Rigidbody2D rb;
    public float Speed;
    public int timer;
    public SpriteRenderer flip;
	public int minTime;
	public int maxTime;
	
	private int initialTimer;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
		initialTimer = timer;
    }


	
	// Update is called once per frame
	void Update () {

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
