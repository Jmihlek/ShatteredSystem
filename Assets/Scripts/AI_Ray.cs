using UnityEngine;
using UnityEngine.AI;

public class AI_Ray : MonoBehaviour 
{
    private Transform Player;
    private NavMeshAgent NMA;
    private bool isUpdateEnabled = true;
    private float disableDuration = 0f;
    private float disableTimer = 0f;

    void Start () 
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        NMA = GetComponent<NavMeshAgent>();
	}

    private void Update()
    {
        if (isUpdateEnabled)
        {
            if (Player != null && NMA != null)
                NMA.SetDestination(Player.position);
        }
        else
        {
            // Отключение кода на заданное время
            if (disableTimer <= disableDuration)
            {
                disableTimer += Time.deltaTime;
            }
            else
            {
                disableTimer = 0f;
                isUpdateEnabled = true;
            }
        }
    }

    public void DisableOnTime(float duration)
    {
        isUpdateEnabled = false;
        disableDuration = duration;
    }

}
