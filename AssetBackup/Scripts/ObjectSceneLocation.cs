using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSceneLocation : MonoBehaviour
{
    private ObjectLocationController _objectLocationController;
    public float DiameterInMeter;
    public float ScaleDivider;

    private float _TrueDiameter;

    // Start is called before the first frame update
    void Start()
    {
        _TrueDiameter = DiameterInMeter / ScaleDivider;
        _objectLocationController = GameObject.Find("ObjectLocationController").GetComponent<ObjectLocationController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float ActiveAreaRadius = 20000;

        Vector3double thisObject = new Vector3double(
                _objectLocationController.LocationObjects[0].x,
                _objectLocationController.LocationObjects[0].y,
                _objectLocationController.LocationObjects[0].z
            );
        Vector3double playerObject = new Vector3double(
                _objectLocationController.PlayerObject.x,
                _objectLocationController.PlayerObject.y,
                _objectLocationController.PlayerObject.z
            );

        double distance = Vector3double.Distance(thisObject, playerObject);

        Vector3 scenePosition;

        if (distance < ActiveAreaRadius + (DiameterInMeter / 2))
        {
            float x = (float)(_objectLocationController.LocationObjects[0].x - _objectLocationController.PlayerObject.x);
            float y = (float)(_objectLocationController.LocationObjects[0].y - _objectLocationController.PlayerObject.y);
            float z = (float)(_objectLocationController.LocationObjects[0].z - _objectLocationController.PlayerObject.z);

            scenePosition = new Vector3(x, y, z);
        }
        else
        {
            float scaleCalc = _TrueDiameter * (ActiveAreaRadius * Mathf.Pow((float)distance - (DiameterInMeter / 2), -1f));

            Vector3double calcPosition = ObjectLocationController.PointAtDistance(playerObject, thisObject, ActiveAreaRadius + (DiameterInMeter / 2));

            float x = (float)(_objectLocationController.PlayerObject.x - calcPosition.x);
            float y = (float)(_objectLocationController.PlayerObject.y - calcPosition.y);
            float z = (float)(_objectLocationController.PlayerObject.z - calcPosition.z);
            
            scenePosition = new Vector3(x, y, z);

            if (scaleCalc < 0.0001)
            {
                gameObject.transform.localScale = new Vector3(0, 0, 0);
            }
            else
            {
                gameObject.transform.localScale = new Vector3(scaleCalc, scaleCalc, scaleCalc);
            }
            
        }

        //double distance = Vector3double.Distance(thisObject, playerObject);
        //Debug.Log(distance);


        gameObject.transform.position = scenePosition;
    }

    
}
