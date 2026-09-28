using System;
using UnityEditor.Rendering;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public float cardinal = 0;
    //North = 1, East = 2, South = 3, West = 4
    public GameObject tl;
    public GameObject br;
    public float speed = 0;
    private bool isFacingRight;
    private bool isFacingDown;
    public GameObject asteroid;
    System.Random rnd = new System.Random();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("makeAsteroid", 2, rnd.Next(5, 13));
        if(cardinal % 2 == 1)
        {
            isFacingRight = true;
        }
        if(cardinal % 2 == 0)
        {
            isFacingDown = true;
        }
        speed = rnd.Next(4, 16);
    }

    // Update is called once per frame
    void Update()
    {
        if(cardinal % 2 == 1)
        {
            sideSide();
        }
        if(cardinal % 2 == 0)
        {
            upDown();
        }
    }

    void sideSide()
    {
        if (isFacingRight)
        {
            transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        }
        if (transform.position.x > br.transform.position.x)
        {
            isFacingRight = false;
        }
        if(transform.position.x < tl.transform.position.x)
        {
            isFacingRight = true;
        }
    }

    void upDown()
    {
        if (isFacingDown)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
        }
        if (transform.position.y < br.transform.position.y)
        {
            isFacingDown = false;
        }
        if(transform.position.y > tl.transform.position.y)
        {
            isFacingDown = true;
        }
    }

    void makeAsteroid()
    {
        Instantiate(asteroid, transform.position, Quaternion.identity);
    }
}
