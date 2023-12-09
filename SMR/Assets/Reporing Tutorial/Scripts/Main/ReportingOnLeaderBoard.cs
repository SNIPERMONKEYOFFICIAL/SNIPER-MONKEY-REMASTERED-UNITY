using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.XR;
using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;

public class ReportingOnLeaderBoard : MonoBehaviour
{
    private string playerUsername;
    private LeaderBoard script;
    private string playerID;
    public bool isParent;
    public GameObject[] buttons;


    public int playerSpot;
    public reportType _reportType;

    public enum reportType
    {
        Toxic,
        HateSpeech,
        Cheating
    }
    private void Start()
    {
        script = GameObject.FindObjectOfType<LeaderBoard>();
    }
    private void OnTriggerExit(Collider other)
    {
        base.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
    }

    private void OnTriggerEnter(Collider other)
    {
        base.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        script.activereportperson = script.usernames[playerSpot];

        if (_reportType == reportType.Toxic)
        {
            if (script.activereportperson == "")
            {

            }
            else
            {
                PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
                {
                    FunctionName = "SendReport",
                    FunctionParameter = new
                    {
                        ReporterUsername = playerUsername,
                        ReporterID = playerID,
                        ReportedUsername = script.activereportperson,
                        ReportedID = script.activereportpersonID,
                        ReportReason = "Toxic"
                    }
                }, ExecuteSuccess, ExecuteFail);
            }
        }
        if (_reportType == reportType.HateSpeech)
        {
            if (script.activereportperson == "")
            {

            }
            else
            {
                PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
                {
                    FunctionName = "SendReport",
                    FunctionParameter = new
                    {
                        ReporterUsername = playerUsername,
                        ReporterID = playerID,
                        ReportedUsername = script.activereportperson,
                        ReportedID = script.activereportpersonID,
                        ReportReason = "Hate Speech"
                    }
                }, ExecuteSuccess, ExecuteFail);
            }
        }
        if (_reportType == reportType.Cheating)
        {
            if (script.activereportperson == "")
            {

            }
            else
            {
                PlayFabClientAPI.ExecuteCloudScript(new ExecuteCloudScriptRequest()
                {
                    FunctionName = "SendReport",
                    FunctionParameter = new
                    {
                        ReporterUsername = playerUsername,
                        ReporterID = playerID,
                        ReportedUsername = script.activereportperson,
                        ReportedID = script.activereportpersonID,
                        ReportReason = "Cheating"
                    }
                }, ExecuteSuccess, ExecuteFail);
            }
        }
    }

    private void Update()
    {

        playerID = PlayerPrefs.GetString("PlayFabPlayerID");
        if (isParent)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                if (PhotonNetwork.PlayerList.Length >= i + 1)
                {
                    if (script.playfabids[i] != playerID)
                    {
                        buttons[i].SetActive(true);
                    }else
                    {
                        buttons[i].SetActive(false);
                    }
                }else
                {
                    buttons[i].SetActive(false);
                }
                
            }
        }


        if (PhotonNetwork.NickName == "")
        {

            if (PlayerPrefs.GetString("Username") == "")
            {
                if (PlayerPrefs.GetString("username") == "")
                {
                    Debug.LogError("Cannot Find Username, Make Sure You Are Saving It In A PlayerPref Or The Photon Network!");
                }
                else
                {
                    playerUsername = PlayerPrefs.GetString("username");
                }
            }
            else
            {
                playerUsername = PlayerPrefs.GetString("Username");
            }
        }
        else
        {
            playerUsername = PhotonNetwork.NickName;
        }
        
    }

    IEnumerator SendWebhook(string link, string message, System.Action<bool> action)
    {
        WWWForm form = new WWWForm();
        form.AddField("content", message);
        using (UnityWebRequest www = UnityWebRequest.Post(link, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                action(false);
            }
            else
                action(true);
        }
    }

    private void Awake()
    {
        Login();
    }

    void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    void OnSuccess(LoginResult result)
    {

        playerID = result.PlayFabId;

        // you can use this for alot of other things
        var Hash = PhotonNetwork.LocalPlayer.CustomProperties;
        if (!Hash.ContainsKey("PlayFabPlayerID"))
        {
            Hash.Add("PlayFabPlayerID", playerID);
        }
        if (!PlayerPrefs.HasKey("PlayFabPlayerID"))
        {
            PlayerPrefs.SetString("PlayFabPlayerID", playerID);
        }
        Debug.Log("playfabid = " + PhotonNetwork.LocalPlayer.CustomProperties["PlayFabPlayerID"]);
    }

    void OnError(PlayFabError error) { }



    void ExecuteSuccess(ExecuteCloudScriptResult request)
    {
        Debug.Log(request.FunctionResult);
    }

    void ExecuteFail(PlayFabError error)
    {
        Debug.LogError(error);
    }
}
