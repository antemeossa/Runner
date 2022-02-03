using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    Vector2 startingPos;
    private void Awake()
    {
        startingPos.x = transform.position.x;
        startingPos.y = transform.position.y;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("projectile"))
        {
            GetComponent<BoxCollider>().enabled= false;
            StartCoroutine(shake());
        }
    }

    IEnumerator shake()
    {
        float currentT = 0;
        float desiredT = .5f;

        while (currentT < desiredT)
        {

            transform.localScale -= Vector3.one * Time.deltaTime * 4;
            currentT += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
        
    }
}
