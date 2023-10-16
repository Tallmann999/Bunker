using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingButton : MonoBehaviour
{
    public void OnMenuButton()
    {
        const string MainMenu = "Level-01-MainMenu";

        SceneManager.LoadScene(MainMenu);
    }

    public void OnExitButton()
    {
        Application.Quit();
    }

    public void OnResetMenuButton()
    {
        const string Level02 = "Level-02-Bunker";

        SceneManager.LoadScene(Level02);
    }
}
