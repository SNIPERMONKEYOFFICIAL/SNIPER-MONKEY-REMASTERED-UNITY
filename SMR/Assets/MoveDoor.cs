using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveDoor : MonoBehaviour
{
    public GameObject Door;
    public string HandTag;
    public float DoorY;
    public float DoorYDown;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(HandTag))
        {
            StartCoroutine(Wait());
        }
    }

    IEnumerator Wait()
    {
        Door.transform.DOLocalMoveY(DoorY, 2f, false);
        yield return new WaitForSeconds(5);
        Door.transform.DOLocalMoveY(DoorYDown, 2f, false);
    }

}
