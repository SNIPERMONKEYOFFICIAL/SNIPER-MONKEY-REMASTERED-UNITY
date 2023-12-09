using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class LeaderBoard : MonoBehaviour
{
    [SerializeField] public string[] usernames;
    [SerializeField] public string[] playfabids;
    [SerializeField] public TMP_Text displaySpot;
    [SerializeField] public string activereportperson;
    [SerializeField] public string activereportpersonID;

    private void Update()
    {
        usernames = new string[PhotonNetwork.PlayerList.Length];
        playfabids = new string[PhotonNetwork.PlayerList.Length];
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            usernames[i] = PhotonNetwork.PlayerList[i].NickName;
            playfabids[i] = (string)PhotonNetwork.PlayerList[i].CustomProperties["PlayFabPlayerID"];
            displaySpot.text = string.Join("\n", usernames);
        }
    }
}
