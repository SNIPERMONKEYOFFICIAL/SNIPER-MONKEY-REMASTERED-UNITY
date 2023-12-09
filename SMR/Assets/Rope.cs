using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Rope : MonoBehaviour
{
    public GameObject ropeSegmentPrefab;
    public int segmentCount = 10;
    public float segmentSpacing = 0.1f;

    private GameObject[] ropeSegments;
    private XRGrabInteractable[] grabInteractables;

    private void Start()
    {
        // Create the rope segments.
        CreateRope();

        // Connect the rope segments.
        ConnectRope();

        // Set up XR Interactables for grabbing.
        ConfigureXRInteractables();
    }

    private void CreateRope()
    {
        ropeSegments = new GameObject[segmentCount];
        grabInteractables = new XRGrabInteractable[segmentCount];

        for (int i = 0; i < segmentCount; i++)
        {
            ropeSegments[i] = Instantiate(ropeSegmentPrefab, transform.position + i * segmentSpacing * Vector3.down, Quaternion.identity);
            ropeSegments[i].transform.parent = transform;
        }
    }

    private void ConnectRope()
    {
        for (int i = 1; i < segmentCount; i++)
        {
            // Connect segments with HingeJoint components.
            var hingeJoint = ropeSegments[i].AddComponent<HingeJoint>();
            hingeJoint.connectedBody = ropeSegments[i - 1].GetComponent<Rigidbody>();
        }
    }

    private void ConfigureXRInteractables()
    {
        for (int i = 0; i < segmentCount; i++)
        {
            grabInteractables[i] = ropeSegments[i].GetComponent<XRGrabInteractable>();
            grabInteractables[i].interactionLayerMask = LayerMask.GetMask("Interactable"); // Set your desired interaction layer.
        }
    }
}
