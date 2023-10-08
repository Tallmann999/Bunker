using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButton : MonoBehaviour
{
   public void OnSettingMenuButton()
    {
        SceneManager.LoadScene("PauseMenu");
    }
}
