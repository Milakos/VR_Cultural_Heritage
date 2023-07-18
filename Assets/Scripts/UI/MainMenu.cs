using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
    using UnityEditor;
#endif

using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void OnEnable() 
    {
        FindObjectOfType<ButtonActionsController>().yButton += QuitGame;    
    }

/*    private void OnDisable() 
    {
        
        FindObjectOfType<ButtonActionsController>().yButton -= QuitGame; 
    }*/
    public void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
