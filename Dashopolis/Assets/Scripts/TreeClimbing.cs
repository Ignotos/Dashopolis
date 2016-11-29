using UnityEngine;
using System.Collections;

public class TreeClimbing : MonoBehaviour
{

    public PlayerController player1;
    public PlayerController player2;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "Player_0")
            player1.onTree = true;

        if (other.name == "Player_1")
            player2.onTree = true;

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player_0")
            player1.onTree = false;

        if (other.name == "Player_1")
            player2.onTree = false;
    }


}
