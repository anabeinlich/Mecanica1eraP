using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float force;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Debug.Log("Shoot!!!");

        GameObject bulletClone = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);

        Rigidbody bulletRB = bulletClone.GetComponent<Rigidbody>();

        bulletRB.AddRelativeForce(transform.up * force, ForceMode.Impulse);

        Destroy(bulletClone, 3f);
    }
}
