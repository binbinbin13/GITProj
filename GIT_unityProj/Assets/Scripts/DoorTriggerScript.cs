using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerScript : MonoBehaviour
{
    public int PointToUnlock;
    public GameObject[] doorList;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject door in doorList) 
        {
            door.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player")) 
        {
            if (GameManager.instance.GetPointCount() >= PointToUnlock)
            {
                foreach (GameObject door in doorList)
                {
                    AudioManager.instance.PlayDoorSfx();
                    door.SetActive(true);
                    Destroy(gameObject);
                }
            }
            else
            {
                AudioManager.instance.PlayErrorSfx();
                GameManager.instance.DisplayInstuction("You need more points!", 3);
            }
        }
    }
}
