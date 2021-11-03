using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] float buffSpeed;
    [SerializeField] float nerfSpeed;
    [SerializeField] ParticleSystem buffFX;
    [SerializeField] ParticleSystem nerfFX;
    
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Buff" && moveSpeed < 100)
        {
            moveSpeed += buffSpeed;
            Instantiate(buffFX, other.transform.position, Quaternion.identity);
        }

        else if (other.tag == "Nerf" && moveSpeed > 5)
        {
            moveSpeed -= nerfSpeed;
            Instantiate(nerfFX, other.transform.position, Quaternion.identity);
        }
    }

    void Update()
    {
        float steerAmount = steerSpeed * Input.GetAxis("Horizontal");
        float moveAmount = moveSpeed * Input.GetAxis("Vertical");
        
        if(moveAmount != 0)
        {
            transform.Rotate(0, 0, -steerAmount * Time.deltaTime);
        }
       
        transform.Translate(0, moveAmount * Time.deltaTime, 0);
    }
}
