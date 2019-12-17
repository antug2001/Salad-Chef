using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    private PlateTableManager plateTableManager;
    private FruitStallManager fruitManager;
    private PlayerManager playerManager;
    private MiscelleniousManager miscManager;
    private ChoppingBoardManager choppingBoardManager;
    public GameObject players;
    public GameObject misc;
    public GameObject fruit;
    public GameObject plate;
    public GameObject chopBoard;
    public GameObject errorMessageWrongDeliveryP1, errorMessageWrongDeliveryP2, duccessfulDeliveryP1, duccessfulDeliveryP2;
    const int NO_OF_TOTAL_CUSTOMER = 5;
    const int TOTAL_FRUIT_TYPE = 6;
    const int NO_OF_TOTAL_FOOD = 3;
    const float MINIMUM_TIME = 45.0F;
    const float MAXIMUM_TIME = 90.0F;
    public GameObject[] fruitObjectIcon1;
    public GameObject[]fruitObjectIcon2;
    public GameObject[]fruitObjectIcon3;
    public GameObject[]fruitObjectIcon4;
    public GameObject[]fruitObjectIcon5;
    GameObject [,] fruitObjectIcon = new GameObject[NO_OF_TOTAL_CUSTOMER, TOTAL_FRUIT_TYPE];
    float[] customerWaitTime, customerWaitTimer;
    int[,] customerFruitRequirement;

    // Start is called before the first frame update
    void Start()
    {
        //necessary initialization specially customer fruit requirement randomized with time limit
        errorMessageWrongDeliveryP1.SetActive(false);
        errorMessageWrongDeliveryP2.SetActive(false);
        duccessfulDeliveryP1.SetActive(false); 
        duccessfulDeliveryP2.SetActive(false);
        plateTableManager = plate.GetComponent<PlateTableManager>();
        fruitManager = fruit.GetComponent<FruitStallManager>();
        playerManager = players.GetComponent<PlayerManager>();
        miscManager = misc.GetComponent<MiscelleniousManager>();
        choppingBoardManager = chopBoard.GetComponent<ChoppingBoardManager>();
        //print("s "+ fruitObjectIcon1[0]);
        //print("d "+ fruitObjectIcon[0, 0]);
        initialLengthC1 = healthBarChopC1.transform.localScale.x;
        initialLengthC2 = healthBarChopC2.transform.localScale.x;
        initialLengthC3 = healthBarChopC3.transform.localScale.x;
        initialLengthC4 = healthBarChopC4.transform.localScale.x;
        initialLengthC5 = healthBarChopC5.transform.localScale.x;
        for (int i = 0; i < TOTAL_FRUIT_TYPE; i++)
        {
           // print("length " + fruitObjectIcon.Length + " " + fruitObjectIcon1);
            fruitObjectIcon[0, i] = fruitObjectIcon1[i];
            fruitObjectIcon[1, i] = fruitObjectIcon2[i];
            fruitObjectIcon[2, i] = fruitObjectIcon3[i];
            fruitObjectIcon[3, i] = fruitObjectIcon4[i];
            fruitObjectIcon[4, i] = fruitObjectIcon5[i];
        }
        //print("length " + fruitObjectIcon1.Length );
        DisableAllCustomerFoodIcons();
        customerWaitTime = new float[NO_OF_TOTAL_CUSTOMER];
        customerWaitTimer = new float[NO_OF_TOTAL_CUSTOMER];
        customerFruitRequirement = new int[NO_OF_TOTAL_CUSTOMER,NO_OF_TOTAL_FOOD];
        InitiateCustomerWaitTime();
        InitiateCustomerFruitRequirement();
       // DisableAllCustomerFoodIcons();
    }
    void DisableAllCustomerFoodIcons()//icons for fruit of customer are reset
    {
        for (int i = 0; i < NO_OF_TOTAL_CUSTOMER; i++)
        {
            for (int j = 0; j < TOTAL_FRUIT_TYPE; j++)
            {
                fruitObjectIcon[i, j].SetActive(false);
               //fruitObjectIcon2[0].SetActive(false);
            }
        }
    }
    void InitiateCustomerWaitTime()//coroutine fired for customer's waiting time indication bar
    {
        for(int i=0;i< NO_OF_TOTAL_CUSTOMER; i++)
        {
            customerWaitTime[i]=Random.Range(MINIMUM_TIME, MAXIMUM_TIME);
            customerWaitTimer[i]= Time.time;
            switch(i)
            {
                case 0:
                    StartCoroutine("CompleteTimerProcessC1", i);
                    break;
                case 1:
                    StartCoroutine("CompleteTimerProcessC2", i);
                    break;
                case 2:
                    StartCoroutine("CompleteTimerProcessC3", i);
                    break;
                case 3:
                    StartCoroutine("CompleteTimerProcessC4", i);
                    break;
                case 4:
                    StartCoroutine("CompleteTimerProcessC5", i);
                    break;
            }
            
            //print("customer "+i+" time " + customerWaitTime[i]);
        }
    }
    public GameObject healthBarChopC1, healthBarChopC2, healthBarChopC3, healthBarChopC4, healthBarChopC5;
    private float initialLengthC1, initialLengthC2, initialLengthC3, initialLengthC4, initialLengthC5;
    IEnumerator CompleteTimerProcessC1(int i)//yielding inside while to allow other process working simultaneously
    {
        float t = 0;
        while (t < 1.0f)
        {
            t = (Time.time - customerWaitTimer[i]) / customerWaitTime[i];
            //print("" + playerManager.isMovementAllowedPlayerOne);
            healthBarChopC1.transform.localScale = new Vector3(initialLengthC1 - initialLengthC1 * t, healthBarChopC1.transform.localScale.y, healthBarChopC1.transform.localScale.z);
            yield return null;// new WaitForSeconds(duration);
        }
        //isChoppingPlayerOne = false;
        healthBarChopC1.transform.localScale = new Vector3(initialLengthC1, healthBarChopC1.transform.localScale.y, healthBarChopC1.transform.localScale.z);
    }
    IEnumerator CompleteTimerProcessC2(int i)
    {
        float t = 0;
        while (t < 1.0f)
        {
            t = (Time.time - customerWaitTimer[i]) / customerWaitTime[i];
            //print("" + playerManager.isMovementAllowedPlayerOne);
            healthBarChopC2.transform.localScale = new Vector3(initialLengthC2 - initialLengthC2 * t, healthBarChopC2.transform.localScale.y, healthBarChopC2.transform.localScale.z);
            yield return null;// new WaitForSeconds(duration);
        }
        //isChoppingPlayerOne = false;
        healthBarChopC2.transform.localScale = new Vector3(initialLengthC2, healthBarChopC2.transform.localScale.y, healthBarChopC2.transform.localScale.z);
    }
    IEnumerator CompleteTimerProcessC3(int i)
    {
        float t = 0;
        while (t < 1.0f)
        {
            t = (Time.time - customerWaitTimer[i]) / customerWaitTime[i];
            //print("" + playerManager.isMovementAllowedPlayerOne);
            healthBarChopC3.transform.localScale = new Vector3(initialLengthC3 - initialLengthC3 * t, healthBarChopC3.transform.localScale.y, healthBarChopC3.transform.localScale.z);
            yield return null;// new WaitForSeconds(duration);
        }
        //isChoppingPlayerOne = false;
        healthBarChopC3.transform.localScale = new Vector3(initialLengthC3, healthBarChopC3.transform.localScale.y, healthBarChopC3.transform.localScale.z);
    }
    IEnumerator CompleteTimerProcessC4(int i)
    {
        float t = 0;
        while (t < 1.0f)
        {
            t = (Time.time - customerWaitTimer[i]) / customerWaitTime[i];
            //print("" + playerManager.isMovementAllowedPlayerOne);
            healthBarChopC4.transform.localScale = new Vector3(initialLengthC4 - initialLengthC4 * t, healthBarChopC4.transform.localScale.y, healthBarChopC4.transform.localScale.z);
            yield return null;// new WaitForSeconds(duration);
        }
        //isChoppingPlayerOne = false;
        healthBarChopC4.transform.localScale = new Vector3(initialLengthC4, healthBarChopC4.transform.localScale.y, healthBarChopC4.transform.localScale.z);
    }
    IEnumerator CompleteTimerProcessC5(int i)
    {
        float t = 0;
        while (t < 1.0f)
        {
            t = (Time.time - customerWaitTimer[i]) / customerWaitTime[i];
            //print("" + playerManager.isMovementAllowedPlayerOne);
            healthBarChopC5.transform.localScale = new Vector3(initialLengthC5 - initialLengthC5 * t, healthBarChopC5.transform.localScale.y, healthBarChopC5.transform.localScale.z);
            yield return null;// new WaitForSeconds(duration);
        }
        //isChoppingPlayerOne = false;
        healthBarChopC5.transform.localScale = new Vector3(initialLengthC5, healthBarChopC5.transform.localScale.y, healthBarChopC5.transform.localScale.z);
    }
    void InitiateCustomerFruitRequirement()
    {
        for (int i = 0; i < NO_OF_TOTAL_CUSTOMER; i++)
        {
            GenerateUniqueValue(i);
        }
    }
    void GenerateUniqueValue( int i )//making sure that fruit requirement list for customer is unique
    {
        int foodCounter = 0;
        while (true)
        {
            int val = Random.Range(0, TOTAL_FRUIT_TYPE);
            bool noRepeat = true;
            for (int k = 0; k < foodCounter; k++)
            {
                if (customerFruitRequirement[i, k] == val)
                    noRepeat = false;
            }
            if (noRepeat)
            {
                customerFruitRequirement[i, foodCounter] = val;
                fruitObjectIcon[i, customerFruitRequirement[i, foodCounter]].SetActive(true);
                foodCounter++;
               // print("customer " + i + " foodcounter " + foodCounter + " value " + val);
            }
            //else
            //    print("REPEAT");
            if (foodCounter == NO_OF_TOTAL_FOOD)
                break;
        }
    }
    // Update is called once per frame
    void Update()//iterating through customer's fruit and time bound generation and tracking
    {
        for (int i = 0; i < NO_OF_TOTAL_CUSTOMER; i++)
        {
            if(Time.time- customerWaitTimer[i]> customerWaitTime[i])
            {
                customerWaitTime[i] = Random.Range(MINIMUM_TIME, MAXIMUM_TIME);
                customerWaitTimer[i] = Time.time;
                switch (i)
                {
                    case 0:
                        StartCoroutine("CompleteTimerProcessC1", i);
                        break;
                    case 1:
                        StartCoroutine("CompleteTimerProcessC2", i);
                        break;
                    case 2:
                        StartCoroutine("CompleteTimerProcessC3", i);
                        break;
                    case 3:
                        StartCoroutine("CompleteTimerProcessC4", i);
                        break;
                    case 4:
                        StartCoroutine("CompleteTimerProcessC5", i);
                        break;
                }
                for (int j = 0; j < TOTAL_FRUIT_TYPE; j++)
                {
                    fruitObjectIcon[i, j].SetActive(false);
                }
                GenerateUniqueValue(i);
                miscManager.playerOneScore -= 100;
                miscManager.playerTwoScore -= 100;
            }
        }
    }

    public void HandleCustomerActivities()
    {
        //if player reaches to any of the customer
        if (playerManager.playerOneDestinationIdentity == PlayerManager.DestinationType.CUSTOMER_ONE
            || playerManager.playerOneDestinationIdentity == PlayerManager.DestinationType.CUSTOMER_TWO
            || playerManager.playerOneDestinationIdentity == PlayerManager.DestinationType.CUSTOMER_THREE
            || playerManager.playerOneDestinationIdentity == PlayerManager.DestinationType.CUSTOMER_FOUR
            || playerManager.playerOneDestinationIdentity == PlayerManager.DestinationType.CUSTOMER_FIVE)
        {   
            if (playerManager.playerOneDestinationReached)
            {
                playerManager.playerOneDestinationReached = false;
                bool wrongDelivery = false;
                int wrongDeliveryCounter = 0;                
                for (int i=0;i< NO_OF_TOTAL_FOOD; i++)//how many mismatch between fruit collected and requirement are there is calculated
                {
                    print("player fruit collection " + fruitManager.playerOneFruitS[i]);
                    print(" customer fruit requirement "+customerFruitRequirement[(int)playerManager.playerOneDestinationIdentity - TOTAL_FRUIT_TYPE, i]);
                    if(
                            !(fruitManager.playerOneFruitS[i]== (byte)customerFruitRequirement[(int)playerManager.playerOneDestinationIdentity - TOTAL_FRUIT_TYPE, 0]
                            ||
                            fruitManager.playerOneFruitS[i] == (byte)customerFruitRequirement[(int)playerManager.playerOneDestinationIdentity - TOTAL_FRUIT_TYPE, 1]
                            ||
                            fruitManager.playerOneFruitS[i] == (byte)customerFruitRequirement[(int)playerManager.playerOneDestinationIdentity - TOTAL_FRUIT_TYPE, 2])
                        )
                    {
                        wrongDelivery = true;
                        wrongDeliveryCounter++;
                    }
                }
                if (!choppingBoardManager.choppingDonePlayerOne)//if player doesn't reach chopping table before fruit submission to customer,invalid delivery
                    wrongDelivery = true;               
                choppingBoardManager.choppingDonePlayerOne = false;
                if (!plateTableManager.plateCollectedPlayerOne)//if player doesn't collect plates  before fruit submission to customer,invalid delivery
                    wrongDelivery = true;
                plateTableManager.plateCollectedPlayerOne = false;
                if (wrongDelivery)//wrong delivery message shown and score deducted
                {
                    errorMessageWrongDeliveryP1.SetActive(true);
                    Invoke("DisableErrorMessageP1", 2.0f);
                    print("delivery error");
                    miscManager.playerOneScore -= 100 * wrongDeliveryCounter;
                }
                else//on successful delivery,score recalculated and remaining time added to player's timer
                {
                    duccessfulDeliveryP1.SetActive(true);
                    Invoke("SuccessfulDeliveryMessageP1", 2.0f);
                    miscManager.playerOneScore += 500;
                    miscManager.playerOneTime += (customerWaitTime[(int)playerManager.playerOneDestinationIdentity - TOTAL_FRUIT_TYPE] - (Time.time - customerWaitTimer[(int)playerManager.playerOneDestinationIdentity - TOTAL_FRUIT_TYPE]));
                    miscManager.playerOneScore+=(int)(100*(customerWaitTime[(int)playerManager.playerOneDestinationIdentity - TOTAL_FRUIT_TYPE] - (Time.time - customerWaitTimer[(int)playerManager.playerOneDestinationIdentity - TOTAL_FRUIT_TYPE])));  
                }
                playerManager.playerOneFoodInHand = 0;
                print("222222222222222");
                playerManager.DisableAllFruitIconsP1();
                fruitManager.ResetPlayerFruitBasketP1();
            }
        }
        //same for second player
        if (playerManager.playerTwoDestinationIdentity == PlayerManager.DestinationType.CUSTOMER_ONE
           || playerManager.playerTwoDestinationIdentity == PlayerManager.DestinationType.CUSTOMER_TWO
           || playerManager.playerTwoDestinationIdentity == PlayerManager.DestinationType.CUSTOMER_THREE
           || playerManager.playerTwoDestinationIdentity == PlayerManager.DestinationType.CUSTOMER_FOUR
           || playerManager.playerTwoDestinationIdentity == PlayerManager.DestinationType.CUSTOMER_FIVE)
        {
            if (playerManager.playerTwoDestinationReached)
            {
                playerManager.playerTwoDestinationReached = false;
                bool wrongDelivery = false;
                int wrongDeliveryCounter = 0;
                //playerManager.playerTwoDestinationIdentity = PlayerManager.DestinationType.CUSTOMER_ONE
                for (int i = 0; i < NO_OF_TOTAL_FOOD; i++)
                {
                    if (
                            !(fruitManager.playerTwoFruitS[i] == (byte)customerFruitRequirement[(int)playerManager.playerTwoDestinationIdentity - TOTAL_FRUIT_TYPE, 0]
                            ||
                            fruitManager.playerTwoFruitS[i] == (byte)customerFruitRequirement[(int)playerManager.playerTwoDestinationIdentity - TOTAL_FRUIT_TYPE, 1]
                            ||
                            fruitManager.playerTwoFruitS[i] == (byte)customerFruitRequirement[(int)playerManager.playerTwoDestinationIdentity - TOTAL_FRUIT_TYPE, 2])
                        )
                    {
                        wrongDelivery = true;
                        wrongDeliveryCounter++;
                    }
                }
                if (!choppingBoardManager.choppingDonePlayerTwo)
                    wrongDelivery = true;
                choppingBoardManager.choppingDonePlayerTwo = false;
                if (!plateTableManager.plateCollectedPlayerTwo)
                    wrongDelivery = true;
                plateTableManager.plateCollectedPlayerTwo = false;
                if (wrongDelivery)
                {
                    errorMessageWrongDeliveryP2.SetActive(true);
                    Invoke("DisableErrorMessageP2", 2.0f);
                    print("delivery error");
                    miscManager.playerTwoScore -= 100 * wrongDeliveryCounter;
                }
                else
                {
                    duccessfulDeliveryP2.SetActive(true);
                    Invoke("SuccessfulDeliveryP2", 2.0f);
                    miscManager.playerTwoScore += 500;
                    miscManager.playerTwoTime += (customerWaitTime[(int)playerManager.playerTwoDestinationIdentity - TOTAL_FRUIT_TYPE] - (Time.time - customerWaitTimer[(int)playerManager.playerTwoDestinationIdentity - TOTAL_FRUIT_TYPE]));
                    miscManager.playerTwoScore += (int)(100 * (customerWaitTime[(int)playerManager.playerTwoDestinationIdentity - TOTAL_FRUIT_TYPE] - (Time.time - customerWaitTimer[(int)playerManager.playerTwoDestinationIdentity - TOTAL_FRUIT_TYPE])));
                }
                playerManager.playerTwoFoodInHand = 0;
                playerManager.DisableAllFruitIconsP2();
                fruitManager.ResetPlayerFruitBasketP2();
            }
        }
    }

    void DisableErrorMessageP1()
    {
        errorMessageWrongDeliveryP1.SetActive(false);
    }
    void DisableErrorMessageP2()
    {
        errorMessageWrongDeliveryP2.SetActive(false);
    }
    void SuccessfulDeliveryMessageP1()
    {
        duccessfulDeliveryP1.SetActive(false);
    }
    void SuccessfulDeliveryP2()
    {
        duccessfulDeliveryP2.SetActive(false);
    }
}
