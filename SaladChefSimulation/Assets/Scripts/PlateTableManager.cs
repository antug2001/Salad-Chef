using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlateTableManager : MonoBehaviour
{

    private PlayerManager playerManager;
    public GameObject players;
    [HideInInspector]
    public bool plateCollectedPlayerOne = false, plateCollectedPlayerTwo = false;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = players.GetComponent<PlayerManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HandlePlateTableFeatures()//ensuring plates are collected by both player before serving to customer
    {
        if (playerManager.playerOneDestinationIdentity == PlayerManager.DestinationType.PLATE_TABLES)
        {
            if (playerManager.playerOneDestinationReached)
            {
                playerManager.playerOneDestinationReached = false;
                plateCollectedPlayerOne = true;
            }
        }
        if (playerManager.playerTwoDestinationIdentity == PlayerManager.DestinationType.PLATE_TABLES)
        {
            if (playerManager.playerTwoDestinationReached)
            {
                playerManager.playerTwoDestinationReached = false;
                plateCollectedPlayerTwo = true;
            }
        }
    }
}
