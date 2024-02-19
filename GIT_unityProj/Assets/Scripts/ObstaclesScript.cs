using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesScript : MonoBehaviour
{
    public float rateOfDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player")) 
        {
            GameManager.instance.MinusHealth(rateOfDamage * Time.deltaTime);
        }
    }

}
