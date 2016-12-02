using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlManager : MonoBehaviour {

	Text p1Ready;
	Text p2Ready;
	Button goBtn;

	bool p1Go;
	bool p2Go;

	AudioSource selection;

	// Use this for initialization
	void Awake () {
		Text[] ts = transform.parent.GetComponentsInChildren<Text> ();
		p1Ready = ts [1];
		p2Ready = ts [2];

		Debug.Log (p1Ready.text);

		goBtn = transform.parent.GetComponentInChildren<Button> ();
		selection = GetComponent<AudioSource> ();

		goBtn.gameObject.SetActive(false);
		p1Ready.gameObject.SetActive (false);
		p2Ready.gameObject.SetActive (false);

		p1Go = false;
		p2Go = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("KB_Jump")) {
			p1Go = true;
			selection.Play ();
			p1Ready.gameObject.SetActive (true);
		}

		if (Input.GetButtonDown ("P1_Jump")) {
			p2Go = true;
			selection.Play ();
			p2Ready.gameObject.SetActive (true);
		}

		if(p1Go && p2Go)
			SceneManager.LoadScene("Cave_no_platform");
        else if (p1Go && PlayerPrefs.GetInt("Mode") == 1)
        {
            SceneManager.LoadScene("Cave_no_platform");
        }
    }
}
