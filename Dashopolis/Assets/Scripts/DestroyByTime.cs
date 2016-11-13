using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour {

    public float Lifetime;
    public static bool timeFreezeActivated;

    // Use this for initialization
    void Start()
    {
        timeFreezeActivated = false;
        //Destroy(gameObject, Lifetime);
    }

    void Update()
    {
        if (!timeFreezeActivated)
        {
            Lifetime -= Time.deltaTime;
            if (Lifetime <= 0)
            {
                Destroy(gameObject);
            }
        }
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
