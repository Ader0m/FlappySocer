using UnityEngine;

public class Ball : MonoBehaviour, IPlayableObj
{
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _force;
    private Rigidbody2D _rb;


    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();    
    }
    
    void Update()
    {
        MovementLogick();
        SpeedController();
    }

    private void SpeedController()
    {
        if (_rb.velocity.y > _maxSpeed)
            _rb.velocity = _rb.velocity.normalized * _maxSpeed;
    }

    private void MovementLogick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rb.velocity = _rb.velocity.normalized;
            _rb.AddForce(new Vector3(0, _force), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Game.Instance.EndGame();
        Destroy(gameObject);
    }
}
