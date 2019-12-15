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

    // Start is called before the first frame update
    void Start()
    {
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
                if (playerManager.playerOneFoodInHand == 0)
                {
                    errorMessageNothingToTrashP1.SetActive(true);
                    Invoke("DisableErrorMessageP1", 2.0f);
                    print("trash error");
                }
                else
                {
                    print("trashing " + playerManager.playerOneFoodInHand);
                    playerManager.playerOneFoodInHand = 0;
                    playerManager.DisableAllFruitIconsP1();
                    fruitStallManager.ResetPlayerFruitBasketP1();
                }
            }
        }

        if (playerManager.playerTwoDestinationIdentity == PlayerManager.DestinationType.TRASH_CAN_TWO)
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
