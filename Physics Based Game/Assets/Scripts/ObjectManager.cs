using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject obj;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnCollisionEnter(Collision colInfo)
    {
        if (colInfo.collider.tag == "Floor"){
        
            Debug.Log("Hit floor");
            Destroy(obj, 2.0f);
            //SpawnObject();
        }
        
    }
}
