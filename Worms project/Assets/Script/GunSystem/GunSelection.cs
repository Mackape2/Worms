using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSelection : MonoBehaviour
{
    //Hat Collection
    private GameObject gameobject;
    public GameObject weapon;
    public Transform gunPosition;
    public GameObject sniper;
    

    // Start is called before the first frame update
    void Awake()
    {
        sniper.SetActive(false);
        weapon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (GetComponentInParent<PlayerController>().isActivePlayer)
            {
                sniper.SetActive(false);
                weapon.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (GetComponentInParent<PlayerController>().isActivePlayer)
            {
                weapon.SetActive(false);
                sniper.SetActive(true);
            }
        }
    }
    
    public void CreateGun(gunType type)
    {
        GameObject fireArm = Instantiate(weapon, gunPosition.position, gunPosition.rotation);
        fireArm.name = "Machine Gun";

    }
    public enum gunType
    {
        gun
    }
}
