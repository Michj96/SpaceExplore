using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject Enemy;

    EnemyBehaviour _behaviour;

    FloatOriginHandler _handler;

    GameObject star;

    // Start is called before the first frame update
    void Start()
    {
        star = GameObject.FindGameObjectWithTag("Star");

    }

    // Update is called once per frame
    void Update()
    {
        EnemyBehaviour[] enemy = FindObjectsOfType<EnemyBehaviour>();
        if(enemy == null || enemy.Length == 0)
        {
            SpawnEnemies(star);
        }
    }

    public void SpawnEnemies(GameObject go)
    {
        for (int i = 0; i < 1; i++)
        {
            GameObject enemy = Instantiate(Enemy, go.transform);
            _handler = enemy.GetComponent<FloatOriginHandler>();
            _behaviour = enemy.GetComponent<EnemyBehaviour>();
            _handler.x = 5000;
            _handler.y = 5000;
            _handler.z = 5000;
            //go.transform.z
            enemy.transform.position += new Vector3(Random.Range(0, 1000), Random.Range(0, 1000), Random.Range(0, 1000));
            //_handler.Velocity = new Vector3(0, 100, 0);
        }
    }
}
