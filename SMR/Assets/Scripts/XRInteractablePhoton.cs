using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

public class XRInteractablePhoton : MonoBehaviourPunCallbacks
{
    private DualHandGI interactable;

    private void Start()
    {
        interactable = GetComponent<DualHandGI>();

        // Register this script as the interaction manager for the interactable object.
        interactable.onSelectEntered.AddListener(OnSelectEnter);
        interactable.onSelectExited.AddListener(OnSelectExit);
    }

    // Called when a player starts grabbing the object.
    public void OnSelectEnter(XRBaseInteractor interactor)
    {
        if (photonView.IsMine)
        {
            // Handle interactions here, such as enabling/disabling physics, changing object state, etc.
        }
        else
        {
            // Inform the server that the object has been grabbed.
            photonView.RequestOwnership(); // Request ownership of this object on the server.
            photonView.RPC("OnSelectEnterRemote", RpcTarget.Others); // Notify other clients.
        }
    }

    // Called when a player stops grabbing the object.
    public void OnSelectExit(XRBaseInteractor interactor)
    {
        if (photonView.IsMine)
        {
            // Handle interactions here, such as enabling/disabling physics, changing object state, etc.
        }
        else
        {
            photonView.RPC("OnSelectExitRemote", RpcTarget.Others); // Notify other clients.
        }
    }

    // This RPC method is called on other clients when a player starts grabbing the object.
    [PunRPC]
    private void OnSelectEnterRemote()
    {
        // Handle interactions for remote clients, such as enabling/disabling visuals or sounds.
    }

    // This RPC method is called on other clients when a player stops grabbing the object.
    [PunRPC]
    private void OnSelectExitRemote()
    {
        // Handle interactions for remote clients, such as enabling/disabling visuals or sounds.
    }
}
