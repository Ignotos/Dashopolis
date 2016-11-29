using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScene : MonoBehaviour {

	Text winnerTxt;

	// Use this for initialization
	void Start () {
		winnerTxt = transform.parent.GetComponentsInChildren<Text> () [2];

		int winner = PlayerPrefs.GetInt ("Winner");
	
		winnerTxt.text = winner.ToString ();
	}

}
