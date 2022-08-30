using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    bool spawn = true;
    [SerializeField] float minSpawnDelay = 1;
    [SerializeField] float maxSpawnDelay = 5;
    [SerializeField] List<Attacker> attackersPrefab;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        Attacker newAttacker = Instantiate(attackersPrefab[Random.Range(0, attackersPrefab.Count)], transform.position, Quaternion.identity) as Attacker;
        newAttacker.transform.parent = transform;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
