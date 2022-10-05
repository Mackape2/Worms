using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
     [SerializeField] public float delay;
     [SerializeField] public GameObject shot;
    void Awake()
    {
        
        Destroy(shot,delay);
    }
    
}
