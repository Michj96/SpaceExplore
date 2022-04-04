using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    UnityEngine.UI.Button btn;
    // Start is called before the first frame update
    void Start()
    {
        //btn = GetComponent<UnityEngine.UI.Button>();
    }

    // Update is called once per frame
    void Update()
    {
        //btn.onClick.AddListener(LoadGame);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
        SceneManager.LoadScene(2, LoadSceneMode.Additive);
    }
}
