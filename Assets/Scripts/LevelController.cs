using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerDestroyed()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            Debug.Log("End");
        }
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopAllSpawners();
    }

    private void StopAllSpawners()
    {
        AttackerSpawner[] spawnersArray = FindObjectsOfType<AttackerSpawner>();
        foreach (AttackerSpawner spawner in spawnersArray)
        {
            spawner.StopSpawning();
        }
    }
}
