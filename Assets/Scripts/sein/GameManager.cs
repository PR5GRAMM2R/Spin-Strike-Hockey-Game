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
            // 플레이어를 랜덤한 스폰 지점에 생성
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            PhotonNetwork.Instantiate(playerPrefab.name, spawnPoints[spawnIndex].position, Quaternion.identity);
        }
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");

        // 플레이어를 랜덤한 스폰 지점에 생성
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPoints[spawnIndex].position, Quaternion.identity);
    }
}