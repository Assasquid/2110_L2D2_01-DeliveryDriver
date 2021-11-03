using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed;
    [SerializeField] float moveSpeed;
    [SerializeField] float buffSpeed;
    [SerializeField] float maxSpeed;
    [SerializeField] float nerfSpeed;
    [SerializeField] float minSpeed;
    [SerializeField] ParticleSystem buffFX;
    [SerializeField] AudioClip buffSound;
    [SerializeField] float buffSoundVolume;    
    [SerializeField] ParticleSystem nerfFX;
    [SerializeField] AudioClip nerfSound;
    [SerializeField] float nerfSoundVolume;
    AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Buff" && moveSpeed < maxSpeed)
        {
            moveSpeed += buffSpeed;
            Instantiate(buffFX, other.transform.position, Quaternion.identity);
            audioSource.PlayOneShot(buffSound, buffSoundVolume);
        }

        else if (other.tag == "Nerf" && moveSpeed > minSpeed)
        {
            moveSpeed -= nerfSpeed;
            Instantiate(nerfFX, other.transform.position, Quaternion.identity);
            audioSource.PlayOneShot(nerfSound, nerfSoundVolume);
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
