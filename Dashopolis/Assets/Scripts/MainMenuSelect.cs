using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuSelect : MonoBehaviour {

	public void loadCharacterSelect(){
        PlayerPrefs.SetInt("Mode", 2);
        SceneManager.LoadScene ("AbilitySelect");
	}

    public void loadSolo()
    {
        PlayerPrefs.SetInt("Mode", 1);
        SceneManager.LoadScene("AbilitySelect");
    }
}
