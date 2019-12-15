using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    
    const int NO_OF_TOTAL_CUSTOMER = 5;
    const int TOTAL_FRUIT_TYPE = 6;
    const int NO_OF_TOTAL_FOOD = 3;
    const float MINIMUM_TIME = 15.0F;
    const float MAXIMUM_TIME = 45.0F;
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
    void DisableAllCustomerFoodIcons()
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
    void InitiateCustomerWaitTime()
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
            
            print("customer "+i+" time " + customerWaitTime[i]);
        }
    }
    public GameObject healthBarChopC1, healthBarChopC2, healthBarChopC3, healthBarChopC4, healthBarChopC5;
    private float initialLengthC1, initialLengthC2, initialLengthC3, initialLengthC4, initialLengthC5;
    IEnumerator CompleteTimerProcessC1(int i)
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
    void GenerateUniqueValue( int i )
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
                print("customer " + i + " foodcounter " + foodCounter + " value " + val);
            }
            else
                print("REPEAT");
            if (foodCounter == NO_OF_TOTAL_FOOD)
                break;
        }
    }
    // Update is called once per frame
    void Update()
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
            }
        }
    }
}
