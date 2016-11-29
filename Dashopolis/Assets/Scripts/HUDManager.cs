using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDManager : MonoBehaviour {

	Slider pOne;
	Slider pTwo;

	Text timeCounter;
	Text countdownText;

	float seconds;
	int minutes;
	float totalTime;

	ParticleSystem p1;
	ParticleSystem p2;

	AudioSource abf; 
	AudioSource cs;

	bool p1Active;
	bool p2Active;

	bool loopDone;

	IEnumerator startGame;
	int count;
	int countdownTime;

	// Use this for initialization
	void Awake () {
		Slider[] s = transform.parent.GetComponentsInChildren<Slider> ();
		timeCounter = transform.parent.GetComponentsInChildren<Text> ()[1];
		countdownText = transform.parent.GetComponentsInChildren<Text> ()[2];

		pOne = s [0];
		pTwo = s [1];
        Debug.Log("START UI VALUE: " + pOne.value);
		timeCounter.text = "";

		ParticleSystem[] ps = GameObject.Find ("HUDParticle").GetComponentsInChildren<ParticleSystem> ();

		p1 = ps [0];
		p2 = ps [1];

		p1.Stop ();
		p2.Stop ();

		abf = GetComponents<AudioSource> ()[0];
		cs = GetComponents<AudioSource> ()[1];
		p1Active = false;
		p2Active = false;

		Time.timeScale = 0;
		count = 3;
		countdownText.text = "";

		startGame = go ();

		loopDone = false;
	}

	void Start(){
		StartCoroutine (startGame);
	}

	IEnumerator go(){
		yield return new WaitForSecondsRealtime (1);
		countdownTime = (int)Time.unscaledTime;
		countdownText.text = count.ToString ();
		string num = count.ToString ();
		cs.Play ();

		while (!loopDone) {
			if (countdownTime != (int)Time.unscaledTime) {
				countdownTime = (int)Time.unscaledTime;
				count--;
				cs.Play ();
				num = count.ToString ();
				Debug.Log ("Time 1: " + (int)Time.unscaledTime);

				if (count == 0) {
					countdownText.text = "GO!";
					count--;
					cs.Play ();
					num = "GO!";
					Debug.Log("Time 2: " + (int)Time.unscaledTime);
				}
				else if (count < -1) {
					num = "";
					Time.timeScale = 1;
					Debug.Log("Time 3: " + (int)Time.unscaledTime);
					StopCoroutine (startGame);
					count--;
					loopDone = true;
				}
			}
			countdownText.text = num;
			yield return null;
		}
		StopCoroutine (startGame);

	}
		

	// Update is called once per frame
	void Update () {

		totalTime += Time.deltaTime;

		minutes = (int)(totalTime / 60);

		seconds = (int)(totalTime % 60);

		timeCounter.text = string.Format ("{0:0}:{1:00}", minutes, seconds);

	}

	public void increasePlayerOne(int p){
		pOne.value += p;

		if ((int)pOne.value == pOne.maxValue && !p1Active) {
			p1.Play ();
			abf.Play ();
			p1Active = true;
		}
	}

	public void increasePlayerTwo(int p){
		pTwo.value += p;

		if ((int)pTwo.value == pTwo.maxValue && !p2Active) {
			p2.Play ();
			abf.Play ();
			p2Active = true;
		}
	}

	public void resetPlayerOne(){
        pOne.value = 0;
		p1.Stop ();
		p1Active = false;
	}

	public void resetPlayerTwo(){
        pTwo.value = 0;
		p2.Stop ();
		p2Active = false;
	}

    public void decreasePlayerOne(int p)
    {
        if (pOne.value > 0)
            pOne.value -= p;
    }

    public void decreasePlayerTwo(int p)
    {
        if(pTwo.value > 0)
            pTwo.value -= p;
    }
}
