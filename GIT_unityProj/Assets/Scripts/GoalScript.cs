using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player")) 
        {
            if (GameManager.instance.GetPointCount() >= GameManager.instance.GetPointToWin())
            {
                GameManager.instance.SetGameOver(true);
            }
            else 
            {
                AudioManager.instance.PlayErrorSfx();
                GameManager.instance.DisplayInstuction("No enough point!", 3);
            }
        }
    }
}
