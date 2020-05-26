using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
void Start()
{
    StartCoroutine(AliveTime());
}
IEnumerator AliveTime(){
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
}
