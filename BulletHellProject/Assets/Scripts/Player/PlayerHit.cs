using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    GameObject player;
    GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    

    void OnCollisionEnter2D(Collision2D bullet)
    {

        if (bullet.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("hit_bullet");
            Destroy(bullet.gameObject);
        }
        else
        {
            Debug.Log("hit_Anything");
        }
    }

}
