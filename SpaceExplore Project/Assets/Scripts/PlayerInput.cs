using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    public Transform transform;
    public SectorObjectHandler Handler;

    private float _throttle;
    public float Throttle
    {
        get { return _throttle; }
        private set { _throttle = Mathf.Clamp(value, -100, 100); }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float pitch = Input.GetAxis("Vertical") * 50;
        float rotate = Input.GetAxis("Horizontal") * 50;
        float throttle = Input.GetAxis("Throttle") * 50;

        Throttle += throttle * Time.deltaTime;
        transform.Rotate(Vector3.left * pitch * Time.deltaTime);
        transform.Rotate(Vector3.forward * -rotate * Time.deltaTime);

        Handler.Velocity = ForwardVelocity(Throttle * 3);

        ShipUIController.Throttle = $"{Mathf.Round(Throttle)}%";
    }

    private Vector3 ForwardVelocity(float velocity)
    {
        Vector3 forwardVector = Quaternion.Euler(transform.rotation.eulerAngles) * Vector3.forward * velocity;
        return forwardVector;
    }
}
