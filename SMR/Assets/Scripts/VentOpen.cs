using UnityEngine;
using DG.Tweening;
using System.Collections;

public class VentOpen : MonoBehaviour
{
    public Transform ventHinge;
    public Vector3 openRotation = new Vector3(0f, -90f, 0f); // Adjust the rotation as needed
    public float animationDuration = 1.0f;
    public string HandTag;

    private bool isOpen = false;

    private void Start()
    {
        if (ventHinge == null)
        {
            ventHinge = transform;
        }
    }

    public void ToggleVent()
    {
        if (isOpen)
        {
            CloseVent();
        }
        else
        {
            OpenVent();
        }
    }

    public void OpenVent()
    {
        // Use DoTween to smoothly rotate the vent hinge to the open position
        ventHinge.DORotate(openRotation, animationDuration).OnComplete(() =>
        {
            isOpen = true;
        });
    }

    public void CloseVent()
    {
        // Use DoTween to smoothly rotate the vent hinge back to the closed position
        ventHinge.DORotate(Vector3.zero, animationDuration).OnComplete(() =>
        {
            isOpen = false;
        });
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(HandTag))
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        ToggleVent();
        yield return new WaitForSeconds(10);
        ToggleVent();
    }
}
