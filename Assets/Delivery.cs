using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Hey I bumped into something !");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package")
        {
            Debug.Log("Just picked up a parcel !");
        }

        else if (other.tag == "Customer")
        {
            Debug.Log("Hey mate !");
        } 
    }
}
