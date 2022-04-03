using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleHandler : MonoBehaviour
{
    private float fixedDeltaTime;
    private bool SETAOn = false;

    void Awake()
    {
        // Make a copy of the fixedDeltaTime, it defaults to 0.02f, but it can be changed in the editor
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // If a key is pressed and it's not a timescale key, we set timescale to 1,
        // so you don't flip the ship a million times.
        if (Input.anyKeyDown)
        {
            if (Input.GetButtonDown("Timescale Plus"))
            {
                Time.timeScale += 1;
                //Debug.Log(Time.timeScale);
                // Adjust fixed delta time according to timescale
                // The fixed delta time will now be 0.02 real-time seconds per frame
                //Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
            }
            else if (Input.GetButtonDown("SETA"))
            {
                // Toggle SETA
                SETAOn = !SETAOn;
            }

            else if (Input.GetButtonDown("Timescale Minus") && Time.timeScale > 1)
            {
                Time.timeScale -= 1;
                //Debug.Log(Time.timeScale);
                // Adjust fixed delta time according to timescale
                //Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
            }
            else
            {
                Time.timeScale = 1;
                SETAOn = false;
            }

        }

        if (SETAOn && Time.timeScale < 10)
        {
            if (Time.timeScale > 9.9f)
            {
                Time.timeScale = 10;
            }
            else
            {
                Time.timeScale = Mathf.Lerp(Time.timeScale, 10, 0.1f * Time.deltaTime);
            }
        }



        // Adjust fixed delta time according to timescale. Must be done last.
        Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
    }
}
