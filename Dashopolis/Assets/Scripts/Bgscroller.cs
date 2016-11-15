using UnityEngine;
using System.Collections;

public class Bgscroller : MonoBehaviour {

    public float ScrollSpeed;
    
    // Use this for initialization
    void Start()
    {

       
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(Time.time * ScrollSpeed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
