using UnityEngine;


public class ScoreLogick
{
    [SerializeField] private int _spawnTimeProgress = 100;
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
        _score++;
        CanvasManager.Instance.SetScore();
        Spawner.Instance.DelaySpawnPipes = Spawner.Instance.DelaySpawnPipes - _spawnTimeProgress * (_score / Game.Instance.DificultyProgress);
        if (_score > _maxScore)
        {
            CanvasManager.Instance.SetMaxScore(_score);
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

