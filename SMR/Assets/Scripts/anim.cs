using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using easyInputs;
using UnityEngine.XR;

public class anim : MonoBehaviour
{
    public Animator thumbAnimator;
    public Animator indexAnimator;
    public Animator pinkyAnimator;
    public Animator thumbAnimator2;
    public Animator indexAnimator2;
    public Animator pinkyAnimator2;

    void Update()
    {
        if (EasyInputs.GetTriggerButtonDown(EasyHand.LeftHand))
        {
            indexAnimator.SetTrigger("Trigger");
        }
        else
        {
            indexAnimator.SetTrigger("Nuh Uh");
        }
        if (EasyInputs.GetGripButtonDown(EasyHand.LeftHand))
        {
            pinkyAnimator.SetTrigger("Trigger");
        }
        else
        {
            pinkyAnimator.SetTrigger("Nuh Uh");
        }
        if (EasyInputs.GetPrimaryButtonDown(EasyHand.LeftHand))
        {
            thumbAnimator.SetTrigger("Trigger");
        }
        else
        {
            thumbAnimator.SetTrigger("Nuh Uh");
        }
    }

}
