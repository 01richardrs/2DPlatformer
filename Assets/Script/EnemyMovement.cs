using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 0.1f;
    public float x1Bound= 0f;
    public float x2Bound = 1f;
    public bool right = true;
    float scalef = 1.0f;
    public Text tscore;
     public AudioSource audio;

void Start()
{
    audio = GetComponent<AudioSource> ();
    GameObject scoreText = GameObject.Find("Score");
    tscore = scoreText.GetComponent<Text>();
}
    void Update()
    {
        if(transform.position.x< x2Bound && right)
        {
            transform.Translate(Vector3.right * Time.deltaTime);
        }else if(transform.position.x >= x2Bound)
        {
            right = false;
            transform.localScale = new Vector2(-scalef,scalef);
        }

        if(transform.position.x > x1Bound && !right)
        {
            transform.Translate(Vector3.left * Time.deltaTime);
        }else if(transform.position.x <= x1Bound)
        {
            right = true;
            transform.localScale = new Vector2(scalef,scalef);
        }

    }

 private void OnTriggerEnter2D(Collider2D other) {
            if(other.tag == "Laser")
        {
            audio.Play();
            int iscore = int.Parse(tscore.text) + 1 ;
            tscore.text = iscore.ToString();
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
