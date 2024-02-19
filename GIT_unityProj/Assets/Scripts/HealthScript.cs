using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    public int healthToAdd;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            GameManager.instance.AddHealth(healthToAdd);
            AudioManager.instance.PlayHealthSfx();
            Destroy(gameObject);
        }
    }
}
