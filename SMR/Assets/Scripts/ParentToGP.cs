using UnityEngine;
using Photon.Pun;
using System.Collections;

public class ParentToGP : MonoBehaviourPunCallbacks
{
    private bool isParented = false;

    void Start()
    {
        if (photonView.IsMine)
        {
            // This code runs on the local player's instance.
            // You can put any setup logic here that should only affect the local player.

            StartCoroutine(WaitAndParent());
        }
    }

    IEnumerator WaitAndParent()
    {
        yield return new WaitForSeconds(5f); // Wait for 5 seconds.

        // Check if we are the owner of this object and it hasn't been parented already.
        if (!isParented)
        {
            // Find the object you want to parent to.
            GameObject parentObject = GameObject.Find("Capsule"); // Replace with the actual name or tag of your parent object.

            if (parentObject != null)
            {
                // Parent this GameObject to the parentObject.
                transform.SetParent(parentObject.transform);

                // Set the flag to avoid parenting it again.
                isParented = true;
            }
            else
            {
                Debug.LogError("Parent object not found.");
            }
        }
    }
}
