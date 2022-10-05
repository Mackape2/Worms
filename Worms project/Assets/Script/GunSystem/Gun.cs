using UnityEngine;

namespace Script
{
    public class Gun : MonoBehaviour
    {
        public GameObject muzzlePoint;
        public Transform startPosition;
        public GameObject bullets;
        public GameObject parentobj;
        private GameObject spawnBullet;
        
        
        private void Awake()
        {
            
        }
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (GetComponentInParent<PlayerController>().isActivePlayer)
                {
                     Spawnobject();
                     spawnBullet.GetComponent<Rigidbody>().AddForce(transform.forward * 3000f);
                }
                   

            }
        }
        
        void Spawnobject()
        { 
            startPosition = muzzlePoint.transform;
            spawnBullet = Instantiate(bullets, startPosition.position, startPosition.rotation);
        }
    }
}
