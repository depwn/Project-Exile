using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
   
    public void OnReloadSceneButton()
    {
        SceneManager.LoadScene("Main Game Scene");
    }
}
