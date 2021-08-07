using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 

public class StartMenu : MonoBehaviour
{
    public GameObject Panel; 
    public void Setup()
    {
        gameObject.SetActive(true);

    }
    public void BeginPlay()
    {
        SceneManager.LoadScene("Level0");
    }

    public void OpenHelpMenu()
    {
        if(Panel != null)
        {
            Panel.SetActive(true); 
        }
    }

    public void CloseHelpMenu()
    {
        if(Panel != null)
        {
            Panel.SetActive(false); 
        }
    }
}
