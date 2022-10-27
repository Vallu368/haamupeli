using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            playerSpawnPoint.SetActive(true);
        }
        else playerSpawnPoint.SetActive(false);


    }

    public void RespawnPlayer()
    {
        Debug.Log("peepoo");
        grandpaMovement.playerDetected = false;
        Vector3 pos = new Vector3(playerSpawnPoint.transform.position.x, playerSpawnPoint.transform.position.y, playerSpawnPoint.transform.position.z);
        player.transform.Rotate(0, 0, 0, Space.Self);
        player.transform.position = pos;
        grandpaScript.ResetGrandpa();
        reset = false;
    }

}
