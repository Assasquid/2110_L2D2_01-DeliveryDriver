using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed;
    [SerializeField] float moveSpeed;
    
    void Start()
    {
        
    }

    void Update()
    {
        float steerAmount = steerSpeed * Input.GetAxis("Horizontal");
        float moveAmount = moveSpeed * Input.GetAxis("Vertical");
        transform.Rotate(0, 0, -steerAmount * Time.deltaTime);
        transform.Translate(0, moveAmount * Time.deltaTime, 0);
    }
}
