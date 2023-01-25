using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] myObjects;
    public GameObject[] locations;
    
    void Start()
    {
        SpawnObject();
    }
    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObject()
    {
       
        for (var i = 0; i < locations.Length; i++){
            Vector3 spawn = locations[i].transform.position;
            int rand = Random.Range(0, myObjects.Length);
            
            Collider[] intersecting = Physics.OverlapSphere(spawn, 0.1f); //code to run if nothing is intersecting as the length is 0

            if (intersecting.Length == 0) {
                Instantiate(myObjects[rand], spawn, Quaternion.identity);
            } 
        }
    }
    void OnCollisionEnter(Collision colInfo)
    {
        for (var i = 0; i < myObjects.Length; i++){
            if (colInfo.collider.tag == "Floor")
            {
                Debug.Log("floor");
                Destroy(myObjects[i]);
                SpawnObject();
            }
        }
    }
    // void DestroyObject()
    // {
    //     RaycastHit hit;
    //     for (var i = 0; i < myObjects.Length; i++){
    //         if (myObjects[i])
    //     }
    // }
}
