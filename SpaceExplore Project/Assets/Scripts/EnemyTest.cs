using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTest : MonoBehaviour
{
    private FloatOriginHandler _handler;
    private FloatOriginHandler _star;

    // Start is called before the first frame update
    void Start()
    {
        _handler = gameObject.GetComponent<FloatOriginHandler>();

        _star = GameObject.Find("Star").GetComponent<FloatOriginHandler>();

        Vector3double starPos = _star.WorldLocation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
