using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public GameObject playerOne;
    public GameObject playerTwo;
    private float speedPlayerOne = 3.0f;
    private float speedPlayerTwo = 3.0f;
    public GameObject playerOneFruitIcon1, playerOneFruitIcon2, playerOneFruitIcon3, playerOneFruitIcon4, playerOneFruitIcon5, playerOneFruitIcon6;
    public GameObject playerTwoFruitIcon1, playerTwoFruitIcon2, playerTwoFruitIcon3, playerTwoFruitIcon4, playerTwoFruitIcon5, playerTwoFruitIcon6;

    [HideInInspector]
    public Transform targetPlayerOnePosition;
    [HideInInspector]
    public Transform targetPlayerTwoPosition;
    [HideInInspector]
    public bool isMovementAllowedPlayerOne = false, playerOneDestinationReached = false;
    [HideInInspector]
    public bool isMovementAllowedPlayerTwo = false, playerTwoDestinationReached = false;
    [HideInInspector]
    public enum DestinationType { FRUIT_STALL_ONE, FRUIT_STALL_TWO, FRUIT_STALL_THREE, FRUIT_STALL_FOUR, FRUIT_STALL_FIVE, FRUIT_STALL_SIX,
        CUSTOMER_ONE, CUSTOMER_TWO, CUSTOMER_THREE, CUSTOMER_FOUR, CUSTOMER_FIVE,
        CHOPPING_BOARD_ONE, CHOPPING_BOARD_TWO, TRASH_CAN_ONE, TRASH_CAN_TWO, PLATE_TABLES, NONE };
    [HideInInspector]
    public DestinationType playerOneDestinationIdentity, playerTwoDestinationIdentity;

    //[HideInInspector]
    //public enum PlayerType { PLAYER_ONE, PLAYER_TWO, NONE };
    //[HideInInspector]
    //public PlayerType playerIdentity;
    [HideInInspector]
    public byte playerOneFoodInHand, playerTwoFoodInHand;

    public const byte MAXIMUM_FRUIT_IN_HAND_PERMITTED = 3;

    void Start()
    {
        DisableAllFruitIconsP1();
        DisableAllFruitIconsP2();
    }

    public void DisableAllFruitIconsP1()
    {
        playerOneFruitIcon1.SetActive(false);
        playerOneFruitIcon2.SetActive(false);
        playerOneFruitIcon3.SetActive(false);
        playerOneFruitIcon4.SetActive(false);
        playerOneFruitIcon5.SetActive(false);
        playerOneFruitIcon6.SetActive(false);
    }
    public void DisableAllFruitIconsP2()
    {
        playerTwoFruitIcon1.SetActive(false);
        playerTwoFruitIcon2.SetActive(false);
        playerTwoFruitIcon3.SetActive(false);
        playerTwoFruitIcon4.SetActive(false);
        playerTwoFruitIcon5.SetActive(false);
        playerTwoFruitIcon6.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        HandlePlayerOneMovement(playerOne.transform,targetPlayerOnePosition);
        HandlePlayerTwoMovement(playerTwo.transform, targetPlayerTwoPosition);
    }

    private void HandlePlayerOneMovement(Transform currentTransform,Transform targetTransform)
    {
        if (!isMovementAllowedPlayerOne || targetTransform == null)
            return;
        float step = speedPlayerOne * Time.deltaTime;
        currentTransform.position = Vector3.MoveTowards(currentTransform.position, targetTransform.position, step);
        if(currentTransform.position == targetTransform.position)
        {
            print("reached one");
            playerOneDestinationReached = true;
            targetPlayerOnePosition = targetTransform = null;
           // if(playerOneDestinationIdentity != PlayerManager.DestinationType.CHOPPING_BOARD_ONE)
                isMovementAllowedPlayerOne = false;
        }
    }

    private void HandlePlayerTwoMovement(Transform currentTransform, Transform targetTransform)
    {
        if (!isMovementAllowedPlayerTwo || targetTransform == null)
            return;
        float step = speedPlayerTwo * Time.deltaTime;
        currentTransform.position = Vector3.MoveTowards(currentTransform.position, targetTransform.position, step);
        if (currentTransform.position == targetTransform.position)
        {
            print("reached two");
            playerTwoDestinationReached = true;
            targetPlayerTwoPosition = targetTransform = null;
            //if(playerTwoDestinationIdentity != PlayerManager.DestinationType.CHOPPING_BOARD_TWO)
                isMovementAllowedPlayerTwo = false;
        }
    }

}
