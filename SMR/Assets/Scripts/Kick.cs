using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Application.Quit(); 
    }
}
