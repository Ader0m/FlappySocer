using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    #region Singletone

    public static CanvasManager Instance { get { return _instance; } }
    private static CanvasManager _instance;

    #endregion

    [SerializeField] private Button _startButton;
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _maxScoreText;
    [SerializeField] private Transform _menuGroup;

    void Awake()
    {
        _instance = this;
    }

    public void StartGame()
    {
        Game.Instance.StartGame();
    }

    public void SetScore()
    {
        _scoreText.text = "Score: " + Game.Instance.ScoreLogick.Score.ToString();
    }

    public void SetMaxScore()
    {
        _maxScoreText.text = "Max score: " + Game.Instance.ScoreLogick.MaxScore.ToString();
    }

    public void SwitchMenuGroup()
    {
        _menuGroup.gameObject.SetActive(!_menuGroup.gameObject.activeSelf);
    }
}
