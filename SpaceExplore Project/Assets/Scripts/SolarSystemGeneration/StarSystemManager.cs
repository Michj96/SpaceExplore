using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSystemManager : MonoBehaviour
{
    public StarSystem System;

    public GameObject Star;
    public GameObject Planet;


    void Start()
    {
        System = new StarSystem();
        SpawnSystem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnSystem()
    {
        GameObject starGo = Instantiate(Star) as GameObject;
        float radius = System.star.Radius;
        starGo.transform.Find("Model").localScale = new Vector3(radius, radius, radius);

        var enemyManager = GameObject.Find("Managers").GetComponent<EnemyManager>();
        enemyManager.SpawnEnemies(starGo);

        foreach(Celestial c in System.star.sattelites)
        {
            GameObject satGo = Instantiate(Planet);
            satGo.GetComponent<FloatOriginHandler>().z = c.Orbit.Radius;
            satGo.transform.Find("Model").localScale = new Vector3(c.Radius, c.Radius, c.Radius);

        }
    }
}
