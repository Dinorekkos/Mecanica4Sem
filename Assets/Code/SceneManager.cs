using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{

    public string sceneToLoad;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChargeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
    }
}
