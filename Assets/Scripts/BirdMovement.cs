using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public Rigidbody2D bird;
    public float flapStrenght;
    public LogicScript logic;
    public bool isAlive = true;
    public AudioSource wingFlap;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        wingFlap = GetComponent<AudioSource>();
        Fly();

    }

    // Bird movement
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAlive || Input.GetMouseButtonDown(0) && isAlive)
        {
            Fly();
        }
    }

    private void Fly()
    {
        bird.velocity = Vector2.up * flapStrenght;
        wingFlap.Play();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        isAlive = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            logic.gameOver();
            isAlive = false;
        }
    }
}
