using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatOriginHandler : MonoBehaviour
{
    public bool IsOrigin = false;

    public double x;
    public double y;
    public double z;

    public Vector3double WorldLocation {
        get
        {
            return new Vector3double(_object.x, _object.y, _object.z);
        }
        set
        {
            x = value.x;
            y = value.y;
            z = value.z;
            _object?.UpdateByLocation (value);
        }
    }
    public Vector3double SceneLocation { get { throw new NotImplementedException(); } }

    public Vector3 Velocity;

    public float LifeTime = 0;

    private FloatOriginManager _manager;

    private FloatOriginObject _object;

    // Start is called before the first frame update
    void Start()
    {
        _manager = GameObject.Find("FloatOriginSceneManager").GetComponent<FloatOriginManager>();
        _object = new FloatOriginObject(x, y, z);

        if (IsOrigin)
        {
            _manager.SetOrigin(_object);
        }
        else
        {
            _manager.AddObject(_object);
            if (LifeTime > 0)
            {
                StartCoroutine(DestroyAfterTime(LifeTime));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsOrigin)
        {
            gameObject.transform.position = _manager.LocationInScene(_object);
            gameObject.transform.localScale = _manager.ScaleInSceneMultiplier(_object);
        }
        
        if (Velocity != null)
        {
            _object.UpdateByVelocity(Velocity * Time.deltaTime);
        }
    }

    IEnumerator DestroyAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        _manager.RemoveObject(_object);
        Destroy(gameObject);
    }
}
