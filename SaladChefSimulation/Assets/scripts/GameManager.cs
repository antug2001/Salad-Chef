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
    public GameObject miscellinious;
    private InputManager inputManager;
    private FruitStallManager fruitStallManager;
    private CustomerManager customersManager;
    private TrashCanManager trashCansManager;
    private ChoppingBoardManager choppingBoardManager;
    private PlateTableManager plateTablelManager;
    private MiscelleniousManager miscelleniousManager;
    private HUDManager hudManager;
    void Start()
    {
        //all the necessary reference collected
        inputManager = gameFacilitator.GetComponent<InputManager>();
        fruitStallManager = fruitStalls.GetComponent<FruitStallManager>();
        customersManager = customers.GetComponent<CustomerManager>();
        trashCansManager = trashCans.GetComponent<TrashCanManager>();
        choppingBoardManager = choppingBoards.GetComponent<ChoppingBoardManager>();
        plateTablelManager = plateTable.GetComponent<PlateTableManager>();
        miscelleniousManager = miscellinious.GetComponent<MiscelleniousManager>();
        hudManager = gameObject.GetComponent<HUDManager>();
    }

    // Update is called once per frame
    void Update()
    {        
        //monitoring the whole game stake holders
        fruitStallManager.HandleFruitStallManagement();
        trashCansManager.HandleTrashCansFeatures();
        choppingBoardManager.HandleChopperTablesFeatures();
        plateTablelManager.HandlePlateTableFeatures();
        customersManager.HandleCustomerActivities();
        miscelleniousManager.HandleMiscellinious();

        TrackGameState();
    }

    private void LateUpdate()
    {
        //camera movement handling taken care
        inputManager.HandleCameraZoom();
        inputManager.HandleCameraPan();
        inputManager.HandlePlayersMovementTrack();
    }

    void TrackGameState()//game result calculated after either of the player's time over and winner declared based on greater score collected
    {
       // print("t1 "+ miscelleniousManager.playerOneTime+" t2 "+ miscelleniousManager.playerTwoTime);
        if(miscelleniousManager.playerOneTime<0 || miscelleniousManager.playerTwoTime < 0)
        {
            print("s1 " + miscelleniousManager.playerOneScore + " s2 " + miscelleniousManager.playerTwoScore);    
            if(miscelleniousManager.playerOneScore == miscelleniousManager.playerTwoScore)
            {
                hudManager.playerDrawMessage.SetActive(true);
                print("11111");
            }
            else if(miscelleniousManager.playerOneScore > miscelleniousManager.playerTwoScore)
            {
                hudManager.playerOneWininMessage.SetActive(true);
                print("22222222");
            }
            else if(miscelleniousManager.playerOneScore < miscelleniousManager.playerTwoScore)
            {
                hudManager.playerTwoWininMessage.SetActive(true);
                print("33333333");
            }
            Time.timeScale = 0;
        }
    }


}
