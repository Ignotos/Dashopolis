﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuSelect : MonoBehaviour {

	public void loadCharacterSelect(){
		SceneManager.LoadScene ("AbilitySelect");
	}
}
