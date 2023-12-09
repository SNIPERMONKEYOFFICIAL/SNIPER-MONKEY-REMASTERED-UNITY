using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpL : MonoBehaviour
{
    public GameObject LHPUT;
    public ParticleSystem Part1;
    public ParticleSystem Part2;
    public ParticleSystem Part3;

    private void OnTriggerEnter(Collider other)
    {
        if (LHPUT.transform.CompareTag("HandTag"))
        {
            Part1.Play();
            Part2.Play();
            Part3.Play();
            print("working");
        }
    }
}
