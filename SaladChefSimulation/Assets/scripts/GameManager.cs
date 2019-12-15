using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameFacilitator;
    public GameObject fruitStalls;
    public GameObject customers;
    public GameObject trashCans;
    public GameObject choppingBoards;
    public GameObject plateTable;
    private InputManager inputManager;
    private FruitStallManager fruitStallManager;
    private CustomerManager customersManager;
    private TrashCanManager trashCansManager;
    private ChoppingBoardManager choppingBoardManager;
    private PlateTableManager plateTablelManager;

    void Start()
    {
        inputManager = gameFacilitator.GetComponent<InputManager>();
        fruitStallManager = fruitStalls.GetComponent<FruitStallManager>();
        customersManager = customers.GetComponent<CustomerManager>();
        trashCansManager = trashCans.GetComponent<TrashCanManager>();
        choppingBoardManager = choppingBoards.GetComponent<ChoppingBoardManager>();
        plateTablelManager = plateTable.GetComponent<PlateTableManager>();
        choppingBoardManager = choppingBoards.GetComponent<ChoppingBoardManager>();
    }

    // Update is called once per frame
    void Update()
    {
        inputManager.HandleCameraZoom();
        inputManager.HandleCameraPan();
        inputManager.HandlePlayersMovementTrack();

        fruitStallManager.HandleFruitStallManagement();
        trashCansManager.HandleTrashCansFeatures();
        choppingBoardManager.HandleChopperTablesFeatures();
    }
}
