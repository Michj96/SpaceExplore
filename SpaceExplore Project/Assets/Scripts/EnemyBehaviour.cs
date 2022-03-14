using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject star;

    FloatOriginHandler _originHandler;

    // Start is called before the first frame update
    void Start()
    {
        _originHandler = GetComponent<FloatOriginHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(star.transform);
        transform.Rotate(new Vector3(0, 90, 0));

        _originHandler.Velocity = ForwardVelocity(100);
    }

    private Vector3 ForwardVelocity(float velocity)
    {
        Vector3 forwardVector = Quaternion.Euler(transform.rotation.eulerAngles) * Vector3.forward * velocity;
        return forwardVector;
    }
}
