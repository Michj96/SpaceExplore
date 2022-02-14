using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject PlayerShip;
    private Transform _pShipTransform;

    public Text ThrottleDisplay;

    public ParticleSystem[] EngineTrails;

    private float _throttle;

    private ObjectLocationController _objectLocationController;

    public float Throttle
    {
        get { return _throttle; }
        private set { _throttle = Mathf.Clamp(value, -100, 100); }
    }

    // Start is called before the first frame update
    void Start()
    {
        _pShipTransform = PlayerShip.GetComponent<Transform>();
        _objectLocationController = GameObject.Find("ObjectLocationController").GetComponent<ObjectLocationController>();
    }

    // Update is called once per frame
    void Update()
    {
        float pitch = Input.GetAxis("Vertical") * 50;
        float rotate = Input.GetAxis("Horizontal") * 50;
        float throttle = Input.GetAxis("Throttle") * 50;

        Throttle += throttle * Time.deltaTime;
        _pShipTransform.Rotate(Vector3.left * pitch * Time.deltaTime);
        _pShipTransform.Rotate(Vector3.forward * -rotate * Time.deltaTime);

        ThrottleDisplay.text = $"{Mathf.Round(Throttle)}%";
        foreach(ParticleSystem ps in EngineTrails)
        {
            ps.startLifetime = Throttle * 0.0035f;
        }

    }

    private void FixedUpdate()
    {
        Vector3 positionUpdate = PositionUpdate(Throttle * 50);
        _objectLocationController.PlayerObject.x += positionUpdate.x * Time.fixedDeltaTime;
        _objectLocationController.PlayerObject.y += positionUpdate.y * Time.fixedDeltaTime;
        _objectLocationController.PlayerObject.z += positionUpdate.z * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided!!");
    }

    private Vector3 PositionUpdate(float speed)
    {
        Vector3 forwardVector = Quaternion.Euler(_pShipTransform.rotation.eulerAngles) * Vector3.forward * speed;
        return forwardVector;
    }
}
