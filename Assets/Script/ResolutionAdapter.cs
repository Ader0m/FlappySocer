using UnityEngine;

public class ResolutionAdapter : MonoBehaviour
{
    #region Singletone

    public static ResolutionAdapter Instance { get { return _instance; } }
    private static ResolutionAdapter _instance;

    #endregion

    [SerializeField] private GameObject _barrier;
    [SerializeField] private Camera _camera;
    [SerializeField] private GameObject _spawner;
    public float _pipesSpawnX;
    public float _landSpawnX;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        Vector3 rightDownPoint;
        _camera = Camera.main;


        rightDownPoint = _camera.ScreenToWorldPoint(new Vector3(_camera.orthographicSize / 2, 0));
        rightDownPoint.x *= -1;
        rightDownPoint.x *= 1.0165f; // ��������� ��������, ����� ���� ����� ����� �� �����

        _barrier.transform.localScale = rightDownPoint * 2.2f; // ��������� ������� ������� � ������� ������
        _spawner.transform.position = rightDownPoint;

        _pipesSpawnX = Spawner.Instance.transform.position.x;
        _landSpawnX = _pipesSpawnX + 2.45f; // Sprite Size / 2
        _pipesSpawnX *= 1.111f; // ��������� ������� ���� ����� � ������ ������ �����
    }
}
