using Assets.Sandbox.Michael.Sector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystemController : MonoBehaviour
{
    public GameObject StarPrefab;
    public GameObject PlanetPrefab;

    // Start is called before the first frame update
    void Start()
    {
        SolarSystem ss = SolarSystemFactory.New();

        IntanstiateStar(ss.star);

        Debug.Log($"Star Class: {ss.star.StarClass.ToString()}");

        //foreach (Planet p in ss.Planets)
        //{
        //    GameObject go = Instantiate(Planet, new Vector3(0, 0, p.OriginDist * 100), Quaternion.identity);
        //    go.transform.localScale = new Vector3(p.Radius * 2, p.Radius * 2, p.Radius * 2);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IntanstiateStar(Star star)
    {
        GameObject go = StarPrefab;
        go.GetComponent<Renderer>().sharedMaterial.SetColor("Color_9f985f6a48dd457aa250ebb3307ffc38", ColorTemperature.ToRGB(star.SurfaceTemperature));
        go.transform.localScale = new Vector3(star.Diameter, star.Diameter, star.Diameter);
        Instantiate(go, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
