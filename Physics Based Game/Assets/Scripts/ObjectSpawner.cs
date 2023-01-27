using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public List<GameObject> prefabObjects;
    // public List<GameObject> locations;
    public List<GameObject> spawnedObjects;

    void Start()
    {
        spawnedObjects = new List<GameObject>();

        SpawnObject(RandomObjects());
    }
//Update is called once per frame
    void Update()
    {
        SpawnObject(RandomObjects());
    }

    void SpawnObject(GameObject obj)
    {
        Collider[] intersecting = Physics.OverlapSphere(transform.position, 0.2f); //code to run if nothing is intersecting as the length is 0

        if (intersecting.Length == 0) {
            GameObject newObject = Instantiate(obj, transform.position, Quaternion.identity );
            spawnedObjects.Add(newObject);
        }
    }

     GameObject RandomObjects()
     {

        int rand = Random.Range(0, prefabObjects.Count);
            
        return prefabObjects[rand];

     }

    
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
