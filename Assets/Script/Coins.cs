using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour
{
    public Text tscore;
    public AudioSource audio;
	
    void Start()
    {
        audio = GetComponent<AudioSource> ();
        GameObject scoreText = GameObject.Find("Score");
        tscore = scoreText.GetComponent<Text>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            int iscore = int.Parse(tscore.text) + 1 ;
            tscore.text = iscore.ToString();
            audio.Play();
            this.GetComponent<Renderer>().enabled = false;
            StartCoroutine(BeforeDestroyed());
        }
    }

  IEnumerator BeforeDestroyed()
    {
        yield return new WaitForSeconds(1);
        Destroy(this.gameObject);
    }

}
