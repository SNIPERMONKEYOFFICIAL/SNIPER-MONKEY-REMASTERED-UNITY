using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.ProBuilder.Shapes;

public class kamehame : MonoBehaviour
{

    private GameObject thisHand;
    public GameObject otherHand;
    private float distanceBetweenHands;
    private LineRenderer lineRenderer;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<LineRenderer>();
        lineRenderer = new LineRenderer();
        lineRenderer.positionCount = 2;
        thisHand = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        var distenceBetweenHands = Vector3.Distance(thisHand.transform.position, otherHand.transform.position);
        lineRenderer.SetPositions(new Vector3[] { thisHand.transform.position, otherHand.transform.position });
    }
}
