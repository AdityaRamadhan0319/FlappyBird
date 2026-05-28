using UnityEngine;
using System.Collections; 

public class PiperSpawner : MonoBehaviour
{
    public GameObject pipe;
    public float spawnTime;
    public float yPosMin,yPosMax;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnPipeCoroutine());
    }

    // Update is called once per frame
    IEnumerator SpawnPipeCoroutine()
    {
        yield return new WaitForSeconds(spawnTime);
        Instantiate(pipe, transform.position + Vector3.up * Random.Range(yPosMin, yPosMax), 
        Quaternion.identity);
        StartCoroutine(SpawnPipeCoroutine());
    }
}