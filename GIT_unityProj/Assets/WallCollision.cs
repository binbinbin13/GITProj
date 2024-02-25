using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Reduce player health when colliding with a wall
            TakeDamage(10); // Adjust damage value as needed
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // You can add further actions here like updating UI, checking for death, etc.
        Debug.Log("Player health: " + currentHealth);
    }


}
