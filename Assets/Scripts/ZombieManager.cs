using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    [Header("Zombie GameObject")]
    public GameObject zombiePrefab;
    public int countZombies = 10;

    [Header("Platform Boundary")]
    public Transform platform;
    public float minX, maxX;
    public float fixedY = 0f;
    public float minZ, maxZ;

    [Header("Waypoints Arraay")]
    public Transform[] waypoints;
    public int maxWaypoints = 4;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i=0; i<countZombies; i++){
            SpawnZombie();
        }
    }

    // Update is called once per frame
    void SpawnZombie()
    {
        // Select random point in a give rectangle
        Vector3 spwanPosition = new Vector3(
            Random.Range(minX, maxX),
            fixedY,
            Random.Range(minZ, maxZ)
        );

        // Spawn zombie
        GameObject zombie = Instantiate(zombiePrefab, spwanPosition, Quaternion.identity);

        EnemyAI ai = zombie.GetComponent<EnemyAI>();

        // Give zombie its points to wander around 
        if(ai != null){
            ai.waypoints = GetRandomWaypoints();
        }

        // For detecting hit by car
        ZombieHit zh = zombie.GetComponent<ZombieHit>();
        if(zh != null){
            zh.manager = this;
        }
    }

    // Select Destination points for zombie to walk
    private Transform[] GetRandomWaypoints()
    {
        if(waypoints.Length <= maxWaypoints){
            return waypoints;
        }

        List<Transform> randomWaypoints = new List<Transform>();
        List<int> usedIndex = new List<int>();

        // Select random points from waypoints
        while(randomWaypoints.Count < maxWaypoints){
            int i = Random.Range(0, waypoints.Length);
            if(!usedIndex.Contains(i)){
                randomWaypoints.Add(waypoints[i]);
                usedIndex.Add(i);
            }
        }

        return randomWaypoints.ToArray();
    }

    // Called by ZombieHit.cs to Respwan Zombie
    public void Respwan(GameObject zombie, float delay = 2.5f)
    {
        StartCoroutine(RespwanCoroutine(zombie, delay));
    }

    // 
    public IEnumerator RespwanCoroutine(GameObject zombie, float delay)
    {
        yield return new WaitForSeconds(delay);

        Vector3 randomPosition = new Vector3(
            Random.Range(minX, maxX),
            fixedY,
            Random.Range(minZ, maxZ)
        );

        // Give random points and activates nessecary components
        ZombieHit zh = zombie.GetComponent<ZombieHit>();
        if(zh != null){
            zh.ResetZombie(randomPosition);
        }

        // AI for wandering around
        EnemyAI ai = zombie.GetComponent<EnemyAI>();
        if(ai != null){
            ai.waypoints = GetRandomWaypoints();
        }
    }
}
