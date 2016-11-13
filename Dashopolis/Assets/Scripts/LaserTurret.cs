using UnityEngine;
using System.Collections;

public class LaserTurret : MonoBehaviour {
	LineRenderer lineRenderer;
	public Transform target;
	public Transform canon;
	float distance;
    public static bool timeFreezeActivated;

	// Use this for initialization
	void Start () {
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.enabled = true;
		lineRenderer.useWorldSpace =  true;
        timeFreezeActivated = false;
		
				if(lineRenderer == null){
			Debug.Log("LINE RENDERER IS NULL");
		}
		
		distance = Vector3.Distance(target.position,canon.position);
	}
	
	// Update is called once per frame
	void Update () {
        if (!timeFreezeActivated)
        {
            RaycastHit2D hit = Physics2D.Raycast(canon.position, -canon.up);
            target.position = hit.point;
            lineRenderer.SetPosition(0, canon.position);
            lineRenderer.SetPosition(1, target.position);

            int random = Random.Range(0, 40);

            if (random == 0)
            {
                lineRenderer.enabled = true;
            }
            else
            {
                lineRenderer.enabled = false;
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
