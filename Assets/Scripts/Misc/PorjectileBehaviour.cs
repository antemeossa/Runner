using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorjectileBehaviour : MonoBehaviour
{

    [SerializeField]
    private float projectileSpeed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position  += new Vector3(0,0, projectileSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
