using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSounds : MonoBehaviour
{
    public AudioSource Hitsound;

    void OnTriggerEnter()
    {
        new WaitForSeconds(1);
        Hitsound.Play();

    }
}
