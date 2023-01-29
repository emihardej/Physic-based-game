using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    

    //public ObjectSpawner spawner;
    
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //GameObject[] go = GameObject.FindGameObjectsWithTag("Object");
        //GameObject go = GameObject.FindGameObjectWithTag("Object");
        

        //for ( var i = 0 ; i < go.Length ; i ++){
            //GameObject obj = go[i].GetComponent<ObjectSpawner>().spawnedObject;
            //Debug.Log(obj);
            //GameObject spawner = go[i].GetComponent<ObjectSpawner>().location;
            //ObjectSpawner spawner = go[i].GetComponent<ObjectSpawner>();
            //GameObject spawnObject = spawner.spawnedObject;
            //Debug.Log(go[i]);
            //Debug.Log(obj);
            
            if (collision.collider.tag == "Floor"){
            
                string objName = obj.name; 
                string newObjName = objName.Replace("0","");
                Debug.Log(newObjName);
                GameObject loc = GameObject.Find(newObjName);
                Destroy(obj, 2.0f);
                RespawnObject(loc, obj.name);
                //spawner.RespawnObject();
            }
        //} 
    }

    void RespawnObject(GameObject location, string objectName)
    {
        GameObject respawnedObject = Instantiate(obj, location.transform.position, Quaternion.identity);
        respawnedObject.name = objectName;
    }

}
