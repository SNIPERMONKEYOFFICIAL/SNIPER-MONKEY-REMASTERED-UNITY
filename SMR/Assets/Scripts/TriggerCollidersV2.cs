using UnityEngine;
using System.Collections.Generic;

public class TriggerCollidersV2 : MonoBehaviour
{
    public string objectTag; 
    public List<GameObject> objectsToEnableInsideCollider; 
    public List<GameObject> objectsToDisableInsideCollider; 
    public List<GameObject> objectsToEnableOutsideCollider; 
    public List<GameObject> objectsToDisableOutsideCollider; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(objectTag))
        {
            
            foreach (var obj in objectsToEnableInsideCollider)
            {
                obj.SetActive(true);
            }

            foreach (var obj in objectsToDisableInsideCollider)
            {
                obj.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(objectTag))
        {
            
            foreach (var obj in objectsToEnableOutsideCollider)
            {
                obj.SetActive(true);
            }

            foreach (var obj in objectsToDisableOutsideCollider)
            {
                obj.SetActive(false);
            }
        }
    }
}
