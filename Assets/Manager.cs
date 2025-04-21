using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
   
    void Start()
    {
        
    }

    void Update()
    {
        
    }

   public void Menu()
    {
        SceneManager.LoadScene("UIMenu");
    }
    
    public void Restart()
    {
        SceneManager.LoadScene("world-1");
    }
    
    public void Close()
    {
        Application.Quit();
    }
}
