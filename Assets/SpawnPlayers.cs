using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if (PhotonNetwork.LocalPlayer.ActorNumber == 1)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(-1.92999995f, -1.38f, 0.850000024f), Quaternion.Euler(0f, 88.2539902f, 0f));
        }
        if (PhotonNetwork.LocalPlayer.ActorNumber == 2)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(1.92999995f, -1.38f, 0.850000024f), Quaternion.Euler(0f, 280.253967f, 0f));
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
