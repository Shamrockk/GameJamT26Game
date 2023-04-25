using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
      public float moveSpeed;
      public Rigidbody2D rb2d;
      private Vector2 moveInput;

      GameObject player;
      GameObject bullet;

      public float maxHealth = 10;
      public float currentHealth;

      public GameObject projectile;
      public Transform firePosition;
      private AudioSource audioSource;
      

    // Start is called before the first frame update
    void Start()
    {
      currentHealth = maxHealth;
    }

   

    // Update is called once per frame
    void Update()
    {
      if(currentHealth > 0)
      {
          Movement();
      }

      if(Input.GetMouseButton(0)) 
      {
        Fire();
      }
    
    }

    void OnCollisionEnter2D(Collision2D bullet)
    {

        if (bullet.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("hit_bullet");
            Destroy(bullet.gameObject);
            TakeDamage(1);
        }
        else
        {
            Debug.Log("hit_Anything");
        }
    }

    public void Movement() 
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb2d.velocity = moveInput * moveSpeed;
    }

    public void Fire() 
    {
      GameObject obj = ObjectPooler.current.GetPooledObject();
      if(obj == null) return;

      obj.transform.position = firePosition.position;
      obj.transform.rotation = firePosition.rotation;
      obj.SetActive(true);
      //AudioSource.PlayOneShot(audioSource.clip);
    }

     void TakeDamage(int amount)
    {
      currentHealth--;

      if(currentHealth <= 0) {
        //we are dead
        //game over screen
      }
    }

    public void Heal(int amount)
    {
      currentHealth += amount;

      if(currentHealth > maxHealth) {
        currentHealth = maxHealth;
      }
    }

}
