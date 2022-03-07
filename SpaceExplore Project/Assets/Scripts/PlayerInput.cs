using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    public Transform transform;
    public FloatOriginHandler Handler;

    public GameObject Laser;

    private float _throttle;
    public float Throttle
    {
        get { return _throttle; }
        private set { _throttle = Mathf.Clamp(value, -100, 100); }
    }

    private float rateOfFirePointer;
    private int shootCycle = 0;

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

        if (Input.GetButton("Fire1") && Time.time > rateOfFirePointer)
        {
            rateOfFirePointer = Time.time + (0.1f);
            SpawnLaser();
        }

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

    private void SpawnLaser()
    {
        float offset = 0;
        if (shootCycle == 0)
        {
            offset = 2.843f;
            shootCycle = 1;
        }
        else
        {
            offset = -2.843f;
            shootCycle = 0;
        }

        GameObject laser = Instantiate(Laser) as GameObject;
        laser.transform.localRotation = transform.rotation;
        FloatOriginHandler foh = laser.GetComponent<FloatOriginHandler>();
        foh.Velocity = Handler.Velocity + ForwardVelocity(2000);
        
        Vector3 t = (Quaternion.Euler(transform.rotation.eulerAngles) * Vector3.left * offset);
        foh.WorldLocation = Handler.WorldLocation + t;
    }
}
