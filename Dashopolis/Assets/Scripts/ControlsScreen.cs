using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControlsScreen : MonoBehaviour
{

    public void loadGameLevel()
    {
        SceneManager.LoadScene("Cave_no_platform");
    }
}
