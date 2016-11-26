using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AbilitySelector : MonoBehaviour {

	Sprite[] sprites;

	[SerializeField]
	Sprite time;

	[SerializeField]
	Sprite flight;

	[SerializeField]
	Sprite speed;

	private SpriteRenderer pOne;
	private SpriteRenderer pTwo;

	int player1Ability;
	int player2Ability;

	string playerPrefix;

	private int indexOne;
	private int indexTwo;

	AudioSource selector;
	AudioSource selection;

	private Color pOneCol;
	private Color pTwoCol;

	private float timeInput;


	// Use this for initialization
	void Start () {
		sprites = new Sprite[]{speed, flight, time};
		pOne = GetComponentsInChildren<SpriteRenderer> ()[0];
		pTwo = GetComponentsInChildren<SpriteRenderer> ()[1];

		indexOne = 0;
		indexTwo = 1;

		pOne.sprite = sprites [indexOne];
		pTwo.sprite = sprites [indexTwo];

		player1Ability = -1;
		player2Ability = -1;

		timeInput = 0;

		selector = GetComponents<AudioSource> ()[0];
		selection = GetComponents<AudioSource> ()[1];

	}
	
	// Update is called once per frame
	void Update () {

		timeInput += Time.deltaTime;
		if (Input.GetButtonDown ("KB_Horizontal") && Input.GetAxisRaw ("KB_Horizontal") >0 && player1Ability == -1) {
			indexOne += 1;
			if (indexOne >= sprites.Length)
				indexOne = 0;
			
			pOne.sprite = sprites [indexOne];
			selector.Play ();
		}

		if (Input.GetButtonDown ("KB_Horizontal") && Input.GetAxisRaw ("KB_Horizontal") <0 && player1Ability == -1) {
			indexOne += -1;
			if (indexOne < 0)
				indexOne = sprites.Length-1;
			pOne.sprite = sprites [indexOne];
			selector.Play ();
		}

		if (Input.GetButtonDown ("KB_Jump")) {
			pOneCol = pOne.material.color;
			pOne.material.color = Color.gray;
			player1Ability = indexOne + 1;
			selection.Play ();
		}

		if (timeInput > 0.3f && Input.GetAxisRaw ("P1_Horizontal") >0 && player2Ability == -1) {
			indexTwo += 1;
			if (indexTwo >= sprites.Length)
				indexTwo = 0;

			pTwo.sprite = sprites [indexTwo];
			timeInput = 0;
			selector.Play ();
		}

		if (timeInput > 0.3f && Input.GetAxisRaw ("P1_Horizontal") <0 && player2Ability == -1) {
			indexTwo += -1;
			if (indexTwo < 0)
				indexTwo = sprites.Length-1;
			pTwo.sprite = sprites [indexTwo];
			timeInput = 0;
			selector.Play ();
		}

		if (Input.GetButtonDown ("P1_Jump")) {
			pTwoCol = pTwo.material.color;
			pTwo.material.color = Color.gray;
			player2Ability = indexTwo + 1;
			timeInput = 0;
			selection.Play ();
		}

		if(player1Ability != -1 && player2Ability != -1){
			PlayerPrefs.SetInt ("P1 Ability", player1Ability);
			PlayerPrefs.SetInt ("P2 Ability", player2Ability);
			SceneManager.LoadScene ("Cave_no_platform");
		}


	}
}
