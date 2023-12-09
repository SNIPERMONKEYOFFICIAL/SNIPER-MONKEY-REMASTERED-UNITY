using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpR : MonoBehaviour
{
    public GameObject RHPUT;
    public ParticleSystem Part4;
    public ParticleSystem Part5;
    public ParticleSystem Part6;

    private void OnTriggerEnter(Collider other)
    {
        if (RHPUT.transform.CompareTag("HandTag"))
        {
            Part4.Play();
            Part5.Play();
            Part6.Play();
            print("working");
        }
    }
}
