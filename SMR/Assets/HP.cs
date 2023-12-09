using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using easyInputs;

public class HP : MonoBehaviour
{
    public GameObject Red;
    public GameObject Blue;
    public GameObject Perple;

    void Update()
    {
        ThumbButtonUsed();
    }

    void ThumbButtonUsed()
    {
        if (EasyInputs.GetThumbStickButtonDown(EasyHand.RightHand))
        {
            StartCoroutine(HollowP());
        }

        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(HollowP());
        }

    }


    IEnumerator HollowP()
    {
        Red.transform.position = new Vector3(5f, 0, -1.58f);
        Blue.transform.position = new Vector3(-5f, 0, -1.58f);
        Red.SetActive(true);
        yield return new WaitForSeconds(3f);
        Blue.SetActive(true);
        yield return new WaitForSeconds(10f);
        Red.transform.position = new Vector3(0, 0, -1.58f);
        Blue.transform.position = new Vector3(0, 0, -1.58f);
        yield return new WaitForSeconds(3f);
        Perple.SetActive(true);
        yield return new WaitForSeconds(5f);
        Red.SetActive(false);
        Blue.SetActive(false);
        Perple.SetActive(false);
    }
}
