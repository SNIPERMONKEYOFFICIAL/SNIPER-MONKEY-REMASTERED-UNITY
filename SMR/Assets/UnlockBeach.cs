using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UnlockBeach : MonoBehaviour
{
    public GameObject Keycard;
    public GameObject Keycard2;
    public GameObject Couch;
    public float SlideY;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BeachKeycard"))
        {
            Keycard.SetActive(false);
            Keycard2.SetActive(true);
            Couch.transform.DOLocalMoveZ(SlideY, 10f, false);
        }
    }
}
