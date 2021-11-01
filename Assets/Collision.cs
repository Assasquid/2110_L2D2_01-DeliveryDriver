using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Hey I bumped into something !");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("Did I run over something !?");
    }
}
