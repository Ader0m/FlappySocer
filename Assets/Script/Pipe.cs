using UnityEngine;

public class Pipe : MonoBehaviour, IGameWorldObj
{
    private bool _haveScore;

    void Awake()
    {
        _haveScore = true;
        Spawner.Instance.PipesAndLandList.Add(this);
    }

    public void Move(float speed)
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        if (_haveScore&& transform.position.x < -6)
        {
            Game.Instance.ScoreLogick.AddScore();
            _haveScore = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Spawner.Instance.PipesAndLandList.Remove(this);
        Destroy(gameObject);
    }  
}
