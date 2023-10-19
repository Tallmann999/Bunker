using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class DieImageActivation : MonoBehaviour
{
    [SerializeField] private AudioSource _baseSound;
    [SerializeField] private AudioClip _mainSound;
    [SerializeField] private AudioClip _dieScreenSound;
    [SerializeField] private Player _player;
    [SerializeField] private CanvasGroup _dieScreen;
    [SerializeField] private CanvasGroup _restartButton;
    [SerializeField] private CanvasGroup _exitButton;

    private Coroutine _activeCorutine = null;

    public void OnRestartButton()
    {
        const string Level02 = "Level-02-Bunker";

        SceneManager.LoadScene(Level02);
        Time.timeScale = 1;
    }

    public void OnExitButton()
    {
        Application.Quit();
    }

    private void Start()
    {
        _baseSound = GetComponent<AudioSource>();
        _baseSound.clip = _mainSound;
        _baseSound.Play();
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
            _baseSound.clip = _mainSound;
            _baseSound.Stop();
            _baseSound.clip = _dieScreenSound;
            _baseSound.Play();

            _dieScreen.alpha = 1;
            _restartButton.alpha = 1;
            _exitButton.alpha = 1;
            yield return null;
        }
        else
        {
            _baseSound.clip = _mainSound;
            _baseSound.Play();
            yield return null;
        }
    }
}
