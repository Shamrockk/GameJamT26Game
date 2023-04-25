using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
      public float moveSpeed;
      public Rigidbody2D rb2d;
      private Vector2 moveInput;

      public float CurrentHealth;
      public float MaxHealth = 10;
      public float bulletCooldown;
      float bulletTimer;


    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
      bulletTimer -= Time.deltaTime;
      Movement();
      Shooting();
      Health();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
      if(collision.tag == "Bullet" && bulletTimer <= 0) 
      {
        CurrentHealth--;
        print(CurrentHealth);
        bulletTimer = bulletCooldown;
      }
    }

    public void Movement() 
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        moveInput.Normalize();

        rb2d.velocity = moveInput * moveSpeed;
    }
    
    public void Shooting() 
    {
      
    }

    public void Health() 
    {
       
    }

     public void TakeDamage(int amount) 
     {
         CurrentHealth -= amount;
         if(CurrentHealth <= 0) {
          
         }
     }
    


}
