using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scene1to2()
    {
        SceneManager.LoadScene ("Scene2");
    }
    public void Scene3to2()
    {
        SceneManager.LoadScene ("Scene2");
    }
}
