using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddLetter : MonoBehaviour
{
    public NameScript nameScript;
    public string Handtag;
    public string Letter;

    private void OnTriggerEnter(Collider other)
    {
        new WaitForSeconds(1);

        if(other.transform.tag == Handtag) 
        {
            nameScript.NameVar += Letter;
        }
    }
}
