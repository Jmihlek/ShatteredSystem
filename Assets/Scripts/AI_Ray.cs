using UnityEngine;
using UnityEngine.AI;

public class AI_Ray : MonoBehaviour 
{
    private Transform Player;
    private NavMeshAgent NMA;

	void Start () 
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        NMA = GetComponent<NavMeshAgent>();
	}
	
	void Update () 
    {
        if (Player != null && NMA != null)
            NMA.SetDestination(Player.position);
	}
}
