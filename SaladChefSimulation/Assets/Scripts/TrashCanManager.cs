using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanManager : MonoBehaviour
{

    private PlayerManager playerManager;
    public GameObject players;
    public GameObject fruitStalls;
    private FruitStallManager fruitStallManager;
    public GameObject errorMessageNothingToTrashP1, errorMessageNothingToTrashP2;
    private MiscelleniousManager miscManager;
    public GameObject misc;

    // Start is called before the first frame update
    void Start()
    {
        //necessary initialization regarding trash can
        miscManager = misc.GetComponent<MiscelleniousManager>();
        fruitStallManager = fruitStalls.GetComponent<FruitStallManager>();
        playerManager = players.GetComponent<PlayerManager>();
        errorMessageNothingToTrashP1.SetActive(false);
        errorMessageNothingToTrashP2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleTrashCansFeatures()
    {
        if (playerManager.playerOneDestinationIdentity == PlayerManager.DestinationType.TRASH_CAN_ONE)
        {
            if (playerManager.playerOneDestinationReached)
            {
                playerManager.playerOneDestinationReached = false;
                if (playerManager.playerOneFoodInHand == 0)//if nothing to trash,error message displayed
                {
                    errorMessageNothingToTrashP1.SetActive(true);
                    Invoke("DisableErrorMessageP1", 2.0f);
                    print("trash error");
                }
                else//after trashing,necessary reinitialization
                {
                    print("trashing " + playerManager.playerOneFoodInHand);
                    miscManager.playerOneScore -= 100;
                    playerManager.playerOneFoodInHand = 0;
                    print("1111111111");
                    playerManager.DisableAllFruitIconsP1();
                    fruitStallManager.ResetPlayerFruitBasketP1();
                }
            }
        }

        if (playerManager.playerTwoDestinationIdentity == PlayerManager.DestinationType.TRASH_CAN_TWO)//just same as player one
        {
            if (playerManager.playerTwoDestinationReached)
            {
                playerManager.playerTwoDestinationReached = false;
                if (playerManager.playerTwoFoodInHand == 0)
                {
                    errorMessageNothingToTrashP2.SetActive(true);
                    Invoke("DisableErrorMessageP2", 2.0f);
                }
                else
                {
                    miscManager.playerTwoScore -= 100;
                    playerManager.playerTwoFoodInHand = 0;
                    playerManager.DisableAllFruitIconsP2();
                    fruitStallManager.ResetPlayerFruitBasketP2();
                }
            }
        }
    }

    void DisableErrorMessageP1()
    {
        errorMessageNothingToTrashP1.SetActive(false);
    }
    void DisableErrorMessageP2()
    {
        errorMessageNothingToTrashP2.SetActive(false);
    }

}
