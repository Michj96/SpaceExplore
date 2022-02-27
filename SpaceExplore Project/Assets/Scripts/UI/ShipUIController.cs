using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipUIController : MonoBehaviour
{
    public static string Throttle;

    public Text ThrottleDisplay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ThrottleDisplay.text = Throttle;
    }
}
