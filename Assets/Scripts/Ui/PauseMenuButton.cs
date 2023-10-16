using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButton : MonoBehaviour
{
    public void OnSettingMenuButton()
    {
        const string PauseMenu = "PauseMenu";

        SceneManager.LoadScene(PauseMenu);
    }
}
