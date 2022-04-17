using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;

    public GameObject[] PlatList; 

    public Transform lastPlatform;
    public bool PlatisSpawning;
    Vector3 lastPosition;
    Vector3 newPos;

    bool stop;

    private void Start()
    {
        lastPosition = lastPlatform.position;
        StartCoroutine(SpawnPlatforms());

    }

    private void Update()
    {
        
    }

    void GeneratePosition()
    {
        newPos = lastPosition;

        int randIdx = Random.Range(0, 2);

        if (randIdx > 0)
        {
            newPos.x += 2f;
        }
        else
        {
            newPos.z += 2f;
        }

    }

    IEnumerator SpawnPlatforms()
    {
        while (!stop)
        {
        
        GeneratePosition();

        int PlatRanIdx = Random.Range(0, 6);


        Instantiate(PlatList[PlatRanIdx], newPos, Quaternion.identity);

        lastPosition = newPos;

        yield return new WaitForSeconds(0.1f);
         
        }


    }

}
