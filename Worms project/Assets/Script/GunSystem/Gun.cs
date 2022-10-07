using System;
using System.Collections;
using UnityEngine;

namespace Script.GunSystem
{
    public class Gun : MonoBehaviour
    {
        public GameObject muzzlePoint;
        public GameObject bullets;
        public GameObject sniperBullets;
        private GameObject spawnBullet;
        private Transform startPosition;
        private PlayerTurnManager gameManager;
        private float speed = 3000f;
        private int tracker;
        
        

        private void Awake()
        {
            gameManager = FindObjectOfType<PlayerTurnManager>();       
            if (tag == "Sniper")
            {
                tracker = 1;
            }
            if (tag == "Gun")
            {
                tracker = 3;
            }

        }

        void Update()
        {
            
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                StartCoroutine(Shoot());
                
            }
            
        }
        
        IEnumerator Shoot()
        {
            for (int times = 0; times < tracker; times++)
            {
                if(tag == "Sniper")
                    Spawnobject();
                if (tag == "Gun")
                    SpawnShot();
                spawnBullet.GetComponent<Rigidbody>().AddForce(startPosition.forward * speed);
                yield return new WaitForSeconds(float.Parse("0.5"));
            }
            gameManager.ChangeTurn();
        }

        void Spawnobject()
        { 
            startPosition = muzzlePoint.transform;
            spawnBullet = Instantiate(sniperBullets, startPosition.position, startPosition.rotation);
        }

        void SpawnShot()
        {
            startPosition = muzzlePoint.transform;
             spawnBullet = Instantiate(bullets, startPosition.position, startPosition.rotation);
        }

        
    }
}
