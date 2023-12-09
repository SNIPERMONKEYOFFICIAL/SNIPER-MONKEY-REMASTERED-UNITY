using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using easyInputs;
using TMPro;

public class swtich : MonoBehaviour
{
    public GameObject Thing1;
    public GameObject Thing2;
    public int TimeHasPressedTheButton = 1;
    [Header("TEST DONT USE")] 
    public TMPro.TextMeshPro textMeshPro;

    private void FixedUpdate()
    {
        textMeshPro.text = TimeHasPressedTheButton.ToString();

        if (EasyInputs.GetPrimaryButtonDown(EasyHand.RightHand))
        {
            Thing1.SetActive(false);
            Thing2.SetActive(true);

            TimeHasPressedTheButton += 1;

            print(TimeHasPressedTheButton);

            new WaitForSeconds(5);

            if (TimeHasPressedTheButton < 2) ;
            {
                Thing1.SetActive(true);
                Thing2.SetActive(false);

                TimeHasPressedTheButton += 1;
            }
        }
    }
}    