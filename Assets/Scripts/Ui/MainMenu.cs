using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnPlayButton()
    {
        const string Level02 = "Level-02-Bunker";
        SceneManager.LoadScene(Level02);
    }

    public void OnExitButton()
    {
        Application.Quit();
    }
}
