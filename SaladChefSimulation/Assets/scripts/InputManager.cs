using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    public GameObject fruitStallOne;
    public GameObject fruitStallTwo;
    public GameObject fruitStallThree;
    public GameObject fruitStallFour;
    public GameObject fruitStallFive;
    public GameObject fruitStallSix;
    public GameObject customerOne;
    public GameObject customerTwo;
    public GameObject customerThree;
    public GameObject customerFour;
    public GameObject customerFive;
    public GameObject choppingBoardOne;
    public GameObject choppingBoardTwo;
    public GameObject trashCanOne;
    public GameObject trashCanTwo;
    public GameObject plateTable;
    public GameObject chopBoards;

    private float ZoomAmount = 0;
    private float MaxToClamp = 10;
    private float ROTSpeed = 1;
    private Vector3 touchStart;
    private float groundZ = 0;
    private PlayerManager playerManager;
    private ChoppingBoardManager chopBoardManager;
    public GameObject players;
    // Start is called before the first frame update
    void Start()
    {
        playerManager = players.GetComponent<PlayerManager>();
        chopBoardManager = chopBoards.GetComponent<ChoppingBoardManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }    

    public void HandlePlayersMovementTrack()
    {
        if (Input.GetKeyDown(KeyCode.Return) && !playerManager.isMovementAllowedPlayerOne && !chopBoardManager.isChoppingPlayerOne)
            playerManager.isMovementAllowedPlayerOne = true;

        if (Input.GetKeyDown(KeyCode.Space) && !playerManager.isMovementAllowedPlayerTwo && !chopBoardManager.isChoppingPlayerTwo)
            playerManager.isMovementAllowedPlayerTwo = true;

        if (playerManager.isMovementAllowedPlayerOne)
        {
            //input keymap for first player
            if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
            {
                playerManager.targetPlayerOnePosition = customerOne.transform;
            }
            else if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
            {
                playerManager.targetPlayerOnePosition = customerTwo.transform;
            }
            else if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
            {
                playerManager.targetPlayerOnePosition = customerThree.transform;
            }
            else if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
            {
                playerManager.targetPlayerOnePosition = customerFour.transform;
            }
            else if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5))
            {
                playerManager.targetPlayerOnePosition = customerFive.transform;
            }
            else if (Input.GetKeyDown(KeyCode.F1))
            {
                playerManager.targetPlayerOnePosition = fruitStallOne.transform;
                playerManager.playerOneDestinationIdentity = PlayerManager.DestinationType.FRUIT_STALL_ONE;
            }
            else if (Input.GetKeyDown(KeyCode.F2) )
            {
                playerManager.targetPlayerOnePosition = fruitStallTwo.transform;
                playerManager.playerOneDestinationIdentity = PlayerManager.DestinationType.FRUIT_STALL_TWO;
            }
            else if (Input.GetKeyDown(KeyCode.F3))
            {
                playerManager.targetPlayerOnePosition = fruitStallThree.transform;
                playerManager.playerOneDestinationIdentity = PlayerManager.DestinationType.FRUIT_STALL_THREE;
            }
            else if (Input.GetKeyDown(KeyCode.F4) )
            {
                playerManager.targetPlayerOnePosition = fruitStallFour.transform;
                playerManager.playerOneDestinationIdentity = PlayerManager.DestinationType.FRUIT_STALL_FOUR;
            }
            else if (Input.GetKeyDown(KeyCode.F5))
            {
                playerManager.targetPlayerOnePosition = fruitStallFive.transform;
                playerManager.playerOneDestinationIdentity = PlayerManager.DestinationType.FRUIT_STALL_FIVE;
            }
            else if (Input.GetKeyDown(KeyCode.F6))
            {
                playerManager.targetPlayerOnePosition = fruitStallSix.transform;
                playerManager.playerOneDestinationIdentity = PlayerManager.DestinationType.FRUIT_STALL_SIX;
            }
            else if (Input.GetKeyDown(KeyCode.T))
            {
                playerManager.targetPlayerOnePosition = trashCanOne.transform;
                playerManager.playerOneDestinationIdentity = PlayerManager.DestinationType.TRASH_CAN_ONE;
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                playerManager.targetPlayerOnePosition = choppingBoardOne.transform;
                playerManager.playerOneDestinationIdentity = PlayerManager.DestinationType.CHOPPING_BOARD_ONE;
            }
            else if (Input.GetKeyDown(KeyCode.P))
            {
                playerManager.targetPlayerOnePosition =plateTable.transform;
                playerManager.playerOneDestinationIdentity = PlayerManager.DestinationType.PLATE_TABLES;
            }
        }
        //input key map for second player
        if (playerManager.isMovementAllowedPlayerTwo)
        {
            if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6))
            {
                playerManager.targetPlayerTwoPosition = customerOne.transform; 
            }
            else if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha7))
            {
                playerManager.targetPlayerTwoPosition = customerTwo.transform;
            }
            else if (Input.GetKeyDown(KeyCode.Keypad8) || Input.GetKeyDown(KeyCode.Alpha8))
            {
                playerManager.targetPlayerTwoPosition = customerThree.transform;
            }
            else if (Input.GetKeyDown(KeyCode.Keypad9) || Input.GetKeyDown(KeyCode.Alpha9))
            {
                playerManager.targetPlayerTwoPosition = customerFour.transform;
            }
            else if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Alpha0))
            {
                playerManager.targetPlayerTwoPosition = customerFive.transform;
            }
            else if (Input.GetKeyDown(KeyCode.F7))
            {
                playerManager.targetPlayerTwoPosition = fruitStallOne.transform;
                playerManager.playerTwoDestinationIdentity = PlayerManager.DestinationType.FRUIT_STALL_ONE;
            }
            else if (Input.GetKeyDown(KeyCode.F8))
            {
                playerManager.targetPlayerTwoPosition = fruitStallTwo.transform;
                playerManager.playerTwoDestinationIdentity = PlayerManager.DestinationType.FRUIT_STALL_TWO;
            }
            else if (Input.GetKeyDown(KeyCode.F9))
            {
                playerManager.targetPlayerTwoPosition = fruitStallThree.transform;
                playerManager.playerTwoDestinationIdentity = PlayerManager.DestinationType.FRUIT_STALL_THREE;
            }
            else if (Input.GetKeyDown(KeyCode.F10))
            {
                playerManager.targetPlayerTwoPosition = fruitStallFour.transform;
                playerManager.playerTwoDestinationIdentity = PlayerManager.DestinationType.FRUIT_STALL_FOUR;
            }
            else if (Input.GetKeyDown(KeyCode.F11))
            {
                playerManager.targetPlayerTwoPosition = fruitStallFive.transform;
                playerManager.playerTwoDestinationIdentity = PlayerManager.DestinationType.FRUIT_STALL_FIVE;
            }
            else if (Input.GetKeyDown(KeyCode.F12))
            {
                playerManager.targetPlayerTwoPosition = fruitStallSix.transform;
                playerManager.playerTwoDestinationIdentity = PlayerManager.DestinationType.FRUIT_STALL_SIX;
            }
            else if (Input.GetKeyDown(KeyCode.Y))
            {
                playerManager.targetPlayerTwoPosition = trashCanTwo.transform;
                playerManager.playerTwoDestinationIdentity = PlayerManager.DestinationType.TRASH_CAN_TWO;
            }
            else if (Input.GetKeyDown(KeyCode.V))
            {
                playerManager.targetPlayerTwoPosition = choppingBoardTwo.transform;
                playerManager.playerTwoDestinationIdentity = PlayerManager.DestinationType.CHOPPING_BOARD_TWO;
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                playerManager.targetPlayerTwoPosition = plateTable.transform;
                playerManager.playerTwoDestinationIdentity = PlayerManager.DestinationType.PLATE_TABLES;
            }
        }
    }

    public void HandleCameraZoom()//mouse wheel rotation based camera distance calculate within max-min position for zooming
    {
        ZoomAmount += Input.GetAxis("Mouse ScrollWheel");
        ZoomAmount = Mathf.Clamp(ZoomAmount, -MaxToClamp, MaxToClamp);
        float translate = Mathf.Min(Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")), MaxToClamp - Mathf.Abs(ZoomAmount));
        Camera.main.transform.Translate(0, 0, translate * ROTSpeed * Mathf.Sign(Input.GetAxis("Mouse ScrollWheel")));
    }

    public void HandleCameraPan()//mouse pointer pressed camera pan calculation
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchStart = GetWorldPosition(groundZ);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - GetWorldPosition(groundZ);
            Camera.main.transform.position += direction;
        }
    }

    private Vector3 GetWorldPosition(float z)//world position obtained from screen point
    {
        Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane ground = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        ground.Raycast(mousePos, out distance);
        return mousePos.GetPoint(distance);
    }

}
