using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float projectileSpeed;
    private Rigidbody2D rb;
    // Start is called before the first frame update

    private void OnEnable() 
    {
        if(rb != null) 
        {
            rb.velocity = Vector2.up * projectileSpeed;
        }
        
        Invoke("Disable", 2f);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * projectileSpeed;
    }

    // Update is called once per frame
    void Disable()
    {
        gameObject.SetActive(false);
    }

      void OnDisable()
    {
        CancelInvoke();
    }
}
