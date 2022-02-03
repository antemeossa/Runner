using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;


    public GameObject road;


    public List<GameObject> roadArr;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("road"))
        {

            moveRoad();            
            
        }
    }

    private void moveRoad()
    {
        
        GameObject movedRoad = roadArr[0];
        roadArr.Remove(movedRoad);
        float newZ = roadArr[roadArr.Count - 1].GetComponent<RoadScript>().spawnPos.position.z;
        movedRoad.transform.position = new Vector3(0, 0, newZ);
        movedRoad.GetComponent<RoadScript>().reSpawnObjects(); 
        roadArr.Add(movedRoad);
        
    }
   
}
