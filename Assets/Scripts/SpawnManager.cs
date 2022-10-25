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
    public Menu menu;
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
        Debug.Log("peepoo");
        grandpaMovement.playerDetected = false;
        Vector3 pos = new Vector3(playerSpawnPoint.transform.position.x, playerSpawnPoint.transform.position.y, playerSpawnPoint.transform.position.z + 0.001f);
        player.transform.position = pos;
        grandpaScript.ResetGrandpa();
        reset = false;
    }
}
