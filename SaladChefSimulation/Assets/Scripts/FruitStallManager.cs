using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitStallManager : MonoBehaviour
{

    private PlayerManager playerManager;
    public GameObject players;
    public enum FruitType
    {FRUIT_TYPE_ONE, FRUIT_TYPE_TWO, FRUIT_TYPE_THREE, FRUIT_TYPE_FOUR, FRUIT_TYPE_FIVE, FRUIT_TYPE_SIX };
    public byte[] playerOneFruitS, playerTwoFruitS;
    public GameObject maxFruitErrorCollectionP1, maxFruitErrorCollectionP2;
   
    // Start is called before the first frame update
    void Start()
    {
        maxFruitErrorCollectionP1.SetActive(false);
        maxFruitErrorCollectionP2.SetActive(false);
        playerManager = players.GetComponent<PlayerManager>();
        playerOneFruitS = new byte[PlayerManager.MAXIMUM_FRUIT_IN_HAND_PERMITTED] ;
        playerTwoFruitS = new byte[PlayerManager.MAXIMUM_FRUIT_IN_HAND_PERMITTED];
        for(int i=0;i< PlayerManager.MAXIMUM_FRUIT_IN_HAND_PERMITTED; i++)
        {
            playerOneFruitS[i]= (byte)PlayerManager.DestinationType.NONE;
            playerTwoFruitS[i] = (byte)PlayerManager.DestinationType.NONE;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleFruitStallManagement()
    {
        if(playerManager.playerOneDestinationReached)
        {
            playerManager.playerOneDestinationReached = false;
            if (playerManager.playerOneFoodInHand < PlayerManager.MAXIMUM_FRUIT_IN_HAND_PERMITTED)
            {
                switch (playerManager.playerOneDestinationIdentity)
                {
                    case PlayerManager.DestinationType.FRUIT_STALL_ONE:
                        print("F11");
                        playerOneFruitS[playerManager.playerOneFoodInHand] = (byte)PlayerManager.DestinationType.FRUIT_STALL_ONE;
                        playerManager.playerOneFruitIcon1.SetActive(true);
                        break;
                    case PlayerManager.DestinationType.FRUIT_STALL_TWO:
                        print("F12");
                        playerOneFruitS[playerManager.playerOneFoodInHand] = (byte)PlayerManager.DestinationType.FRUIT_STALL_TWO;
                        playerManager.playerOneFruitIcon2.SetActive(true);
                        break;
                    case PlayerManager.DestinationType.FRUIT_STALL_THREE:
                        print("F13");
                        playerOneFruitS[playerManager.playerOneFoodInHand] = (byte)PlayerManager.DestinationType.FRUIT_STALL_THREE;
                        playerManager.playerOneFruitIcon3.SetActive(true);
                        break;
                    case PlayerManager.DestinationType.FRUIT_STALL_FOUR:
                        print("F14");
                        playerOneFruitS[playerManager.playerOneFoodInHand] = (byte)PlayerManager.DestinationType.FRUIT_STALL_FOUR;
                        playerManager.playerOneFruitIcon4.SetActive(true);
                        break;
                    case PlayerManager.DestinationType.FRUIT_STALL_FIVE:
                        print("F15");
                        playerOneFruitS[playerManager.playerOneFoodInHand] = (byte)PlayerManager.DestinationType.FRUIT_STALL_FIVE;
                        playerManager.playerOneFruitIcon5.SetActive(true);
                        break;
                    case PlayerManager.DestinationType.FRUIT_STALL_SIX:
                        print("F16");
                        playerOneFruitS[playerManager.playerOneFoodInHand] = (byte)PlayerManager.DestinationType.FRUIT_STALL_SIX;
                        playerManager.playerOneFruitIcon6.SetActive(true);
                        break;
                }
                playerManager.playerOneFoodInHand++;
            }
            else
            {
                //error message
                maxFruitErrorCollectionP1.SetActive(true);
                Invoke("DisableErrorMessageP1", 2.0f);
            }            
        }

        if (playerManager.playerTwoDestinationReached)
        {
            playerManager.playerTwoDestinationReached = false;
            if (playerManager.playerTwoFoodInHand < PlayerManager.MAXIMUM_FRUIT_IN_HAND_PERMITTED)
            {
                switch (playerManager.playerTwoDestinationIdentity)
                {
                    case PlayerManager.DestinationType.FRUIT_STALL_ONE:
                        print("F11");
                        playerTwoFruitS[playerManager.playerOneFoodInHand] = (byte)PlayerManager.DestinationType.FRUIT_STALL_ONE;
                        playerManager.playerTwoFruitIcon1.SetActive(true);
                        break;
                    case PlayerManager.DestinationType.FRUIT_STALL_TWO:
                        print("F12");
                        playerTwoFruitS[playerManager.playerOneFoodInHand] = (byte)PlayerManager.DestinationType.FRUIT_STALL_TWO;
                        playerManager.playerTwoFruitIcon2.SetActive(true);
                        break;
                    case PlayerManager.DestinationType.FRUIT_STALL_THREE:
                        print("F13");
                        playerTwoFruitS[playerManager.playerOneFoodInHand] = (byte)PlayerManager.DestinationType.FRUIT_STALL_THREE;
                        playerManager.playerTwoFruitIcon3.SetActive(true);
                        break;
                    case PlayerManager.DestinationType.FRUIT_STALL_FOUR:
                        print("F14");
                        playerTwoFruitS[playerManager.playerOneFoodInHand] = (byte)PlayerManager.DestinationType.FRUIT_STALL_FOUR;
                        playerManager.playerTwoFruitIcon4.SetActive(true);
                        break;
                    case PlayerManager.DestinationType.FRUIT_STALL_FIVE:
                        print("F15");
                        playerTwoFruitS[playerManager.playerOneFoodInHand] = (byte)PlayerManager.DestinationType.FRUIT_STALL_FIVE;
                        playerManager.playerTwoFruitIcon5.SetActive(true);
                        break;
                    case PlayerManager.DestinationType.FRUIT_STALL_SIX:
                        print("F16");
                        playerTwoFruitS[playerManager.playerOneFoodInHand] = (byte)PlayerManager.DestinationType.FRUIT_STALL_SIX;
                        playerManager.playerTwoFruitIcon6.SetActive(true);
                        break;
                }
                playerManager.playerTwoFoodInHand++;
            }
            else
            {
                //error message
                maxFruitErrorCollectionP2.SetActive(true);
                Invoke("DisableErrorMessageP2", 2.0f);
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
