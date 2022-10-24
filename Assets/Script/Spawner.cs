using System;
using System.Collections;
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
    /// milliseconds
    /// </summary>
    [SerializeField] private float _delaySpawnPipes;
    /// <summary>
    /// milliseconds
    /// </summary>
    [SerializeField] private float _delaySpawnLand;
    [SerializeField] private float _pipesAndLandSpeed;
    private List<IGameWorldObj> _pipesAndLandList;
    private DateTime _timePipes;
    private DateTime _timeLand;

    #region Get/Set

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
        _timePipes = DateTime.Now;
        _timeLand = DateTime.Now;
    }

    void Update()
    {
        SpawnPipes();
        SpawnLand();
        MoveObj();
    }

    private void SpawnPipes()
    {
        if ((DateTime.Now - _timePipes).TotalMilliseconds > _delaySpawnPipes)
        {
            GameObject obj = Instantiate(_pipes, _pipeLayer);
            obj.transform.position = new Vector3(transform.position.x, UnityEngine.Random.Range(0, 7) - 3, 1);
            _timePipes = DateTime.Now;
        }
    }

    private void SpawnLand()
    {
        if ((DateTime.Now - _timeLand).TotalMilliseconds > _delaySpawnLand)
        {
            GameObject obj = Instantiate(_land, _landLayer);
            obj.transform.position = new Vector3(obj.transform.position.x + 1.45f, obj.transform.position.y, obj.transform.position.z);
            _timeLand = DateTime.Now;
        }
    }    

    private void MoveObj()
    {
        foreach (var worldObj in _pipesAndLandList)
        {
            worldObj.Move(_pipesAndLandSpeed);
        }
    }

    public void SpawnPlayer()
    {
        GameObject obj = Instantiate(_player);
        obj.transform.position = new Vector3(-6, 0, 0);
    }
}
