using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject Enemy;

    EnemyBehaviour _behaviour;

    FloatOriginHandler _handler;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemies(GameObject go)
    {
        GameObject enemy = Instantiate(Enemy);
        _handler = enemy.GetComponent<FloatOriginHandler>();
        _behaviour = enemy.GetComponent<EnemyBehaviour>();
        //go.transform.z
        _handler.x = 0;
        _handler.y = 0;
        _handler.z = 0;
        _handler.Velocity = new Vector3(0, 100, 0);
        _behaviour.star = go;
    }
}
