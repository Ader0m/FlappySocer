using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class ScoreLogick
{
    private static int _maxScore = 0;
    private int _score = 0;

    #region Get/Set

    public int Score => _score;
    public int MaxScore => _maxScore;

    #endregion

    public ScoreLogick()
    {
        _maxScore = PlayerPrefs.GetInt("MaxScore", 0);
    }

    public void AddScore()
    {
        _score += (_score / 25) + 1;
        CanvasManager.Instance.SetScore();
        if (_score > _maxScore)
        {
            CanvasManager.Instance.SetMaxScore();
        }
    }

    internal void Reset()
    {
        _score = 0;
    }

    public void CheckMaxScore()
    {
        if (_score > _maxScore)
        {
            _maxScore = _score;
            SaveMaxScore();
        }
    }

    private void SaveMaxScore()
    {
        PlayerPrefs.SetInt("MaxScore", _maxScore);
    }
}

