using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    [SerializeField] int delayForNextRoundSec = 5;
    int numberOfAttackers = 0;
    bool levelTimerFinished = false;


    private void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }
    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerDestroyed()
    {
        numberOfAttackers--;
        if (numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(delayForNextRoundSec);
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        Time.timeScale = 0;
        loseLabel.SetActive(true);
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
