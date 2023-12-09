using UnityEngine;
using Photon.Pun;

public class NetworkedObjectParenting : MonoBehaviourPunCallbacks
{
    private bool isParented = false;

    void Start()
    {
        if (photonView.IsMine)
        {
            // This code runs on the local player's instance.
            // You can put any setup logic here that should only affect the local player.

            // Check if we are the owner of this object.
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
}

