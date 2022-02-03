using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript : MonoBehaviour
{

    [SerializeField]
    private Transform pos1,pos2,pos3;

    private float movSpeed = 10f;

    public Transform spawnPos;

    public GameObject coin,obstacle,extraAmmo;

    private Rigidbody rb;

    private int randomPos;
    private int randomObjectInt;

    public GameObject[] objects;
    private Transform[] posArr;

    private GameObject spawnedObject;
    // Start is called before the first frame update

    private void Awake()
    {
        objects = new GameObject[3];
        objects[0] = coin;
        objects[1] = obstacle;
        objects[2] = extraAmmo;

        posArr = new Transform[3];
        posArr[0] = pos1;
        posArr[1] = pos2;
        posArr[2] = pos3;

    }
    void Start()
    {


        rb = GetComponent<Rigidbody>();

        randomPos = Random.Range(0, 2);
        randomObjectInt = Random.Range(0, 2);

        spawnedObject = Instantiate(objects[randomObjectInt], posArr[randomPos]);
    }

    // Update is called once per frame
    void Update()
    {
        moveRoad(); 
    }

    private void moveRoad()
    {
        if (RunnerManager.instance.gameStarted)
        {
            Vector3 forwardMove = -(transform.forward * movSpeed * Time.fixedDeltaTime);
            rb.MovePosition(rb.position + forwardMove);

        }
    }

    public void reSpawnObjects()
    {
        Destroy(spawnedObject);

        rb = GetComponent<Rigidbody>();

        randomPos = Random.Range(0, 3);
        randomObjectInt = Random.Range(0, 3);

        Instantiate(objects[randomObjectInt], posArr[randomPos]);
    }

    



}
