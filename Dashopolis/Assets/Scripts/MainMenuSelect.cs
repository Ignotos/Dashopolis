using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuSelect : MonoBehaviour {

	public void loadCharacterSelect(){
		SceneManager.LoadScene ("Cave_no_platform");
	}
}
