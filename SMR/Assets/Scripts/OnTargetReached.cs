using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnTargetReached : MonoBehaviour
{
    public SimpleShoot Shoot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("slide"))
        {
            Shoot.Slide();
        }
    }

}
