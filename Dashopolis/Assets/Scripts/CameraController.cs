using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform player1;
    public Transform player2;
    public bool singlePlayer;
    public float zoomScalingFactor; 
    private float distance; // distance between the two players 
    private float deltaDistance; // the change in distance since the last frame 


	// Use this for initialization
	void Start () {
        distance = Vector3.Distance(player1.position, player2.position);
    }

    // Update is called once per frame
    void Update () {
        if (!singlePlayer)
        {
            deltaDistance = Vector3.Distance(player1.position, player2.position) - distance;

            // if delta distance is positive, means that the players are further away from each other since the last frame 
            if (deltaDistance <= 0)
            {
                GetComponent<Camera>().orthographicSize += (deltaDistance * zoomScalingFactor);
            }

            // if negative, they are closer since the last frame
            else
            {
                GetComponent<Camera>().orthographicSize += (deltaDistance * zoomScalingFactor);
            }

            distance = Vector3.Distance(player1.position, player2.position);

            // if player 1 is to the right of player 2, follow player 1
            if (player1.position.x > player2.position.x)
            {
                gameObject.transform.position = new Vector3(player1.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            // otherwise follow player 2
            else
            {
                gameObject.transform.position = new Vector3(player2.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            }

            /*
            if (gameObject.transform.position.x > otherPlayer.gameObject.transform.position.x)
            {
                GetComponent<Camera>().enabled = true;
                otherPlayer.enabled = false;
            }

            else
            {
                GetComponent<Camera>().enabled = true;
                otherPlayer.enabled = false;
            }
            */
        }
        else
        {
            gameObject.transform.position = new Vector3(player1.position.x, player1.position.y, gameObject.transform.position.z);
        }
    }
}
