using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


public class PhotonManager : MonoBehaviourPunCallbacks
{
    private const string gameVersion = "1.0";
    private string playerName;
    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }


    void Start()
    {
        playerName = PlayerPrefs.GetString("PLAYER_NAME", "PLAYER_" + Random.Range(0, 101).ToString("000"));

        if (PhotonNetwork.IsConnected)
        {
            Debug.Log("Already Connected");
        }
        else
        {
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.NickName = playerName;
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    #region  DEVELOPER_CALLBACK
    public void OnJoinRoomButtonClick()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public void OnCreateRoomButtonClick()
    {
        RoomOptions ro = new RoomOptions();
        ro.MaxPlayers = 2;
        ro.IsOpen = true;
        ro.IsVisible = true;
        PhotonNetwork.CreateRoom("newRoom", ro);
    }
    #endregion

    #region PUN_CALLBACK

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log($"Join Failure {returnCode} / {message}");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        PhotonNetwork.ConnectUsingSettings();

    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room !!!");

        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("GameScene");
        }
    }

    #endregion


}
