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
            activePlayer.GetComponent<PlayerController>().isActivePlayer = true;
            newCamera = Team.Player1[0].transform.GetChild(1).gameObject;
            currentCamera = newCamera;
        
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                //If the newCamera doesn't update during the loop, it will repeat.
                while (currentCamera == newCamera)
                { 
                    //Turns off the activePlayer bool to be able to reactive it on a new gameobject
                    activePlayer.GetComponent<PlayerController>().isActivePlayer = false;
                    
                    //Unequip any weapon currently held by the player when the turn is done
                    activePlayer.transform.GetChild(2).gameObject.SetActive(false);
                    activePlayer.transform.GetChild(3).gameObject.SetActive(false);
                    
                    turnTotal += 1;
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
                            //Checks if the picked player is currently alive. If it is dead, the newCamera object
                            //will not update and the loop will repeat.
                            playerIsAlive = Team.Player1[currentPlayer].GetComponent<PlayerController>().isAlive;
                            if (playerIsAlive)
                            {
                                //If the player is alive, the affected components are activated
                                activePlayer = Team.Player1[currentPlayer].gameObject;
                                
                                //The camera is updated, causing the loop to end
                                newCamera = activePlayer.transform.GetChild(1).gameObject;
                                
                                //activePlayer sets to true so the gameobject can equip guns
                                activePlayer.GetComponent<PlayerController>().isActivePlayer = true;
                                
                                //The same happens in the other cases too
                            }
                            
                            break;
                        case 1:
                            playerIsAlive = Team.Player2[currentPlayer].GetComponent<PlayerController>().isAlive;
                            if (playerIsAlive)
                            {
                                activePlayer = Team.Player2[currentPlayer].gameObject;
                                newCamera = activePlayer.transform.GetChild(1).gameObject;
                                activePlayer.GetComponent<PlayerController>().isActivePlayer = true;
                            }
                            
                            break;
                        case 2:
                            playerIsAlive = Team.Player3[currentPlayer].GetComponent<PlayerController>().isAlive;
                            if (playerIsAlive)
                            {
                                activePlayer = Team.Player3[currentPlayer].gameObject;
                                newCamera = activePlayer.transform.GetChild(1).gameObject;
                                activePlayer.GetComponent<PlayerController>().isActivePlayer = true;
                            }
                            break;
                        case 3:
                            
                            playerIsAlive = Team.Player4[currentPlayer].GetComponent<PlayerController>().isAlive;
                            if (playerIsAlive)
                            {
                                activePlayer = Team.Player4[currentPlayer].gameObject;
                                newCamera = activePlayer.transform.GetChild(1).gameObject;
                                activePlayer.GetComponent<PlayerController>().isActivePlayer = true;
                            }
                            break;
           
                    }
                    //The new camera will only activate when the correct camera has been selected
                    if (currentCamera != newCamera)
                    { 
                        newCamera.SetActive(true); 
                        currentCamera.SetActive(false);
                    } 
                }
                // Updates current camera to the new camera so that the previous loop can activate again
                currentCamera = newCamera;
            }
        }
    }
}
