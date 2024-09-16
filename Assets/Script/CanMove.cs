using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.Audio;

public class CanMove : NPCMove
{
    public float detectionRadius = 5f; // Radius to detect pedestrians at stops
    public LayerMask pedestrianLayer; // Layer to identify pedestrian objects
    public int moneyPerPedestrian = 200; // Money earned per pedestrian destroyed
    public Money wallet; // Reference to the Money ScriptableObject
    public Timer timer; // Reference to the Timer script to track money earned in the scene
    public AudioClip MoneySound;
    public ParticleSystem test;

    private AudioSource audioSource;
    protected override void Start()
    {
        test.Stop();
        navMeshArea = "Car"; // Set this to Bus for the bus object
        base.Start();
        
        audioSource = GetComponent<AudioSource>();
    }

    protected override IEnumerator StopAtPoint()
    {
        isStopped = true;
        agent.isStopped = true;

        // Logic for bus to pick up pedestrians
        Collider[] pedestrians = Physics.OverlapSphere(transform.position, detectionRadius, pedestrianLayer);
        Debug.Log("Pedestrians detected: " + pedestrians.Length);

        foreach (Collider pedestrian in pedestrians)
        {
            // Debug log to confirm detection
            Debug.Log("Destroying pedestrian: " + pedestrian.gameObject.name);
            
            // Destroy the pedestrian GameObject
            Destroy(pedestrian.gameObject);
            
            // Add money for each destroyed pedestrian
            if (wallet != null)
            {
                wallet.amount += moneyPerPedestrian;
                timer.moneyEarnedInScene += moneyPerPedestrian; // Update money earned in the scene
                Debug.Log("Money: " + wallet.amount);
            }

            if (audioSource != null && MoneySound != null)
            {
                audioSource.PlayOneShot(MoneySound);
                test.Play();
            }
        }

        yield return new WaitForSeconds(stopDuration);

        agent.isStopped = false;
        isStopped = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
