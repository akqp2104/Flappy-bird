using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Out of bounds of the game
public class Limits : MonoBehaviour
{
    public LogicScript logic;
    public GameObject bird;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        logic.gameOver();
        Destroy(bird);
    }
}
