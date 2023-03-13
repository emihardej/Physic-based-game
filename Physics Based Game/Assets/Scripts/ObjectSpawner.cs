using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> prefabObjects;
    public GameObject location;
    public GameObject spawnedObject;

    void Start()
    {
        SpawnObject();
    }

// Spawn objects 
    public void SpawnObject()
    {
        int rand = Random.Range(0, prefabObjects.Count);
        GameObject obj = prefabObjects[rand];
        Vector3 spawn = location.transform.position;
        //Debug.Log(spawn);
        spawnedObject = Instantiate(obj, spawn, Quaternion.identity );
        spawnedObject.name = location.name + "0";

    }
}
