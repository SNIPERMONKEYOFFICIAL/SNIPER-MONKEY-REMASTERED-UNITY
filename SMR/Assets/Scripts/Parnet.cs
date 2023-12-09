using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parnet : MonoBehaviour
{
    public GameObject Slide;
    public GameObject Gun;

    // Update is called once per frame
    void FixedUpdate()
    {
         Slide.transform.SetParent(Gun.transform);
    }
}
