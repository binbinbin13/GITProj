using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public float contactDistance;
    public float damageRate;

    private NavMeshAgent navMeshAgent;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.isStopped = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.GetIsGameOver()) 
        {
            navMeshAgent.isStopped = true;
            return;
        }

        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

        if (distanceToPlayer < contactDistance)
        {
            if (navMeshAgent.isStopped)
            {
                AudioManager.instance.PlayContactedSfx();
                navMeshAgent.isStopped = false;
            }

            navMeshAgent.SetDestination(player.transform.position);
        }
        else 
        {
            if (!navMeshAgent.isStopped)
            {
                navMeshAgent.isStopped = true;
                AudioManager.instance.PlayUnContactedSfx();
            }   
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag.Equals("Player")) 
        {
            GameManager.instance.MinusHealth(damageRate * Time.deltaTime);
        }
    }
}
