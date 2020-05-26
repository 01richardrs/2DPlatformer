using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 newPos = new Vector2(player.transform.position.x, player.transform.position.y+3);
        transform.position = new Vector3(newPos.x,newPos.y,transform.position.z);
    }
}
