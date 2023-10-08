using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DieImageActivation : MonoBehaviour
{
    [SerializeField] private AudioSource _baseBackgroundSound;
    [SerializeField] private AudioClip _mainSound;
    [SerializeField] private AudioClip _dieScreenSound;
    [SerializeField] private Player _player;
    [SerializeField] private CanvasGroup _dieScreen;
    [SerializeField] private CanvasGroup _restartButton;
    [SerializeField] private CanvasGroup _exitButton;

    private Coroutine _activeCorutine = null;

    public void OnRestartButton()
    {
        SceneManager.LoadScene("Level-02-Bunker");
        Time.timeScale = 1;
    }

    public void OnExitButton()
    {
        Application.Quit();
    }

    private void Start()
    {
        _baseBackgroundSound = GetComponent<AudioSource>();
        _baseBackgroundSound.clip = _mainSound;
        _baseBackgroundSound.Play();
        _dieScreen.alpha = 0;
        _restartButton.alpha = 0;
        _exitButton.alpha = 0;
    }

    private void OnEnable()
    {
        _player.Die += ChangeScreen;
    }

    private void OnDisable()
    {
        _player.Die -= ChangeScreen;
    }

    private void ChangeScreen(bool activation)
    {
        if (_activeCorutine != null)
        {
            StopCoroutine(_activeCorutine);
        }

        _activeCorutine = StartCoroutine(MainScreenChange(activation));
    }

    private IEnumerator MainScreenChange(bool status)
    {

        if (status)
        {
            _baseBackgroundSound.clip = _mainSound;
            _baseBackgroundSound.Stop();
            _baseBackgroundSound.clip = _dieScreenSound;
            _baseBackgroundSound.Play();

            _dieScreen.alpha = 1;
            _restartButton.alpha = 1;
            _exitButton.alpha = 1;
            yield return null;
        }
        else
        {
            _baseBackgroundSound.clip = _mainSound;
            _baseBackgroundSound.Play();
            yield return null;
        }
    }
}
