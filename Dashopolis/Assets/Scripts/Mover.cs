using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{

    private Rigidbody2D rb;
    public float Speed;
   

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * Speed;

    }
}
        