using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Wather : MonoBehaviour
{
    public XRDirectInteractor leftHandInteractor;
    public XRDirectInteractor rightHandInteractor;

    public float propulsionForce = 5f; // Adjust this value to control the propulsion force.
    public float waterGravity = 2f;   // Adjust this value for lower gravity in the water.

    private bool isInWater = false;
    private float originalGravity;

    private void Start()
    {

        // Subscribe to events to handle interactions.
        leftHandInteractor.selectEntered.AddListener(OnHandEnterWater);
        rightHandInteractor.selectEntered.AddListener(OnHandEnterWater);
        leftHandInteractor.selectExited.AddListener(OnHandExitWater);
        rightHandInteractor.selectExited.AddListener(OnHandExitWater);

        // Store the original gravity value.
        originalGravity = Physics.gravity.y;
    }

    private void Update()
    {
        // If you want to do additional processing while in the water, you can put it here.
        if (isInWater)
        {
            // Add any underwater logic here.
        }
    }

    private void OnHandEnterWater(SelectEnterEventArgs args)
    {
        // Check if the hand entered an object with the "WaterSurface" tag.
        if (args.interactable.CompareTag("Water"))
        {
            // Apply a forward force when the hand enters the water.
            Rigidbody handRigidbody = args.interactable.GetComponent<Rigidbody>();

            if (handRigidbody != null)
            {
                Vector3 propulsionDirection = transform.forward; // Adjust for the water's orientation if needed.
                handRigidbody.AddForce(propulsionDirection * propulsionForce, ForceMode.Impulse);
            }

            // Lower the gravity while in the water.
            Physics.gravity = new Vector3(0f, -waterGravity, 0f);

            // Set the flag to indicate that we are in the water.
            isInWater = true;
        }
    }

    private void OnHandExitWater(SelectExitEventArgs args)
    {
        // Check if the hand exited an object with the "WaterSurface" tag.
        if (args.interactable.CompareTag("Water"))
        {
            // Reset the hand's physics when it exits the water.
            Rigidbody handRigidbody = args.interactable.GetComponent<Rigidbody>();

            if (handRigidbody != null)
            {
                handRigidbody.drag = 0f;
                handRigidbody.angularDrag = 0f;
            }

            // Restore the original gravity when exiting the water.
            Physics.gravity = new Vector3(0f, originalGravity, 0f);

            // Set the flag to indicate that we are no longer in the water.
            isInWater = false;
        }
    }
}
