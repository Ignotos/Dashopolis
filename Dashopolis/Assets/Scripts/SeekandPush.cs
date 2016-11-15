using UnityEngine;
using System.Collections;

public class SeekandPush : MonoBehaviour
{

    public float mFollowRange;
    public Transform mTarget;
    public Transform mTarget1;
    public float mFollowSpeed;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float distance = new Vector2(transform.position.x - mTarget.position.x, transform.position.y - mTarget.position.y).magnitude;
        float distance2 = new Vector2(transform.position.x - mTarget1.position.x, transform.position.y - mTarget1.position.y).magnitude;


        if (distance < mFollowRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, mTarget.position, mFollowSpeed * Time.deltaTime);


        }
        else if  (distance2 < mFollowRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, mTarget1.position, mFollowSpeed * Time.deltaTime);


        }
    }
}
