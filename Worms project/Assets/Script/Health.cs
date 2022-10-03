using UnityEngine;

namespace Script
{
    public class Health : MonoBehaviour
    {
        public float health = 100;

        public PlayerController playerController;
        // Start is called before the first frame update

    
        void Update()
        {
            if (health <= 0)
            {
                playerController.isAlive = false;
            }
        }
    }
}
