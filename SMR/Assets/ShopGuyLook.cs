using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopGuyLook : MonoBehaviour
{
    public GameObject player;

    public GameObject ShopGuy;

    // Update is called once per frame
    void Update()
    {
        ShopGuy.transform.LookAt(player.transform.position);
    }
}
