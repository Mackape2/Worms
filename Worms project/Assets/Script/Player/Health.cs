using UnityEngine;

namespace Script
{
    public class Health : MonoBehaviour
    {
        public float health = 100;

        public PlayerController playerController;

        private bool _playerDead = false;
        // Start is called before the first frame update

    
        void Update()
        {
            if (health <= 0)
            {
                playerController.isAlive = false;
                gameObject.GetComponent<MeshRenderer>().material.color = Color.gray;
                if(!_playerDead)
                    switch (gameObject.GetComponent<PlayerController>().teamOfPlayer)
                    {
                        case 1:
                            Team.Player1Alive -= 1;
                            break;
                        
                        case 2:
                            Team.Player2Alive -= 1;
                            break;
                        
                        case 3:
                            Team.Player3Alive -= 1;
                            break;
                        
                        case 4:
                            Team.Player4Alive -= 1;
                            break;
                    }

                _playerDead = true;
            }
        }
    }
}
