using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using Photon.Realtime;

public class XRHandController : MonoBehaviourPunCallbacks
{
    public HandTypeLeft handType;
    public float thumbMoveSpeed = 0.1f;

    public Animator animator;
    public InputDevice targetDevice;

    private float pose4Value;
    private float pose5Value;
    private float pose6Value;
    public PhotonView view;

    private void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        foreach (var item in devices)
        {
            Debug.Log(item.name + item.characteristics);
        }

        if (devices.Count > 0)
        {
            targetDevice = devices[0];
        }


    }

    void Update()
    {
        if (view.IsMine)
        {
            AnimateHand();
        }
    }

    void AnimateHand()
    {
        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out pose4Value);
        targetDevice.TryGetFeatureValue(CommonUsages.grip, out pose5Value);

        targetDevice.TryGetFeatureValue(CommonUsages.primaryTouch, out bool primaryTouched);
        targetDevice.TryGetFeatureValue(CommonUsages.secondaryTouch, out bool secondaryTouched);

        if (primaryTouched || secondaryTouched)
        {
            pose6Value += thumbMoveSpeed;
        }
        else
        {
            pose6Value -= thumbMoveSpeed;
        }

        pose6Value = Mathf.Clamp(pose6Value, 0, 1);

        animator.SetFloat("pose4", pose4Value);
        animator.SetFloat("pose5", pose5Value);
        animator.SetFloat("pose6", pose6Value);
    }

}