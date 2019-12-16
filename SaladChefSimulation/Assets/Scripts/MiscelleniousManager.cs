using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiscelleniousManager : MonoBehaviour
{
    private PlayerManager playerManager;
    public GameObject players;
    [HideInInspector]
    public int playerOneScore = 0, playerTwoScore = 0;
    [HideInInspector]
    public float playerOneTime = 120, playerTwoTime = 120;
    public GameObject sppedBoostP1, sppedBoostP2;
    private int lifeSpanP1, intervalP1;
    private int lifeSpanP2, intervalP2;
    private float initTimeIntervalP1, initTimeIntervalP2;
    private float initTimeSpanP1, initTimeSpanP2;
    const int MAX_SPAN = 6;
    const int MIN_SPAN = 3;
    const int MAX_INTERVAL = 15;
    const int MIN_INTERVAL = 30;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = players.GetComponent<PlayerManager>();
        initTimeIntervalP1 = Time.time;
        initTimeIntervalP2 = Time.time;        
        intervalP1 = Random.Range(MIN_INTERVAL, MAX_INTERVAL);
        intervalP2 = Random.Range(MIN_INTERVAL, MAX_INTERVAL);
        sppedBoostP1.SetActive(false);
        sppedBoostP2.SetActive(false);
    }
    float timer = 0;
    bool sbStarted1 = false, sbStarted2 = false;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        playerOneTime -= (timer % 60);
        playerTwoTime -= (timer % 60);

        if(Time.time-initTimeIntervalP1>intervalP1 && !sbStarted1)
        {
            lifeSpanP1 = Random.Range(MIN_SPAN, MAX_SPAN);            
            sppedBoostP1.SetActive(true);
            initTimeSpanP1 = Time.time;
            sbStarted1 = true;
        }
        if(sbStarted1)
        {
            if(Time.time- initTimeSpanP1>lifeSpanP1)
            {
                initTimeIntervalP1 = Time.time;
                intervalP1 = Random.Range(MIN_INTERVAL, MAX_INTERVAL);
                sbStarted1 = false;
                sppedBoostP1.SetActive(false);
            }
        }

        if (Time.time - initTimeIntervalP2 > intervalP2 && !sbStarted2)
        {
            lifeSpanP2 = Random.Range(MIN_SPAN, MAX_SPAN);
            sppedBoostP2.SetActive(true);
            initTimeSpanP2 = Time.time;
            sbStarted2 = true;
        }
        if (sbStarted2)
        {
            if (Time.time - initTimeSpanP2 > lifeSpanP2)
            {
                initTimeIntervalP2 = Time.time;
                intervalP2 = Random.Range(MIN_INTERVAL, MAX_INTERVAL);
                sbStarted2 = false;
                sppedBoostP2.SetActive(false);
            }
        }
    }

    public void HandleMiscellinious()
    {
        if (playerManager.playerOneDestinationIdentity == PlayerManager.DestinationType.SPPED_BOOST_ONE)
        {
            if (playerManager.playerOneDestinationReached)
            {
                playerManager.playerOneDestinationReached = false;
                playerManager.speedPlayerOne += 2;
            }
        }
        if (playerManager.playerTwoDestinationIdentity == PlayerManager.DestinationType.SPEED_BOOST_TWO)
        {
            if (playerManager.playerTwoDestinationReached)
            {
                playerManager.playerTwoDestinationReached = false;
                playerManager.speedPlayerTwo += 2;
            }
        }
    }

}
