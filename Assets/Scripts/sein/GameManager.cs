using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    public Transform[] spawnPoints;

    void Start()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            // �÷��̾ ������ ���� ������ ����
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            PhotonNetwork.Instantiate(playerPrefab.name, spawnPoints[spawnIndex].position, Quaternion.identity);
        }
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");

        // �÷��̾ ������ ���� ������ ����
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPoints[spawnIndex].position, Quaternion.identity);
    }
}