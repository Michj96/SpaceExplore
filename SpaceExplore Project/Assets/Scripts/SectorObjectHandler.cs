using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorObjectHandler : MonoBehaviour
{
    public bool IsOrigin = false;

    public double x;
    public double y;
    public double z;

    public Vector3 Velocity;

    private SectorObjectManager _manager;

    private SectorObject _SectorObject;

    // Start is called before the first frame update
    void Start()
    {
        _manager = GameObject.Find("SectorObjectManager").GetComponent<SectorObjectManager>();
        _SectorObject = new SectorObject(x, y, z);

        if (IsOrigin)
        {
            _manager.SetOrigin(_SectorObject);
        }
        else
        {
            _manager.AddObject(_SectorObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = _manager.LocationInScene(_SectorObject);
        if (Velocity != null)
        {
            _SectorObject.UpdateByVelocity(Velocity * Time.deltaTime);
        }
    }
}
