using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NebulaSceneChanger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Check if the object that entered the trigger is the player
        {
            if (NebulaManager.instance != null && NebulaManager.instance.IsAllEnemiesDestroyed()) // Check if all enemies are destroyed
            {
                LoadNextScene(); // Load the next scene
            }
        }
    }

    private void LoadNextScene()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex; // Get the build index of the current active scene
        int nextIndex = currentIndex + 1; // Calculate the build index of the next scene

        // Check if the next index is within the range of available scenes
        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex); // Load the next scene
        }
        else
        {
            Debug.LogWarning("No more scenes to load."); // Log a warning if there are no more scenes to load
        }
    }
}



