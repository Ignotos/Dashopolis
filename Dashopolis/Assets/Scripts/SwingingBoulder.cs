using UnityEngine;
using System.Collections;

public class SwingingBoulder : MonoBehaviour {

    public float angle;
    public float speed;
    private CircleCollider2D circleCollider;
    private Rigidbody2D rigidBody;
    private HingeJoint2D hingeJoint;
    private int range;

	// Use this for initialization
	void Start () {
        circleCollider = gameObject.GetComponent<CircleCollider2D>();
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
        hingeJoint = gameObject.GetComponent<HingeJoint2D>();
        range = 5;
	}
	
	// Update is called once per frame
	void Update () {

        if ((transform.eulerAngles.z <= angle + range) && (transform.eulerAngles.z > angle - range))
        {
            JointMotor2D motor = hingeJoint.motor;
            motor.motorSpeed = speed;
            hingeJoint.motor = motor;
        }
        else if ((transform.eulerAngles.z <= 360 - angle + range) && (transform.eulerAngles.z > 360 - angle - range))
        {
            JointMotor2D motor = hingeJoint.motor;
            motor.motorSpeed = -1 * speed;
            hingeJoint.motor = motor;
        }
	}
}
