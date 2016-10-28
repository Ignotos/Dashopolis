using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

    public float Lifetime;
    // Use this for initialization
    void Start()
    {

        Destroy(gameObject, Lifetime);

    }
}
