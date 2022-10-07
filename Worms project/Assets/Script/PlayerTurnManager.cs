using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class PlayerTurnManager : MonoBehaviour
    {
        private int currentTeam;
        [SerializeField]public GameObject currentCamera;
        public GameObject newCamera;
        public Spawning spawning;
        public GameObject activePlayer;
        private List<GameObject> cameras;
        private int currentPlayer;
        private int players;
        private bool playerIsAlive = true;
        private int turnTotal;

        // Start is called before the first frame update


        void Start()
        {
            
            turnTotal = 0;
            currentTeam = 0;
            players = Menu.survivors;
            currentPlayer = 0;
            activePlayer = Team.Player1[0].gameObject;
            activePlayer.GetComponentInChildren<PlayerController>().isActivePlayer = true;
            newCamera = activePlayer.transform.GetChild(1).gameObject;
            currentCamera = newCamera;
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                ChangeTurn();
            }
            
        }

        public void ChangeTurn()
        {
            //If the newCamera doesn't update during the loop, it will repeat.
                turnTotal += 1;
                    //Turns the active player back into a regular object
                    activePlayer.GetComponent<PlayerController>().isActivePlayer = false;
                    activePlayer.GetComponent<PlayerController>().enabled = false;

                    //Un-equips any weapon currently held by the player when the turn is done
                    activePlayer.transform.GetChild(2).GetChild(0).gameObject.SetActive(false);
                    activePlayer.transform.GetChild(2).GetChild(1).gameObject.SetActive(false);
                    while (currentCamera == newCamera)
                    { 
                    
                    currentTeam += 1;
                    
                    //If all teams have played, the loop gets reset, but makes the next player in the teams playable
                    if (currentTeam >= Menu.teams)
                    {
                        currentPlayer += 1;
                        
                        //If all players in a team has played, It resets to the first player of all teams
                        if (currentPlayer >= Menu.survivors)
                        {
                            currentPlayer = 0;
                        }

                        currentTeam = 0;
                    }

                    //Picks from the list that belongs to the current team of players
                    switch (currentTeam)
                    {
                        case 0: 
                            //Makes active player into a usable variable that drastically shortens the code
                            activePlayer = Team.Player1[currentPlayer].gameObject;
                            
                            //Checks if the picked player is currently alive. If it is dead, the newCamera object
                            //will not update and the loop will repeat.
                            playerIsAlive = Team.Player1[currentPlayer].GetComponent<PlayerController>().isAlive;
                            if (playerIsAlive)
                            {
                                //The camera is updated, causing the loop to end
                                newCamera = activePlayer.transform.GetChild(1).gameObject; 
                                //The same process happens in the other cases too
                            }
                            break;
                        
                        
                        case 1:
                            activePlayer = Team.Player2[currentPlayer].gameObject;
                            playerIsAlive = activePlayer.GetComponent<PlayerController>().isAlive;
                            if (playerIsAlive)
                            {
                                newCamera = activePlayer.transform.GetChild(1).gameObject;
                            }
                            
                            
                            break;
                        case 2:
                            activePlayer = Team.Player3[currentPlayer].gameObject;
                            playerIsAlive = activePlayer.GetComponent<PlayerController>().isAlive;
                            if (playerIsAlive)
                            {
                                newCamera = activePlayer.transform.GetChild(1).gameObject;
                            }
                            break;
                        
                        
                        case 3:
                            activePlayer = Team.Player4[currentPlayer].gameObject;
                            playerIsAlive = activePlayer.GetComponent<PlayerController>().isAlive;
                            if (playerIsAlive)
                            {
                                
                                newCamera = activePlayer.transform.GetChild(1).gameObject;
                            }
                            break;
                    }
                    
                    
                    //The new camera will only activate when the correct camera has been selected
                    if (currentCamera != newCamera)
                    {
                        //activates the new camera before deactivating the current camera so it doesn't crash
                        newCamera.SetActive(true); 
                        currentCamera.SetActive(false);
                        
                        //activates the player controller so that the character can move
                        activePlayer.GetComponent<PlayerController>().enabled = true;
                        
                        //isActivePlayer sets to true so the game object can equip guns
                        activePlayer.GetComponent<PlayerController>().isActivePlayer = true;
                    } 
                }
                    // Updates current camera to the new camera so that the previous loop can activate again
                    currentCamera = newCamera;
        }
    }
}
