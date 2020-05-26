using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal_Goal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            // player.enabled = false;
            StartCoroutine(LoadNewStage());
        }
    }

  IEnumerator LoadNewStage()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("NewStage");
    }


}
