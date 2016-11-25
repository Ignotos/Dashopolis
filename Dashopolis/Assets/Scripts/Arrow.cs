using UnityEngine;
using System.Collections;

public class Arrow : MonoBehaviour
{

    public float speed;
    public static bool timeFreezeActivated;
   // private float lifetime;

    // Use this for initialization
    void Start()
    {
        timeFreezeActivated = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (!timeFreezeActivated)
        {
            transform.Translate(-Vector2.right * Time.deltaTime * speed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
		Debug.Log("ARROW X");
        Destroy(gameObject);
    }

    public static void ActivateTimeFreeze()
    {
        timeFreezeActivated = true;
    }

    public static void DeactivateTimeFreeze()
    {
        timeFreezeActivated = false;
    }
}
