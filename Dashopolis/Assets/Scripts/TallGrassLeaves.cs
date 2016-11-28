using UnityEngine;
using System.Collections;

public class TallGrassLeaves : MonoBehaviour {

    // Attributes
    private Rigidbody2D rb;
    private Vector2 oriPosition;
    private Vector2 targetPosition;
    private int state; // 0: stay 1: down 2: up

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        oriPosition = new Vector2(transform.position.x, transform.position.y);
        float rd = Random.Range(0.5f, 1.0f);
        targetPosition = new Vector2(oriPosition.x, oriPosition.y - rd);
        state = 0;
	}
	
	// Update is called once per frame
	void Update () {

        CheckState();

        // DOWN
        if (state == 1)
        {
            Vector2 dir = targetPosition - GetPos();
            transform.Translate(dir * Time.deltaTime);
        }
        // UP
        else if (state == 2)
        {
            Vector2 dir = oriPosition - GetPos();
            transform.Translate(dir * Time.deltaTime);
        }

	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            state = 1;
            GetComponentInChildren<ParticleSystem>().Play();
        }
        else
            state = 0;
    }   

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            state = 2;
        else
            state = 0;
    }

    void CheckState()
    {
        if (state == 1)
        {
            if (Mathf.Approximately(GetPos().y, targetPosition.y))
                state = 0;
        }
        else if (state == 2)
        {
            if (Mathf.Approximately(GetPos().y, oriPosition.y))
                state = 0;
        }
    }

    Vector2 GetPos()
    {
        return new Vector2(transform.position.x, transform.position.y);
    }
}
