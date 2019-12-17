using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppingBoardManager : MonoBehaviour
{
    [HideInInspector]
    public bool choppingDonePlayerOne=false, choppingDonePlayerTwo = false;
    private PlayerManager playerManager;
    public GameObject players;
    public GameObject fruitStalls;
    private FruitStallManager fruitStallManager;
    public GameObject errorMessageNothingToChopP1, errorMessageNothingToChopP2;
    public GameObject healthBarChopP1, healthBarChopP2;
    private float initialLengthP1=0, initialLengthP2 = 0, finalLength =0;
    [HideInInspector]
    public bool isChoppingPlayerOne = false, isChoppingPlayerTwo= false;

    // Start is called before the first frame update
    void Start()
    {
        //necessay initialization done
        playerManager = players.GetComponent<PlayerManager>();
        fruitStallManager = fruitStalls.GetComponent<FruitStallManager>();
        errorMessageNothingToChopP1.SetActive(false);
        errorMessageNothingToChopP2.SetActive(false);
        initialLengthP1 = healthBarChopP1.transform.localScale.x;
        initialLengthP2 = healthBarChopP2.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleChopperTablesFeatures()//after reaching chopping table, coroutines are fired to size input.If no fruit in basket,error message is provided.
    {
        if (playerManager.playerOneDestinationIdentity == PlayerManager.DestinationType.CHOPPING_BOARD_ONE)
        {
            if (playerManager.playerOneDestinationReached)
            {
                playerManager.playerOneDestinationReached = false;
                if (playerManager.playerOneFoodInHand == 0)
                {
                    errorMessageNothingToChopP1.SetActive(true);
                    Invoke("DisableErrorMessageP1", 2.0f);
                    print("chop error");
                }
                else
                {
                    print("chopping " + playerManager.playerOneFoodInHand);
                    //playerManager.playerOneFoodInHand = 0;
                    //playerManager.DisableAllFruitIconsP1();
                    //fruitStallManager.ResetPlayerFruitBasketP1();
                    startTime = Time.time;
                    isChoppingPlayerOne = true;
                    StartCoroutine("CompleteChoppingProcessP1");
                }
            }
        }

        if (playerManager.playerTwoDestinationIdentity == PlayerManager.DestinationType.CHOPPING_BOARD_TWO)
        {
            if (playerManager.playerTwoDestinationReached)
            {
                playerManager.playerTwoDestinationReached = false;
                if (playerManager.playerTwoFoodInHand == 0)
                {
                    errorMessageNothingToChopP2.SetActive(true);
                    Invoke("DisableErrorMessageP2", 2.0f);
                    print("chop error 2");
                }
                else
                {
                    print("chopping2 " + playerManager.playerTwoFoodInHand);
                    //playerManager.playerTwoFoodInHand = 0;
                    //playerManager.DisableAllFruitIconsP2();
                    //fruitStallManager.ResetPlayerFruitBasketP2();
                    startTime = Time.time;
                    isChoppingPlayerTwo = true;
                    StartCoroutine("CompleteChoppingProcessP2");
                }
            }
        }
    }
    private float duration = 5.0f;
    private float startTime;
    IEnumerator CompleteChoppingProcessP1()//after seizing input for the duration,input control regained
    {
        float t =0;
        while (t < 1.0f)
        {
            t = (Time.time - startTime) / duration;
           // print(""+ playerManager.isMovementAllowedPlayerOne);
            healthBarChopP1.transform.localScale = new Vector3(initialLengthP1- initialLengthP1 * t, healthBarChopP1.transform.localScale.y, healthBarChopP1.transform.localScale.z);
            yield return null;// new WaitForSeconds(duration);
        }
        isChoppingPlayerOne = false;
        choppingDonePlayerOne = true;
        healthBarChopP1.transform.localScale = new Vector3(initialLengthP1 , healthBarChopP1.transform.localScale.y, healthBarChopP1.transform.localScale.z);
    }

    IEnumerator CompleteChoppingProcessP2()//same for second player
    {
        float t = 0;
        while (t < 1.0f)
        {
            t = (Time.time - startTime) / duration;
           // print("" + t);
            healthBarChopP2.transform.localScale = new Vector3(initialLengthP2 - initialLengthP2 * t, healthBarChopP2.transform.localScale.y,
                                                               healthBarChopP2.transform.localScale.z);
            yield return null;// new WaitForSeconds(duration);
        }
        isChoppingPlayerTwo = false;
        choppingDonePlayerTwo = true;
        healthBarChopP2.transform.localScale = new Vector3(initialLengthP2, healthBarChopP2.transform.localScale.y,
                                                               healthBarChopP2.transform.localScale.z);
    }
    void DisableErrorMessageP1()//error message withdrawn
    {
        errorMessageNothingToChopP1.SetActive(false);
    }
    void DisableErrorMessageP2()
    {
        errorMessageNothingToChopP2.SetActive(false);
    }

}
