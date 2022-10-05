using UnityEngine;
using Random = UnityEngine.Random;

namespace Script
{
    public class Spawning : MonoBehaviour
    {
        public GameObject playerObject;
        //public GameObject cameras;
        public float area;
        void Awake()
        {
            Spawnobjects(area, playerObject);
        }
        void Spawnobjects(float areasize, GameObject obj)
        {
        
            for (int i = 0; i < Menu.teams; i++)
            {
                for (int teamTracker = 0; teamTracker < Menu.survivors; teamTracker++)
                {
                    Vector2 spawnPos = new Vector2(Random.Range(-areasize, areasize), Random.Range(-areasize, areasize));
                
                    GameObject playerModel = Instantiate(obj, new Vector3(spawnPos.x, 400, spawnPos.y), Quaternion.identity);
                
                
                    //Makes the camera of the clone into an object
                    GameObject cameras  = playerModel.transform.GetChild(1).gameObject;
                    cameras.name = ("Camera " + "Team " + (i + 1).ToString() + " Player " + (teamTracker+1).ToString());
                
                    //Shows the developer that the model has been assigned to the correct team
                    playerModel.GetComponent<PlayerController>().teamOfPlayer = Team.PlayerTeams[i];
                
                
                    if (i == 0 && teamTracker == 0)
                    {
                        cameras.SetActive(true);
                        playerModel.GetComponent<CharacterController>().enabled = true;
                        playerModel.GetComponent<Rigidbody>().useGravity = false;
                    }
                    else
                    {
                        cameras.SetActive(false);
                        playerModel.GetComponent<CharacterController>().enabled = false;
                        playerModel.GetComponent<Rigidbody>().useGravity = true;
                    }
                
                    switch (i)
                    {
                        case 0:
                            playerModel.name = "Team" + (i+1) + " Player" + (teamTracker + 1);
                            Team.Player1[teamTracker] = playerModel.gameObject;
                            break;
                        case 1:
                            playerModel.name = "Team" + (i+1) + " Player" + (teamTracker+ 1);
                            Team.Player2[teamTracker] = playerModel.gameObject;
                            break;
                        case 2:
                            playerModel.name = "Team" + (i+1) + " Player" + (teamTracker+ 1);
                            Team.Player3[teamTracker] = playerModel.gameObject;
                            break;
                        case 3:
                            playerModel.name = "Team" + (i+1) + " Player" + (teamTracker + 1);
                            Team.Player4[teamTracker] = playerModel.gameObject;
                            break;
                    }
                
                
                }
            }
        }
    
    
    
    }
}
