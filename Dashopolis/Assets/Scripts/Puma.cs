using UnityEngine;
using System.Collections;

public class Puma : MonoBehaviour {

    private Rigidbody2D rb;
    public float Speed;
    public int timer;
    public SpriteRenderer flip;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
        
        

    }


	
	// Update is called once per frame
	void Update () {

        Debug.Log(timer);
        timer--;
        flip.flipX = false;

        rb.velocity = -transform.right * Speed;

        if (timer > 0 && timer < 200)
        {
            rb.velocity = transform.right * Speed;
            flip.flipX = true;



        }
       
        if(timer < 0)
        {
            
            timer=400;

        }


    }
       
}
