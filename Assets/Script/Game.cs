using UnityEngine;

public class Game : MonoBehaviour
{
    #region Singletone

    public static Game Instance { get { return _instance; } }
    private static Game _instance;

    #endregion

    [SerializeField] public int DificultyProgress = 25;
    /// <summary>
    /// milliseconds.
    /// ??? ???????? ??????????????? ??? ??????? ?????? StartButton
    /// </summary>
    [SerializeField] private float _delaySpawnPipes;
    private ScoreLogick _scoreLogick;

    #region Get/Set

    public ScoreLogick ScoreLogick => _scoreLogick;


    #endregion

    void Awake()
    {
        _instance = this;
        _scoreLogick = new ScoreLogick();
    }

    void Start()
    {
        CanvasManager.Instance.SetScore();
        CanvasManager.Instance.SetMaxScore(ScoreLogick.MaxScore);
    }

    public void StartGame()
    {
        _scoreLogick.Reset();
        CanvasManager.Instance.SwitchMenuGroup(false);
        CanvasManager.Instance.SetScore();
        CanvasManager.Instance.SetMaxScore(ScoreLogick.MaxScore);
        Spawner.Instance.DelaySpawnPipes = _delaySpawnPipes;
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
        CanvasManager.Instance.SwitchMenuGroup(true);
    }
}
