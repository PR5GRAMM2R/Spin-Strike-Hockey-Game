using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    private readonly string gameVersion = "1";

    public TextMeshProUGUI connectionInfoText;
    public Button joinButton;

    private void Start()
    {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();

        joinButton.interactable = false;
        connectionInfoText.text = "Connection To Master Server...";
        connectionInfoText.color = Color.yellow; // 중립 상태에서 노란색으로 설정
    }

    public override void OnConnectedToMaster()
    {
        joinButton.interactable = true;
        connectionInfoText.text = "Online : Connected to Master Server";
        connectionInfoText.color = Color.green; // 연결 성공 시 초록색으로 설정
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        joinButton.interactable = false;
        connectionInfoText.text = $"Offline : Connection Disabled {cause.ToString()} - Try reconnecting...";
        connectionInfoText.color = Color.red; // 연결 실패 시 빨간색으로 설정

        PhotonNetwork.ConnectUsingSettings();
    }

    public void Connect()
    {
        joinButton.interactable = false;

        if (PhotonNetwork.IsConnected)
        {
            connectionInfoText.text = "Connecting to Random Room...";
            connectionInfoText.color = Color.yellow; // 연결 중 상태에서 노란색으로 설정
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            connectionInfoText.text = "Offline : Connection Disabled - Try reconnecting...";
            connectionInfoText.color = Color.red; // 연결 실패 시 빨간색으로 설정

            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        connectionInfoText.text = "There is no empty room, Creating new Room.";
        connectionInfoText.color = Color.yellow; // 새로운 방 생성 중에는 노란색으로 설정
        PhotonNetwork.CreateRoom(roomName: null, new RoomOptions { MaxPlayers = 2 });
    }

    public override void OnJoinedRoom()
    {
        connectionInfoText.text = "Connected with Room.";
        connectionInfoText.color = Color.green; // 방에 성공적으로 연결되면 초록색으로 설정
        PhotonNetwork.LoadLevel("InGame 1");
    }
}