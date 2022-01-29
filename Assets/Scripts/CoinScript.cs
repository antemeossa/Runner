using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{

    [SerializeField]
    private float rotationSpeed = -.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationSpeed));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RunnerManager.instance.score++;
            Debug.Log(RunnerManager.instance.score);
            Destroy(gameObject);
        }
    }
}
