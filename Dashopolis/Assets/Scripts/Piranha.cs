using UnityEngine;
using System.Collections;

public class Piranha : MonoBehaviour {

    // Attributes
    public float speed;
    private float height;
    public float minHeight;
    public float maxHeight;
    private float width;
    private Vector2 end;
    private Vector2 start;
    private Vector2 dir;
    private bool reachTop;
    public float delay;
    private float nextStart;
	public static bool timeFreezeActivated;
 //   private AudioSource audio;

	void Start () { 
		timeFreezeActivated = false;
        start = new Vector2(transform.position.x, transform.position.y);
        height = Random.Range(minHeight, maxHeight);
        end = new Vector2(start.x, height);
        reachTop = false;
        nextStart = Time.time + delay;
	}
	
	void Update () {
		if (!timeFreezeActivated)
        {
            GetComponentInChildren<Animator>().enabled = true;
			// REACH TOP
			if (GetPos().y >= height - 0.5f && !reachTop)
				reachTop = true;

			// TOUCH WATER
			if (GetPos().y <= start.y + 0.5f && reachTop)
			{
				// Particle effect + audio
				GetComponentInChildren<ParticleSystem>().Play();
				GetComponent<AudioSource>().Play();

				// Reset everything
				nextStart = Time.time + delay;
				reachTop = false;
				height = Random.Range(minHeight, maxHeight);
				end = new Vector2(start.x, height);
			}

			if (Time.time >= nextStart)
			{
				// GO UP
				if (!reachTop && GetPos().y < height)
				{
					transform.localScale = new Vector3(1f, 1f, 1f);
					dir = end - GetPos();
					transform.Translate(dir * speed * Time.deltaTime, Space.World);
				}
				// GO DOWN
				else if (reachTop && GetPos().y <= height)
				{
					transform.localScale = new Vector3(-1f, 1f, 1f);
					dir = start - GetPos();
					transform.Translate(dir * speed * 2 * Time.deltaTime, Space.World);
				}
			}
		}
        else
        {
            GetComponentInChildren<Animator>().enabled = false;
        }

    }

    // RETURN THE CURRENT POSITION IN VECTOR2
    Vector2 GetPos()
    {
        return new Vector2(transform.position.x, transform.position.y);
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
