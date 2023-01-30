using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public List<GameObject> prefabObjects;
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Detect object collision with floor
    void OnCollisionEnter(Collision collision)
    {   
        if (collision.collider.tag == "Floor"){
            string objName = obj.name; 
            string newObjName = objName.Replace("0","");

            //Debug.Log(newObjName);
            ScoreManager.instance.AddPoint();
            
            GameObject loc = GameObject.Find(newObjName);   //Find name of the objects spawn location
            Destroy(obj, 15.0f);    //Destroy object
            StartCoroutine(RespawnObject(loc, obj.name));   //Respawn a new object in original spawn location of previous object
        }
    }

    //Instatiate new object 
    IEnumerator RespawnObject(GameObject location, string objectName)
    {   
        //get new random prefab
        int rand = Random.Range(0, prefabObjects.Count);
        Debug.Log(rand);
        GameObject newObject = prefabObjects[rand];

        //must instatiate just before the previous object is destroyed
        yield return new WaitForSeconds(14.99f);
        GameObject respawnedObject = Instantiate(newObject, location.transform.position, Quaternion.identity);
        respawnedObject.name = objectName;
        
    }

}
