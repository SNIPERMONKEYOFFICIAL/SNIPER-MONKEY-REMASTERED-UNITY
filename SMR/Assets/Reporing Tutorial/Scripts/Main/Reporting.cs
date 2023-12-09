namespace ReportingSystem
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;
    using UnityEngine.Networking;
    using UnityEngine.XR;
    using PlayFab;
    using PlayFab.ClientModels;
    using Photon.Pun;

    //Made By JokerJosh#6230
    public class Reporting : MonoBehaviour
    {
        // All Of These Are Found On Start
        private string playerUsername;
        private LeaderBoard script;
        private string playerID;


        public Keys Type;
        public int PlayerSpot;


        // Haptic Last Seconds (Leave At 0.05f)
        private float hapticWaitSeconds = 0.05f;

        public enum Keys
        {
            PlayerSelectButton,
            Toxic,
            HateSpeech,
            Cheating
        }

        void OnTriggerEnter(Collider other)
        {

            base.GetComponent<Renderer>().material.SetColor("_Color", Color.red);

            if (Type == Keys.PlayerSelectButton)
            {
                script.activereportperson = script.usernames[PlayerSpot - 1];
                script.activereportpersonID = script.playfabids[PlayerSpot - 1];
            }
            if (Type == Keys.Toxic)
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
            if (Type == Keys.HateSpeech)
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
            if (Type == Keys.Cheating)
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

        private void OnTriggerExit(Collider other)
        {
            base.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
        }

        private void Start()
        {
            script = GameObject.FindObjectOfType<LeaderBoard>();
        }

        private void Update()
        {
            if (PhotonNetwork.NickName == "")
            {
                
                if (PlayerPrefs.GetString("Username") == "")
                {
                    if (PlayerPrefs.GetString("username") == "")
                    {
                        Debug.Log("Cannot Find Username, Make Sure You Are Saving It In A PlayerPref Or The Photon Network!");
                    }else
                    {
                        playerUsername = PlayerPrefs.GetString("username");
                    }
                }
                else
                {
                    playerUsername = PlayerPrefs.GetString("Username");
                }
            }else
            {
                playerUsername = PhotonNetwork.NickName;
            }
        }

        private void StartVibration(bool forLeftController, float amplitude, float duration)
        {
            base.StartCoroutine(this.HapticPulses(forLeftController, amplitude, duration));
        }

        // Token: 0x06000315 RID: 789 RVA: 0x00016512 File Offset: 0x00014712
        private IEnumerator HapticPulses(bool forLeftController, float amplitude, float duration)
        {
            float startTime = Time.time;
            uint channel = 0U;
            InputDevice device;
            if (forLeftController)
            {
                device = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
            }
            else
            {
                device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
            }
            while (Time.time < startTime + duration)
            {
                device.SendHapticImpulse(channel, amplitude, this.hapticWaitSeconds);
                yield return new WaitForSeconds(this.hapticWaitSeconds * 0.9f);
            }
            yield break;
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
}
