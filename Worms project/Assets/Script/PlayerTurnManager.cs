using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnManager : MonoBehaviour
{
    private int teams;
    private int currentTurn;
    [SerializeField]public GameObject currentCamera;
    public GameObject newCamera;
    public Spawning spawning;
    private List<GameObject> cameras;
    private int currentLoop;
    private int players;
    private bool playerIsAlive = true;

    // Start is called before the first frame update


    void Start()
    {
        currentTurn = 0;
        teams = Menu.teams;
        players = Menu.survivors;
        currentLoop = 0;
        newCamera = Team.Player1[0].transform.GetChild(1).gameObject;
        currentCamera = newCamera;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            //Increases the turn by one
            while (currentCamera == newCamera)
            { 
                
                currentTurn += 1;
                //all teams
                if (currentTurn >= Menu.teams)
                {
                    currentLoop += 1;
                    if (currentLoop >= Menu.survivors)
                    {
                        currentLoop = 0;
                    }

                    currentTurn = 0;
                }

                switch (currentTurn)
                {
                    case 0:
                        playerIsAlive = Team.Player1[currentLoop].GetComponent<PlayerController>().isAlive;
                        if (playerIsAlive)
                            newCamera = Team.Player1[currentLoop].transform.GetChild(1).gameObject;
                        break;
                    case 1:
                        playerIsAlive = Team.Player2[currentLoop].GetComponent<PlayerController>().isAlive;
                        if (playerIsAlive)
                            newCamera = Team.Player2[currentLoop].transform.GetChild(1).gameObject;
                        break;
                    case 2:
                        playerIsAlive = Team.Player3[currentLoop].GetComponent<PlayerController>().isAlive;
                        if (playerIsAlive)
                            newCamera = Team.Player3[currentLoop].transform.GetChild(1).gameObject;
                        break;
                    case 3:
                        playerIsAlive = Team.Player4[currentLoop].GetComponent<PlayerController>().isAlive;
                        if (playerIsAlive)
                            newCamera = Team.Player4[currentLoop].transform.GetChild(1).gameObject;
                        break;
           
                }             
                if (currentCamera != newCamera)
                { 
                    newCamera.SetActive(true); 
                    currentCamera.SetActive(false);
                } 
            }
            currentCamera = newCamera;
        }
    }
}
