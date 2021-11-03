using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Delivery : MonoBehaviour
{
    bool hasPackage;
    [SerializeField] float destructionDelay;
    [SerializeField] ParticleSystem pickUpFX;
    [SerializeField] ParticleSystem deliveredFX;
    [SerializeField] GameObject parcelIndicator;
    // [SerializeField] Color32 packageColor;
    // [SerializeField] Color32 noPackageColor;
    // SpriteRenderer capsuleSpriteRenderer;
    public int packagesLeft;
    public GameObject[] totalPackages;
    [SerializeField] TMP_Text packagesLeftText;
    

    void Start() 
    {
        parcelIndicator.SetActive(false);
        // capsuleSpriteRenderer = GetComponent<SpriteRenderer>();
        packagesLeft = totalPackages.Length;
        packagesLeftText.text = packagesLeft.ToString();
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        // Debug.Log("Hey I bumped into something !");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("Just picked up a parcel !");
            hasPackage = true;
            parcelIndicator.SetActive(true);
            // capsuleSpriteRenderer.color = packageColor;
            Destroy(other.gameObject, destructionDelay);
            Instantiate(pickUpFX, other.transform.position, Quaternion.identity);
        }

        else if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("Parcel delivered !");
            hasPackage = false;
            parcelIndicator.SetActive(false);
            // capsuleSpriteRenderer.color = noPackageColor;
            Instantiate(deliveredFX, other.transform.position, Quaternion.identity);
            packagesLeft --;
            packagesLeftText.text = packagesLeft.ToString();
        } 
    }
}
