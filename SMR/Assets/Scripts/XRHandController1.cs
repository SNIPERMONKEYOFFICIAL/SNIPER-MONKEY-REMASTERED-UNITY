using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
using Photon.Realtime;

public class XRHandController1 : MonoBehaviourPunCallbacks
{
    public HandTypeLeft handType;
    public float thumbMoveSpeed = 0.1f;

    public Animator animator;
    public InputDevice targetDevice;

    private float pose1Value;
    private float pose2Value;
    private float pose3Value;
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
        targetDevice.TryGetFeatureValue(CommonUsages.trigger, out pose1Value);
        targetDevice.TryGetFeatureValue(CommonUsages.grip, out pose2Value);

        targetDevice.TryGetFeatureValue(CommonUsages.primaryTouch, out bool primaryTouched);
        targetDevice.TryGetFeatureValue(CommonUsages.secondaryTouch, out bool secondaryTouched);

        if (primaryTouched || secondaryTouched)
        {
            pose3Value += thumbMoveSpeed;
        }
        else
        {
            pose3Value -= thumbMoveSpeed;
        }

        pose3Value = Mathf.Clamp(pose3Value, 0, 1);

        animator.SetFloat("pose1", pose1Value);
        animator.SetFloat("pose2", pose2Value);
        animator.SetFloat("pose3", pose3Value);
    }

}