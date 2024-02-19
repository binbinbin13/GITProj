using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public int PointToUnlock;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player")) 
        {
            if (GameManager.instance.GetPointCount() >= PointToUnlock)
            {
                AudioManager.instance.PlayDoorSfx();
                Destroy(gameObject);
            }
            else 
            {
                AudioManager.instance.PlayErrorSfx();
                GameManager.instance.DisplayInstuction("You need more points!", 3);
            }
        }
    }
}
