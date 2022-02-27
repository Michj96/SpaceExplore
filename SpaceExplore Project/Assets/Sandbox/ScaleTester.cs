using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTester : MonoBehaviour
{
    public float distance;

    private Vector3 _scale;

    // Start is called before the first frame update
    void Start()
    {
        _scale = gameObject.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        distance += 100 * Time.deltaTime;
        gameObject.transform.localScale = _scale * scale(distance);
    }

    public float scale(float distance)
    {
        var minDistance = 0f;
        var maxDistance = 100000f;

        var scaleAtMin = 1f;
        var scaleAtMax = 0f;

        return Mathf.Lerp(scaleAtMin, scaleAtMax, Mathf.InverseLerp(minDistance, maxDistance, distance));
        //return new Vector3(scale, scale, scale);

    }
}
