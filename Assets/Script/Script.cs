using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Script : MonoBehaviour
{
   public void StartMenu(){
       SceneManager.LoadScene("MainMenu");
   }
   public void StartGame(){
       SceneManager.LoadScene("GameLevel1");
   }

    public void Exit(){
       Application.Quit();
    }


}
