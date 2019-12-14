using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject gameFacilitator;
    private InputManager inputManager;
    void Start()
    {
        inputManager = gameFacilitator.GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        inputManager.HandleCameraZoom();
        inputManager.HandleCameraPan();
    }
}
