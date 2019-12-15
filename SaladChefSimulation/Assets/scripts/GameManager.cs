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
        fruitStallManager = gameFacilitator.GetComponent<FruitStallManager>();
        customersManager = gameFacilitator.GetComponent<CustomerManager>();
        trashCansManager = gameFacilitator.GetComponent<TrashCanManager>();
        choppingBoardManager = gameFacilitator.GetComponent<ChoppingBoardManager>();
        plateTablelManager = gameFacilitator.GetComponent<PlateTableManager>();
    }

    // Update is called once per frame
    void Update()
    {
        inputManager.HandleCameraZoom();
        inputManager.HandleCameraPan();
        inputManager.HandlePlayersMovementTrack();

        fruitStallManager.HandleFruitStallManagement();
    }
}
