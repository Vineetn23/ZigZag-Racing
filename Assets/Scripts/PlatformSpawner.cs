 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;

    public Transform lastPlatform;
    Vector3 lastPosition;
    Vector3 newPos;

    bool stop;

    void Start()
    {
        lastPosition = lastPlatform.position;
        StartCoroutine(SpawnPlatform());
    }

    void Update()
    {
        
    }

    IEnumerator SpawnPlatform()
    {
        while (!stop)
        {
            GeneratePosition();

            

            lastPosition = newPos;

            yield return new WaitForSeconds(0.2f);
        }
    }


    void GeneratePosition()
    {
        newPos = lastPosition;

        int rand = Random.Range(0, 2);

        if (rand > 0)
        {
            newPos.x += 2f;
            Instantiate(platform, newPos, Quaternion.Euler(0, 90, 0));
        }
        else
        {
            newPos.z += 2f;
            Instantiate(platform, newPos, Quaternion.Euler(0,0,0));
        }
    }
}
