using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    #region Singletone

    public static Game Instance { get { return _instance; } }
    private static Game _instance;

    #endregion

    private ScoreLogick _scoreLogick;

    #region Get/Set

    public ScoreLogick ScoreLogick => _scoreLogick;


    #endregion

    void Awake()
    {
        _instance = this;
        _scoreLogick = new ScoreLogick();

    }

    public void StartGame()
    {
        CanvasManager.Instance.SwitchMenuGroup();
        Spawner.Instance.gameObject.SetActive(true);
        Spawner.Instance.SpawnPlayer();
    }

    public void EndGame()
    {
        Spawner.Instance.gameObject.SetActive(false);

        foreach (Transform obj in Spawner.Instance.PipeLayer.GetComponentInChildren<Transform>())
        {
            Destroy(obj.gameObject);
        }

        _scoreLogick.CheckMaxScore();
        CanvasManager.Instance.SwitchMenuGroup();
    }
    
}
