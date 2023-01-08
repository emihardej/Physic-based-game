using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] myObjects;
    public GameObject[] locations;

    void Start()
    {
        
        // for(var j = 0 ; j < rand; j ++){
            for (var i = 0; i < locations.Length; i++){
            Vector3 spawn = locations[i].transform.position;
                int rand = Random.Range(0, myObjects.Length);
                Instantiate(myObjects[rand], spawn, Quaternion.identity);
            }
            
       // }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
