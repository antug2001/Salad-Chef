using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitStallManager : MonoBehaviour
{
    [HideInInspector]
    public PlayerManager playerManager;
    public GameObject players;
    public enum FruitType
    { FRUIT_TYPE_ONE, FRUIT_TYPE_TWO, FRUIT_TYPE_THREE, FRUIT_TYPE_FOUR, FRUIT_TYPE_FIVE, FRUIT_TYPE_SIX };
    [HideInInspector]
    public byte[] playerOneFruitS, playerTwoFruitS;
    public GameObject maxFruitErrorCollectionP1, maxFruitErrorCollectionP2;

    // Start is called before the first frame update
    void Start()
    {
        //necessary initialization regarding fruit stalls
        maxFruitErrorCollectionP1.SetActive(false);
        maxFruitErrorCollectionP2.SetActive(false);
        playerManager = players.GetComponent<PlayerManager>();
        playerOneFruitS = new byte[PlayerManager.MAXIMUM_FRUIT_IN_HAND_PERMITTED];
        playerTwoFruitS = new byte[PlayerManager.MAXIMUM_FRUIT_IN_HAND_PERMITTED];
        ResetPlayerFruitBasketP1();
        ResetPlayerFruitBasketP2();
    }

    public void ResetPlayerFruitBasketP1()//reseting player one fruit basket
    {
        for(int i=0;i<PlayerManager.MAXIMUM_FRUIT_IN_HAND_PERMITTED; i++)
        {
            playerOneFruitS[i]= (byte) PlayerManager.DestinationType.NONE;
            playerTwoFruitS[i] = (byte) PlayerManager.DestinationType.NONE;
        }
    }
    public void ResetPlayerFruitBasketP2()//same for player 2
    {
        for (int i = 0; i < PlayerManager.MAXIMUM_FRUIT_IN_HAND_PERMITTED; i++)
        {
            playerOneFruitS[i] = (byte)PlayerManager.DestinationType.NONE;
            playerTwoFruitS[i] = (byte)PlayerManager.DestinationType.NONE;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleFruitStallManagement()//collected fruit are put into list tracking and at the same time,possibility of collecting same fruit is eliminated
    {
        if (playerManager.playerOneDestinationIdentity >= PlayerManager.DestinationType.FRUIT_STALL_ONE && playerManager.playerOneDestinationIdentity <= PlayerManager.DestinationType.FRUIT_STALL_SIX)
        {
            if (playerManager.playerOneDestinationReached)
            {
                playerManager.playerOneDestinationReached = false;
                if (playerManager.playerOneFoodInHand < PlayerManager.MAXIMUM_FRUIT_IN_HAND_PERMITTED)
                {
                    switch (playerManager.playerOneDestinationIdentity)
                    {
                        case PlayerManager.DestinationType.FRUIT_STALL_ONE:
                            print("F11 DI " + playerManager.playerOneDestinationIdentity);
                            bool notCollectedBefore1 = true;
                            for (int i = 0; i <= playerManager.playerOneFoodInHand; i++)
                            {
                                if (playerOneFruitS[i] == (byte)PlayerManager.DestinationType.FRUIT_STALL_ONE)
                                    notCollectedBefore1 = false;
                            }
                            if (notCollectedBefore1)
                            {
                                print("here");
                                playerOneFruitS[playerManager.playerOneFoodInHand] = (byte)PlayerManager.DestinationType.FRUIT_STALL_ONE;
                                playerManager.playerOneFruitIcon1.SetActive(true);
                                playerManager.playerOneFoodInHand++;
                            }
                            else
                            {
                                print("there");
                                maxFruitErrorCollectionP1.SetActive(true);
                                Invoke("DisableErrorMessageP1", 2.0f);
                            }
                            break;
                        case PlayerManager.DestinationType.FRUIT_STALL_TWO:
                            print("F12");
                            bool notCollectedBefore2 = true;
                            for (int i = 0; i <= playerManager.playerOneFoodInHand; i++)
                            {
                                if (playerOneFruitS[i] == (byte)PlayerManager.DestinationType.FRUIT_STALL_TWO)
                                    notCollectedBefore2 = false;
                            }
                            if (notCollectedBefore2)
                            {
                                playerOneFruitS[playerManager.playerOneFoodInHand] = (byte)PlayerManager.DestinationType.FRUIT_STALL_TWO;
                                playerManager.playerOneFruitIcon2.SetActive(true);
                                playerManager.playerOneFoodInHand++;
                            }
                            else
                            {
                                maxFruitErrorCollectionP1.SetActive(true);
                                Invoke("DisableErrorMessageP1", 2.0f);
                            }
                            break;
                        case PlayerManager.DestinationType.FRUIT_STALL_THREE:
                            print("F13");
                            bool notCollectedBefore3 = true;
                            for (int i = 0; i <= playerManager.playerOneFoodInHand; i++)
                            {
                                if (playerOneFruitS[i] == (byte)PlayerManager.DestinationType.FRUIT_STALL_THREE)
                                    notCollectedBefore3 = false;
                            }
                            if (notCollectedBefore3)
                            {
                                playerOneFruitS[playerManager.playerOneFoodInHand] = (byte)PlayerManager.DestinationType.FRUIT_STALL_THREE;
                                playerManager.playerOneFruitIcon3.SetActive(true);
                                playerManager.playerOneFoodInHand++;
                            }
                            else
                            {
                                maxFruitErrorCollectionP1.SetActive(true);
                                Invoke("DisableErrorMessageP1", 2.0f);
                            }
                            break;
                        case PlayerManager.DestinationType.FRUIT_STALL_FOUR:
                            print("F14");
                            bool notCollectedBefore4 = true;
                            for (int i = 0; i <= playerManager.playerOneFoodInHand; i++)
                            {
                                if (playerOneFruitS[i] == (byte)PlayerManager.DestinationType.FRUIT_STALL_FOUR)
                                    notCollectedBefore4 = false;
                            }
                            if (notCollectedBefore4)
                            {
                                playerOneFruitS[playerManager.playerOneFoodInHand] = (byte)PlayerManager.DestinationType.FRUIT_STALL_FOUR;
                                playerManager.playerOneFruitIcon4.SetActive(true);
                                playerManager.playerOneFoodInHand++;
                            }
                            else
                            {
                                maxFruitErrorCollectionP1.SetActive(true);
                                Invoke("DisableErrorMessageP1", 2.0f);
                            }
                            break;
                        case PlayerManager.DestinationType.FRUIT_STALL_FIVE:
                            print("F15");
                            bool notCollectedBefore5 = true;
                            for (int i = 0; i <= playerManager.playerOneFoodInHand; i++)
                            {
                                if (playerOneFruitS[i] == (byte)PlayerManager.DestinationType.FRUIT_STALL_FIVE)
                                    notCollectedBefore5 = false;
                            }
                            if (notCollectedBefore5)
                            {
                                playerOneFruitS[playerManager.playerOneFoodInHand] = (byte)PlayerManager.DestinationType.FRUIT_STALL_FIVE;
                                playerManager.playerOneFruitIcon5.SetActive(true);
                                playerManager.playerOneFoodInHand++;
                            }
                            else
                            {
                                maxFruitErrorCollectionP1.SetActive(true);
                                Invoke("DisableErrorMessageP1", 2.0f);
                            }
                            break;
                        case PlayerManager.DestinationType.FRUIT_STALL_SIX:
                            print("F16");
                            bool notCollectedBefore6 = true;
                            for (int i = 0; i <= playerManager.playerOneFoodInHand; i++)
                            {
                                if (playerOneFruitS[i] == (byte)PlayerManager.DestinationType.FRUIT_STALL_SIX)
                                    notCollectedBefore6 = false;
                            }
                            if (notCollectedBefore6)
                            {
                                playerOneFruitS[playerManager.playerOneFoodInHand] = (byte)PlayerManager.DestinationType.FRUIT_STALL_SIX;
                                playerManager.playerOneFruitIcon6.SetActive(true);
                                playerManager.playerOneFoodInHand++;
                            }
                            else
                            {
                                maxFruitErrorCollectionP1.SetActive(true);
                                Invoke("DisableErrorMessageP1", 2.0f);
                            }
                            break;
                    }
                }
                else//if trying to collect the already collected fruit,error message is presented
                {
                    //error message
                    maxFruitErrorCollectionP1.SetActive(true);
                    Invoke("DisableErrorMessageP1", 2.0f);
                }
            }
        }
        //same for player2
        if (playerManager.playerTwoDestinationIdentity >= PlayerManager.DestinationType.FRUIT_STALL_ONE && playerManager.playerTwoDestinationIdentity <= PlayerManager.DestinationType.FRUIT_STALL_SIX)
        {
            if (playerManager.playerTwoDestinationReached)
            {
                playerManager.playerTwoDestinationReached = false;
                if (playerManager.playerTwoFoodInHand < PlayerManager.MAXIMUM_FRUIT_IN_HAND_PERMITTED)
                {
                    switch (playerManager.playerTwoDestinationIdentity)
                    {
                        case PlayerManager.DestinationType.FRUIT_STALL_ONE:
                            print("F11");
                            bool notCollectedBefore1 = true;
                            for (int i = 0; i <= playerManager.playerTwoFoodInHand; i++)
                            {
                                if (playerTwoFruitS[i] == (byte)PlayerManager.DestinationType.FRUIT_STALL_ONE)
                                    notCollectedBefore1 = false;
                            }
                            if (notCollectedBefore1)
                            {
                                playerTwoFruitS[playerManager.playerTwoFoodInHand] = (byte)PlayerManager.DestinationType.FRUIT_STALL_ONE;
                                playerManager.playerTwoFruitIcon1.SetActive(true);
                                playerManager.playerTwoFoodInHand++;
                            }
                            else
                            {
                                maxFruitErrorCollectionP2.SetActive(true);
                                Invoke("DisableErrorMessageP2", 2.0f);
                            }
                            break;
                        case PlayerManager.DestinationType.FRUIT_STALL_TWO:
                            print("F12");
                            bool notCollectedBefore2 = true;
                            for (int i = 0; i <= playerManager.playerTwoFoodInHand; i++)
                            {
                                if (playerTwoFruitS[i] == (byte)PlayerManager.DestinationType.FRUIT_STALL_TWO)
                                    notCollectedBefore2 = false;
                            }
                            if (notCollectedBefore2)
                            {
                                playerTwoFruitS[playerManager.playerTwoFoodInHand] = (byte)PlayerManager.DestinationType.FRUIT_STALL_TWO;
                                playerManager.playerTwoFruitIcon2.SetActive(true);
                                playerManager.playerTwoFoodInHand++;
                            }
                            else
                            {
                                maxFruitErrorCollectionP2.SetActive(true);
                                Invoke("DisableErrorMessageP2", 2.0f);
                            }
                            break;
                        case PlayerManager.DestinationType.FRUIT_STALL_THREE:
                            print("F13");
                            bool notCollectedBefore3 = true;
                            for (int i = 0; i <= playerManager.playerTwoFoodInHand; i++)
                            {
                                if (playerTwoFruitS[i] == (byte)PlayerManager.DestinationType.FRUIT_STALL_THREE)
                                    notCollectedBefore3 = false;
                            }
                            if (notCollectedBefore3)
                            {
                                playerTwoFruitS[playerManager.playerTwoFoodInHand] = (byte)PlayerManager.DestinationType.FRUIT_STALL_THREE;
                                playerManager.playerTwoFruitIcon3.SetActive(true);
                                playerManager.playerTwoFoodInHand++;
                            }
                            else
                            {
                                maxFruitErrorCollectionP2.SetActive(true);
                                Invoke("DisableErrorMessageP2", 2.0f);
                            }
                            break;
                        case PlayerManager.DestinationType.FRUIT_STALL_FOUR:
                            print("F14");
                            bool notCollectedBefore4 = true;
                            for (int i = 0; i <= playerManager.playerTwoFoodInHand; i++)
                            {
                                if (playerTwoFruitS[i] == (byte)PlayerManager.DestinationType.FRUIT_STALL_FOUR)
                                    notCollectedBefore4 = false;
                            }
                            if (notCollectedBefore4)
                            {
                                playerTwoFruitS[playerManager.playerTwoFoodInHand] = (byte)PlayerManager.DestinationType.FRUIT_STALL_FOUR;
                                playerManager.playerTwoFruitIcon4.SetActive(true);
                                playerManager.playerTwoFoodInHand++;
                            }
                            else
                            {
                                maxFruitErrorCollectionP2.SetActive(true);
                                Invoke("DisableErrorMessageP2", 2.0f);
                            }
                            break;
                        case PlayerManager.DestinationType.FRUIT_STALL_FIVE:
                            print("F15");
                            bool notCollectedBefore5 = true;
                            for (int i = 0; i <= playerManager.playerTwoFoodInHand; i++)
                            {
                                if (playerTwoFruitS[i] == (byte)PlayerManager.DestinationType.FRUIT_STALL_FIVE)
                                    notCollectedBefore5 = false;
                            }
                            if (notCollectedBefore5)
                            {
                                playerTwoFruitS[playerManager.playerTwoFoodInHand] = (byte)PlayerManager.DestinationType.FRUIT_STALL_FIVE;
                                playerManager.playerTwoFruitIcon5.SetActive(true);
                                playerManager.playerTwoFoodInHand++;
                            }
                            else
                            {
                                maxFruitErrorCollectionP2.SetActive(true);
                                Invoke("DisableErrorMessageP2", 2.0f);
                            }
                            break;
                        case PlayerManager.DestinationType.FRUIT_STALL_SIX:
                            print("F16");
                            bool notCollectedBefore6 = true;
                            for (int i = 0; i <= playerManager.playerTwoFoodInHand; i++)
                            {
                                if (playerTwoFruitS[i] == (byte)PlayerManager.DestinationType.FRUIT_STALL_SIX)
                                    notCollectedBefore6 = false;
                            }
                            if (notCollectedBefore6)
                            {
                                playerTwoFruitS[playerManager.playerTwoFoodInHand] = (byte)PlayerManager.DestinationType.FRUIT_STALL_SIX;
                                playerManager.playerTwoFruitIcon6.SetActive(true);
                                playerManager.playerTwoFoodInHand++;
                            }
                            else
                            {
                                maxFruitErrorCollectionP2.SetActive(true);
                                Invoke("DisableErrorMessageP2", 2.0f);
                            }
                            break;
                    }
                }
                else
                {
                    //error message
                    maxFruitErrorCollectionP2.SetActive(true);
                    Invoke("DisableErrorMessageP2", 2.0f);

                }
            }
        }
    }

    void DisableErrorMessageP1()
    {
        maxFruitErrorCollectionP1.SetActive(false);
    }
    void DisableErrorMessageP2()
    {
        maxFruitErrorCollectionP2.SetActive(false);
    }

}
