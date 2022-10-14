using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject player;
    public GameObject playerPrefab;
    public GameObject playerSpawnPoint;
    public GameObject grandpa;
    public GameObject grandpaPrefab;
    public GameObject grandpaSpawnPoint;
    public GrandpaMovement grandpaMovement;
    public Grandpa grandpaScript;
    public bool reset = false;

    private void Start()
    {

    }

    private void Update()
    {
        grandpa = GameObject.FindGameObjectWithTag("Grandpa");
        player = GameObject.FindGameObjectWithTag("Player");
        grandpaMovement = grandpa.GetComponent<GrandpaMovement>();
        grandpaScript = grandpa.GetComponent<Grandpa>();
        if (reset)
        {
            Debug.Log("resetting");
            RespawnPlayer();
        }
    }

    public void RespawnPlayer()
    {
        
        grandpaMovement.playerDetected = false;
        player.transform.position = playerSpawnPoint.transform.position;
        grandpaScript.ResetGrandpa();
        reset = false;
    }
}
