﻿using UnityEngine;
using System.Collections;

public class Saw : MonoBehaviour {

    public float speed;
  
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(0, 0, speed * Time.deltaTime);
	}
}
