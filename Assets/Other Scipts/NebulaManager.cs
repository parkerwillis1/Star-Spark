using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NebulaManager : MonoBehaviour
{
    public static NebulaManager instance; // Singleton instance
    public GameObject nebulaObject; // Assign the nebula object here
    private int enemyCount; // To keep track of the number of enemies

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        nebulaObject.SetActive(false); // Disable nebula object at the start
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length; // Count the number of enemies at the start
        Debug.Log("Initial Enemy Count: " + enemyCount); // Log the initial enemy count
    }

    public void RegisterEnemy()
    {
        enemyCount++; // Increase the enemy count when a new enemy is registered
        Debug.Log("Enemy Registered. Total Enemies: " + enemyCount); // Log the total enemy count after registering
    }

    public void EnemyDestroyed()
    {
        enemyCount--; // Decrease the enemy count when an enemy is destroyed
        Debug.Log("Enemy Destroyed. Remaining: " + enemyCount); // Log the remaining enemy count

        if (enemyCount <= 0)
        {
            Debug.Log("All enemies destroyed. Activating Nebula.");
            nebulaObject.SetActive(true); // Enable nebula object when all enemies are destroyed
        }
    }

    public bool IsAllEnemiesDestroyed()
    {
        return enemyCount <= 0; // Return true if all enemies are destroyed, false otherwise
    }
}
