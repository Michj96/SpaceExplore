using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInput : MonoBehaviour
{
    //public Transform transform;
    public FloatOriginHandler Handler;

    public GameObject Laser;

    private float _throttle;

    Vector3 LookAtPos;
    Vector3 SmoothedLookAtPos;

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

        // Only activate mouse steering, when holding space.
        if (Input.GetButton("Mouse Steering"))
        {
            //Look At the Mouse
            LookAtPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100));
            SmoothedLookAtPos = Vector3.Lerp(SmoothedLookAtPos, LookAtPos, Time.deltaTime / 5);

            // Saving the z, so we can roll and still use mouselook
            var oldZ = transform.rotation.eulerAngles.z;

            // Calculating the rotation
            transform.LookAt(SmoothedLookAtPos);

            // Using the calculated rotation, but keeping the old Z. Z would be 0 otherwise.
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, oldZ);
        }

        // Stop slowly
        if (Input.GetButton("Stop"))
        {
            Throttle = Mathf.Lerp(Throttle, 0, 3 * Time.deltaTime);

            // Making sure we actually stop, instead of having a tiny tiny velocity.
            if (Throttle < 1)
            {
                Throttle = 0;
            }

        }

        // Full speed forward
        if (Input.GetButton("Full Speed"))
        {
            Throttle = Mathf.Lerp(Throttle, 100, 3 * Time.deltaTime);

            // Same as stopping, but opposite.
            if (Throttle > 99)
            {
                Throttle = 100;
            }
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
