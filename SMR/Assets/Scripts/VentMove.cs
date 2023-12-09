using UnityEngine;
using DG.Tweening;
using System.Collections;

public class VentMove : MonoBehaviour
{
    public Transform DoorTransform;
    public Transform DoorTransform2;
    public Vector3 openPosition; // Adjust the target position as needed
    public Vector3 openPosition2; // Adjust the target position as needed
    public Vector3 openPosition3; // Adjust the target position as needed
    public Vector3 openPosition4; // Adjust the target position as needed
    public Vector3 closedPosition;
    public Vector3 closedPosition2;
    public Vector3 UPMove1;
    public Vector3 UPMove2;
    public Vector3 UPMove3;
    public Vector3 DOWNMove1;
    public Vector3 DOWNMove2;
    public Vector3 DOWNMove3;
    public float animationDuration = 1.0f;
    public float animationDuration2 = 6f;
    public GameObject ElevObj;
    public AudioSource AC;
    public string HandTag;


    private Vector3 initialPosition;
    private Vector3 initialPosition2;
    private bool isOpen = false;

    private void Start()
    {
        if (DoorTransform == null)
        {
            DoorTransform = transform;
        }

        if (DoorTransform2 == null)
        {
            DoorTransform2 = transform;
        }

        initialPosition = DoorTransform.position;
        initialPosition2 = DoorTransform2.position;
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
        // Use DoTween to smoothly move the vent to the open position
        DoorTransform.DOMove(openPosition, animationDuration).OnComplete(() =>
        {
            isOpen = true;
        });

        DoorTransform2.DOMove(openPosition2, animationDuration).OnComplete(() =>
        {
            isOpen = true;
        });
    }

    public void CloseVent()
    {
        // Use DoTween to smoothly move the vent back to the initial position
        DoorTransform.DOMove(initialPosition, animationDuration).OnComplete(() =>
        {
            isOpen = false;
        });
        DoorTransform2.DOMove(initialPosition2, animationDuration).OnComplete(() =>
        {
            isOpen = false;
        });
    }

    public void OpenVent2()
    {
        // Use DoTween to smoothly move the vent to the open position
        DoorTransform.DOMove(openPosition3, animationDuration).OnComplete(() =>
        {
            isOpen = true;
        });
        // 0.355f

        DoorTransform2.DOMove(openPosition4, animationDuration).OnComplete(() =>
        {
            isOpen = true;
        });
        // 5.694f
    }

    public void CloseVent2()
    {
        // Use DoTween to smoothly move the vent back to the initial position
        DoorTransform.DOMove(closedPosition, animationDuration).OnComplete(() =>
        {
            isOpen = false;
        });
        // 2.152f

        DoorTransform2.DOMove(closedPosition2, animationDuration).OnComplete(() =>
        {
            isOpen = false;
        });
        //  4.052f

    }


    public void ElevUp()
    {
        ElevObj.transform.DOLocalMove(UPMove1, 10f, false);
        DoorTransform.transform.DOLocalMove(UPMove2, 10f, false);
        DoorTransform2.transform.DOLocalMove(UPMove3, 10f, false);
    }
    public void ElevDown()
    {
        ElevObj.transform.DOLocalMove(DOWNMove1, 10f, false);
        DoorTransform.transform.DOLocalMove(DOWNMove2, 10f, false);
        DoorTransform2.transform.DOLocalMove(DOWNMove3, 10f, false);
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
        OpenVent();
        yield return new WaitForSeconds(animationDuration2);
        CloseVent();
        yield return new WaitForSeconds(animationDuration2);
        ElevDown();
        AC.Play();
        yield return new WaitForSeconds(animationDuration2);
        OpenVent2();
        AC.Stop();
        yield return new WaitForSeconds(animationDuration2);
        CloseVent2();
        yield return new WaitForSeconds(animationDuration2);
        ElevUp();
        AC.Play();
        yield return new WaitForSeconds(animationDuration2);
        OpenVent();
        AC.Stop();
        yield return new WaitForSeconds(animationDuration2);
        CloseVent();
    }
}
