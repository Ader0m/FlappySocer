using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour, IGameWorldObj
{

    void Awake()
    {
        Spawner.Instance.PipesAndLandList.Add(this);
    }


    void Update()
    {
        
    }

    public void Move(float speed)
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Spawner.Instance.PipesAndLandList.Remove(this);
        Destroy(this.gameObject);
    }  
}
