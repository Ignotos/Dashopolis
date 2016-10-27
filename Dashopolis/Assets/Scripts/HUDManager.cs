using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUDManager : MonoBehaviour {

	Slider pOne;
	Slider pTwo;

	Text timeCounter;

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
	//	pOne.value = (int)Time.time;
	//	pTwo.value = (int)Time.time;
		timeCounter.text = string.Format ("{0:0}:{1:00}", Time.time/60f,Time.time);

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
