using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserHandler : MonoBehaviour
{
    float lifetime;
    EnemyManager manager;
    GameObject star;

    // Start is called before the first frame update
    void Start()
    {
        lifetime = Time.time;
        manager = GameObject.FindObjectOfType<EnemyManager>();
        star = GameObject.FindGameObjectWithTag("Star");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (Time.time > lifetime + 0.05f)
        {
            if (other.CompareTag("Enemy") && other.transform.parent.parent.parent.parent.gameObject.tag == "Enemy")
            {
                other.transform.parent.parent.parent.parent.gameObject.tag = "Dead";
                Destroy(other.transform.parent.parent.parent.parent.gameObject, 1.0f);
                //EnemyBehaviour[] enemy = FindObjectsOfType<EnemyBehaviour>();
                manager.SpawnEnemies(star);
                //Debug.Log("Enemy hit");
            }
            if (other.CompareTag("Player"))
            {
                Debug.Log("Shot player");
            }
        }
    }
}
