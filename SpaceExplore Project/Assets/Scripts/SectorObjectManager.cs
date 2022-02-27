using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectorObjectManager : MonoBehaviour
{
    SectorObject _originObject;
    List<SectorObject> _objectList = new List<SectorObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddObject(SectorObject sectorObject)
    {
        _objectList.Add(sectorObject);
    }

    public void SetOrigin(SectorObject originObject)
    {
        if (_originObject != null)
        {
            Debug.Log("Origin Object was already set. Was overriden (Only one origin object per scene.)");
        }
        _originObject = originObject;
    }

    public Vector3 LocationInScene(SectorObject sectorObject)
    {
        return new Vector3((float)(sectorObject.x - _originObject.x), (float)(sectorObject.y - _originObject.y), (float)(sectorObject.z - _originObject.z));
    }
}
