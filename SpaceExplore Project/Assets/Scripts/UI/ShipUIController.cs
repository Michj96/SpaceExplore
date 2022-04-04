using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipUIController : MonoBehaviour
{
    public static string Throttle;
    //public static float TimeScale;

    public Text ThrottleDisplay;
    public Text TADisplay;
    public Image marker;


    GameObject[] enemies;
    Camera mainCam;
    List<GameObject> markers;

    // Start is called before the first frame update
    void Start()
    {
        //mainCam = FindObjectOfType<Camera>();
        //enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //foreach (var enemy in enemies)
        //{
        //    Vector3 screenPoint = mainCam.WorldToScreenPoint(enemy.transform.position);
        //    Debug.Log(Instantiate(marker, screenPoint, gameObject.transform.rotation, gameObject.transform).gameObject);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //foreach (GameObject image in markers)
        //{
        //    Destroy(image);
        //}

        ThrottleDisplay.text = Throttle;
        TADisplay.text = "TA: " + $"{Mathf.Round(Time.timeScale)}";
        //foreach (var enemy in enemies)
        //{
        //    Vector3 screenPoint = mainCam.WorldToScreenPoint(enemy.transform.position);
        //    markers.Add(Instantiate(marker, screenPoint, gameObject.transform.rotation, gameObject.transform).gameObject);
        //}
    }
}
