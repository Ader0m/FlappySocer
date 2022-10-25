using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionAdapter : MonoBehaviour
{
    [SerializeField] private GameObject _barrier;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _spawner;

    private void Start()
    {
        Vector3 rightDownPoint;
        _camera = Camera.main;


        rightDownPoint = _camera.ScreenToWorldPoint(new Vector3(_camera.orthographicSize / 2, 0));
        rightDownPoint.x *= -1;
        rightDownPoint.x *= 1.0165f;

        _barrier.transform.localScale = rightDownPoint * 2.2f;
        _spawner.transform.position = rightDownPoint;
    }
}
