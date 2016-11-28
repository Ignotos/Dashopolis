using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour {

	//Should Be on Enter
	void OnCollisionEnter2D(Collision2D col){
		//if winner show winning message

		Debug.Log ("HERE");
		if (col.gameObject.tag == "Player") {
			PlayerController p = col.gameObject.GetComponent<PlayerController> ();
			if (p.playerNumber == 0) {
				PlayerPrefs.SetInt ("Winner", 1);
			} else
				PlayerPrefs.SetInt ("Winner", 2);
			SceneManager.LoadScene ("EndScene");
		}
	}
}
