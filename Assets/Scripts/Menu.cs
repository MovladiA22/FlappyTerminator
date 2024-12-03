using System;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _startButton;

    public event Action PressedStart;

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnStartClick);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnStartClick);
    }

    private void OnStartClick()
    {
        _startButton.gameObject.SetActive(false);
        PressedStart?.Invoke();
    }    
}
