using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Menu _menu;

    private void Awake()
    {
        Time.timeScale = 0.0f;
    }

    private void OnEnable()
    {
        _menu.PressedStart += StartPlay;
        _player.Died += Restart;
    }

    private void OnDisable()
    {
        _menu.PressedStart -= StartPlay;
        _player.Died -= Restart;
    }

    private void StartPlay()
    {
        Time.timeScale = 1.0f;
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
