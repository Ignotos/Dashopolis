using UnityEngine;
using System.Collections;

public class TallGrass : MonoBehaviour {

    // Attributes
    private Rigidbody2D rb;
    public AudioSource audio;
    public GameObject particles;
   /* private bool play;
    private Vector2 lastPos;*/

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
     /*   play = false;
        lastPos = new Vector2(transform.position.x, transform.position.y);*/
	}
	
	// Update is called once per frame
	void Update () {

     /*   if (play && HasNewPos())
            audio.Play();
        else if (play && !HasNewPos())
            audio.Pause();
        else if (!play)
            */

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            audio.Play();
            Instantiate(particles, other.gameObject.transform.position, other.gameObject.transform.rotation);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            audio.Stop();
    }

  /*  Vector2 GetPos()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }

    bool HasNewPos()
    {
        if (Mathf.Approximately(GetPos().x, lastPos.x) && Mathf.Approximately(GetPos().y, lastPos.y))
            return false;
        else
            return true;
    }*/
}
