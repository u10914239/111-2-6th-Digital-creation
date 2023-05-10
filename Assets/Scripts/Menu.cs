using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject Credit;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void CreditMenuOpen()
    {
        Credit.SetActive(true);
    }
    public void CreditMenuClose()
    {
        Credit.SetActive(false);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Scene1()
    {
        SceneManager.LoadScene("Scene1");
    }
}
