using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDManager : MonoBehaviour {

	Slider pOne;
	Slider pTwo;

	Text timeCounter;

	float seconds;
	int minutes;
	float totalTime;

	// Use this for initialization
	void Start () {
		Slider[] s = transform.parent.GetComponentsInChildren<Slider> ();
		timeCounter = transform.parent.GetComponentsInChildren<Text> ()[1];
		pOne = s [0];
		pTwo = s [1];
		timeCounter.text = "";
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
	}

	public void increasePlayerTwo(int p){
		pTwo.value += p;
	}

	public void resetPlayerOne(){
		
	}

	public void resetPLayerTwo(){
	}
}
