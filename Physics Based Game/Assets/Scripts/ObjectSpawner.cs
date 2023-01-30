using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> prefabObjects;
    public GameObject location;
   // public List<GameObject> spawnedObjects;
    public GameObject spawnedObject;

    void Start()
    {
        //spawnedObjects = new List<GameObject>();

        SpawnObject();
        
        
    }

//Update is called once per frame
    void Update()
    {

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
        //spawnedObjects.Add(newObject);
    }

    // public void RespawnObject()
    // {
    //     Invoke("SpawnObject", 5.0f);
    // }



    
}



/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // void SpawnObject()
    // {
       
    //     for (var i = 0; i < locations.Length; i++){
    //         Vector3 spawn = locations[i].transform.position;
    //         int rand = Random.Range(0, myObjects.Length);
            
    //         //Collider[] intersecting = Physics.OverlapSphere(spawn, 0.1f); //code to run if nothing is intersecting as the length is 0

    //         //if (intersecting.Length == 0) {
    //             Instantiate(myObjects[rand], spawn, Quaternion.identity);
    //         //} 
    //     }
    // }
