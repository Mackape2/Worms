using UnityEngine;
using Random = UnityEngine.Random;

namespace Script
{
    public class Spawning : MonoBehaviour
    {
        [SerializeField]private GameObject playerObject;
        [SerializeField]private GameObject MainCam;
        public float area;
        void Awake()
        {
            
            Spawnobjects(area, playerObject);
            
        }
        void Spawnobjects(float areasize, GameObject obj)
        {
            Team.Player1Alive = 0;
            Team.Player2Alive = 0;
            Team.Player3Alive = 0;
            Team.Player4Alive = 0;
        
            for (int i = 0; i < Menu.teams; i++)
            {
                for (int teamTracker = 0; teamTracker < Menu.survivors; teamTracker++)
                {
                    Vector2 spawnPos = new Vector2(Random.Range(-areasize, areasize), Random.Range(-areasize, areasize));
                
                    //Creates the players
                    GameObject playerModel = Instantiate(obj, new Vector3(spawnPos.x, 400, spawnPos.y), Quaternion.identity);


                    playerModel.GetComponent<PlayerController>().playerCamera = MainCam;
                    
                    
                    //Makes the camera of the clone into an object
                    GameObject cameras  = playerModel.transform.GetChild(1).gameObject;
                    cameras.name = ("Camera " + "Team " + (i + 1).ToString() + " Player " + (teamTracker+1).ToString());
                    //Shows the developer that the model has been assigned to the correct team
                    playerModel.GetComponent<PlayerController>().teamOfPlayer = Team.PlayerTeams[i];
                    playerModel.tag = "Player";
                
                    //Simple if-else that only activates the first player in team 1 and deactivates the rest
                    if (i == 0 && teamTracker == 0)
                    {
                        cameras.SetActive(true);
                        playerModel.GetComponent<PlayerController>().enabled = true;
                    }
                    else
                    {
                        cameras.SetActive(false);
                        playerModel.GetComponent<PlayerController>().enabled = false;
                    }
                
                    //A switch that edits the spawned player based on their team
                    switch (i)
                    {
                        case 0:
                            //Programmer help to name the player after its team and position in the team
                            playerModel.name = "Team" + (i+1) + " Player" + (teamTracker + 1);
                            //Places the object into the assigned player list
                            Team.Player1[teamTracker] = playerModel.gameObject;
                            Team.Player1Alive += 1;
                            //Changes the color of the team 
                            playerModel.GetComponent<MeshRenderer>().material.color = Color.red;
                            break;
                        
                        
                        case 1:
                            playerModel.name = "Team" + (i+1) + " Player" + (teamTracker+ 1);
                            Team.Player2[teamTracker] = playerModel.gameObject;
                            Team.Player2Alive += 1;
                            playerModel.GetComponent<MeshRenderer>().material.color = Color.blue;
                            break;
                        
                        
                        case 2:
                            playerModel.name = "Team" + (i+1) + " Player" + (teamTracker+ 1);
                            Team.Player3[teamTracker] = playerModel.gameObject;
                            Team.Player3Alive += 1;
                            playerModel.GetComponent<MeshRenderer>().material.color = Color.black;
                            break;
                        
                        
                        case 3:
                            playerModel.name = "Team" + (i+1) + " Player" + (teamTracker + 1);
                            Team.Player4[teamTracker] = playerModel.gameObject;
                            Team.Player4Alive += 1;
                            playerModel.GetComponent<MeshRenderer>().material.color = Color.yellow;
                            break;
                    }
                }
            }
        }
    }
}
