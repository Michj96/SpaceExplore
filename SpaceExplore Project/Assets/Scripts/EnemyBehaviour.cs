using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private GameObject star;
    private GameObject player;
    public GameObject Laser;

    FloatOriginHandler _originHandler;
    private float rateOfFirePointer = 0;
    private int shootCycle = 0;

    // Start is called before the first frame update
    void Start()
    {
        _originHandler = GetComponent<FloatOriginHandler>();
        player = GameObject.FindGameObjectWithTag("Player");
        star = GameObject.FindGameObjectWithTag("Star");
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(star.transform);
        //transform.Rotate(new Vector3(0, 90, 0));

        transform.LookAt(player.transform);

        float distance = Vector3.Distance(gameObject.transform.position, player.transform.position);

        if (distance < 100)
        {
            _originHandler.Velocity = ForwardVelocity(0);
        }
        else if (distance > 500)
        {
            _originHandler.Velocity = ForwardVelocity(1000);
        }
        else
        {
            _originHandler.Velocity = ForwardVelocity(100);
        }


        if (distance < 500 && distance > 100)
        {
            if (Time.time > rateOfFirePointer)
            {
                rateOfFirePointer = Time.time + (0.3f);
                SpawnLaser();
            }
        }

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
        foh.Velocity = _originHandler.Velocity + ForwardVelocity(2000);

        Vector3 t = (Quaternion.Euler(transform.rotation.eulerAngles) * Vector3.left * offset);
        foh.WorldLocation = _originHandler.WorldLocation + t;
    }

    private Vector3 ForwardVelocity(float velocity)
    {
        Vector3 forwardVector = Quaternion.Euler(transform.rotation.eulerAngles) * Vector3.forward * velocity;
        return forwardVector;
    }
}
