using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    #region Singletone

    public static Spawner Instance { get { return _instance; } }
    private static Spawner _instance;

    #endregion

    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _pipes;
    [SerializeField] private GameObject _land;
    [SerializeField] private Transform _pipeLayer;
    [SerializeField] private Transform _landLayer;
    /// <summary>
    /// milliseconds.
    /// ??? ???????? ?????????? ? ???????? ????
    /// </summary>
    [SerializeField] private float _delaySpawnPipes;
    [SerializeField] private float _pipesAndLandSpeed;
    private List<IGameWorldObj> _pipesAndLandList;
    private DateTime _timePipes;
    private float _pipesSpawnX;
    private float _landSpawnX;

    #region Get/Set

    public float DelaySpawnPipes { get { return _delaySpawnPipes; } set { _delaySpawnPipes = value; } }
    public Transform PipeLayer => _pipeLayer;
    public List<IGameWorldObj> PipesAndLandList => _pipesAndLandList;

    #endregion 

    private void Awake()
    {
        _instance = this;
        _pipesAndLandList = new List<IGameWorldObj>();
        gameObject.SetActive(false);     
    }

    void Start()
    {
        _pipesSpawnX = ResolutionAdapter.Instance._pipesSpawnX;
        _landSpawnX = ResolutionAdapter.Instance._landSpawnX;
        _timePipes = DateTime.Now;      
    }

    void Update()
    {
        SpawnPipes();
        MoveObj();       
    }

    private void SpawnPipes()
    {
        if ((DateTime.Now - _timePipes).TotalMilliseconds > _delaySpawnPipes)
        {
            GameObject obj = Instantiate(_pipes, _pipeLayer);
            obj.transform.position = new Vector3(_pipesSpawnX, UnityEngine.Random.Range(1, 7) - 3, 1);
            _timePipes = DateTime.Now;
        }
    }

    private void SpawnLand()
    {
        GameObject obj = Instantiate(_land, _landLayer);
        obj.transform.position = new Vector3(_landSpawnX, obj.transform.position.y, obj.transform.position.z);  
    }    

    private void MoveObj()
    {
        float newPipesAndLandSpeed = _pipesAndLandSpeed + Game.Instance.ScoreLogick.Score / Game.Instance.DificultyProgress;


        foreach (var worldObj in _pipesAndLandList)
        {
            worldObj.Move(newPipesAndLandSpeed);
        }
    }

    public void SpawnPlayer()
    {
        GameObject obj = Instantiate(_player);
        obj.transform.position = new Vector3(-6, 0, 0);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<LandCell>(out _) && gameObject.activeSelf)
            SpawnLand();
    }
}
