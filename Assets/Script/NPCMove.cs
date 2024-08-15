using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator animator;

    public GameObject PATH;
    public Transform[] pathPoint;
    public int speed = 4;

    public float minDistance = 10f;
    public float stopDuration = 5f; // Duration to stop at each point

    public int index = 0;
    public bool loop = true; // New variable to determine looping behavior

    public string navMeshArea = "Human"; // Set default area to Human

    protected bool isStopped = false; // Flag to handle stopping at points

    public int[] stopIndices; // Array to store indices of stop points

    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // Set agent's area mask to the specified area
        agent.areaMask = 1 << NavMesh.GetAreaFromName(navMeshArea);
        agent.speed = speed;

        pathPoint = new Transform[PATH.transform.childCount];
        for (int i = 0; i < pathPoint.Length; i++)
        {
            pathPoint[i] = PATH.transform.GetChild(i);
        }
    }

    private void Update()
    {
        if (!isStopped)
        {
            roam();
        }
    }

    protected virtual void roam()
    {
        if (Vector3.Distance(transform.position, pathPoint[index].position) < minDistance)
        {
            if (loop)
            {
                index = (index + 1) % pathPoint.Length; // Loop back to the start
            }
            else
            {
                if (index < pathPoint.Length - 1)
                {
                    index += 1; // Move to the next point
                }
                else
                {
                    agent.isStopped = true; // Stop at the last point
                }
            }

            if (ShouldStopAtCurrentIndex())
            {
                StartCoroutine(StopAtPoint());
            }
        }
        agent.SetDestination(pathPoint[index].position);
        animator.SetFloat("vertical", !agent.isStopped ? 1 : 0);
    }

    protected virtual IEnumerator StopAtPoint()
    {
        isStopped = true;
        agent.isStopped = true;
        yield return new WaitForSeconds(stopDuration);
        agent.isStopped = false;
        isStopped = false;
    }

    private bool ShouldStopAtCurrentIndex()
    {
        foreach (int stopIndex in stopIndices)
        {
            if (stopIndex == index)
            {
                return true;
            }
        }
        return false;
    }

    
}
