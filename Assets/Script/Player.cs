using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float maxSpeed = 1f;
    public float speedMultiplier = 10f;
    public Rigidbody2D playerRB;
    public Animator animator;
    private bool facingRight;
    public Collider2D coll2D;
    public float gravity = 1f;
    private AudioSource audio;
    public GameObject laserPrefab;
    public int projectileSpeed = 100;
    public Text tscore;

    void Start()
    {
        audio = GetComponent<AudioSource> ();
        animator = GetComponent<Animator>();
        playerRB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        float jump = Input.GetAxis("Jump");
        bool jump_mario = Input.GetButtonDown("Jump");

        float rbVelocity = playerRB.velocity.magnitude;

    if(rbVelocity < maxSpeed)
    {
        playerRB.AddForce(new Vector2(horizontalAxis*speedMultiplier,0)); 
    }
    
    if(horizontalAxis< 0 && this.transform.localScale.x == 1f)
    {
        transform.localScale = new Vector2(-1f,1f);
    }else if(horizontalAxis> 0 && this.transform.localScale.x == -1f)
    {
        transform.localScale = new Vector2(1f,1f);
    }
    
    if(jump_mario == true && coll2D.IsTouchingLayers(LayerMask.GetMask("Ground")))
    {
        playerRB.AddForce(new Vector2(0,23*speedMultiplier));
    }

    // if(coll2D.IsTouchingLayers(LayerMask.GetMask("Ladder")))
    // {
    //     playerRB.gravityScale = 0f;
    // }else
    // {
    //     playerRB.gravityScale = gravity;
    // } removed due to : when player walk around its harder to reach the ladder becuz too slippery since the gravity is 0f

    if(Mathf.Abs(verticalAxis)>0.2 && coll2D.IsTouchingLayers(LayerMask.GetMask("Ladder")))
    {
        Climb(verticalAxis);
        animator.SetBool("isClimb",true);
    }else if(Mathf.Abs(verticalAxis) < 0.2)
    {
        animator.SetBool("isClimb",false);
    }
    if(rbVelocity>0.1f)
    {
        animator.SetBool("isWalk",true);
    }else{
        animator.SetBool("isWalk",false);
    }
     if(Input.GetButtonDown("Fire1"))
       {
           StartCoroutine("Fire");
       }
       if(Input.GetButtonUp("Fire1"))
       {
           StopCoroutine("Fire");
           animator.SetBool("isAttack",false);
       }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy")
        {
            audio.Play();
            animator.SetBool("isDead",true);
            //in animatior , isdead is in player since its not working on ANYSTATE
            this.enabled = false;

            StartCoroutine(Wait2GameOver());
        }
    }
    IEnumerator Wait2GameOver()
    {
        yield return new WaitForSeconds(2);
        GameObject scoreText = GameObject.Find("Score");
        tscore = scoreText.GetComponent<Text>();
        int iscore = int.Parse(tscore.text) ;
        PlayerPrefs.SetInt("Score",iscore);
        SceneManager.LoadScene("GameOver");
    }

    void Climb(float yDirection)
    {
        float climbSpeed = 3f;
        if(yDirection> 0)
        {
            playerRB.velocity = new Vector2(0f,climbSpeed);
        }else{
            playerRB.velocity = new Vector2(0f, -climbSpeed);
        }
    }

    IEnumerator Fire(){
     while (true)
    {
        animator.SetBool("isAttack",true);
        // transform.position = new Vector3(transform.position.x + 10,transform.position.y,transform.position.z);
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
        laser.transform.Rotate(0, 0, -90.0f, 0);
        if(transform.localScale.x < 0){
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(-projectileSpeed * Time.deltaTime, 0); 
        }else if(transform.localScale.x > 0){
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(projectileSpeed * Time.deltaTime, 0); 
        }
        yield return new WaitForSeconds(3);
        // animator.SetBool("isAttack",false);
    }
    
    }

}
