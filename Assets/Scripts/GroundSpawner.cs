using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject ground;
    public float spawnRate = 2;
    private float timer = 0;
    
    //Spawn the ground
    private void spawnGround()
    {
        Instantiate(ground, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
    }

    void Start()
    {
        spawnGround();
    }

    void Update()
    {
        if (timer < spawnRate)
            timer += Time.deltaTime;
        else
        {
            spawnGround();
            timer = 0;
        }
    }
}
