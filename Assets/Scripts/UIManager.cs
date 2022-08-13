using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Slider _lengtRoad;
    [SerializeField] private RectTransform _panel;
    [SerializeField] private Button _restart;
    [SerializeField] private Button _exit;
    [SerializeField] private Ease _ease;
    [SerializeField] private ParticleSystem _confetti;
    private void Awake()
    {
        _restart.onClick.AddListener(() => RestartGame());
        _exit.onClick.AddListener(() => ExitGame());
        _lengtRoad.onValueChanged.AddListener(delegate { Finish(); });
    }

    private void Finish()
    {
        if (_lengtRoad.value == _lengtRoad.maxValue)
        {
            _panel.DOAnchorPos(new Vector2(0f, 0f), 1f).SetEase(_ease);
            _confetti.Play();
        }
    }
    private void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
    private void ExitGame()
    {
        Application.Quit();
    }
}
