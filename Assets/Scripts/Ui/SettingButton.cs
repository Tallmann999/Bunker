using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingButton : MonoBehaviour
{
    public void OnMenuButton()
    {
        SceneManager.LoadScene("Level-01-MainMenu");
    }

    public void OnExitButton()
    {
        Application.Quit();
    }

    public void OnResetMenuButton()
    {
        SceneManager.LoadScene("Level-02-Bunker");
    }
}
