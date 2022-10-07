using Script;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
     [SerializeField] public float delay;
     [SerializeField] public GameObject shot;
     private int damage;
     void Awake()
    {
        if(tag == "Snipershot")
        {
            Destroy(shot,7);
            damage = 50;
        }
        else if (tag == "Gunshot")
        {
            Destroy(shot,4);
            damage = 25;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().health -= damage;
            Destroy(shot);
        }
    }
}
