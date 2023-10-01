using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPlayButton()
    {
        SceneManager.LoadScene("Level-02-Bunker");
    }

    public void OnExitButton()
    {
        Application.Quit();
    }
}
