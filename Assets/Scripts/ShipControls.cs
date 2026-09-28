using UnityEngine;
using UnityEngine.InputSystem;

public class ShipControls : MonoBehaviour
{

    public Rigidbody2D rb;
    //private Vector2 initLocation;
    public GameObject front;
    public GameObject blast;
    public GameObject tl;
    public GameObject br;
    //private Vector2 front;
    
    public float shipSpeed = 3;
    public float rotationSpeed = 400f;
    
    private Vector2 direction;
    private Vector2 movement;
    private Vector2 start;
    private Vector3 rotDir;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        start = transform.position;
        front.transform.position = new Vector2(transform.position.x, transform.position.y + 1.6f);
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        actuallyMoving();
        wrapAround();
    }

     void actuallyMoving()
    {
        //forward
        transform.position = (Vector2) transform.position + movement.magnitude * direction * shipSpeed * Time.deltaTime;
        //turn
        transform.eulerAngles = transform.eulerAngles + rotDir * rotationSpeed * Time.deltaTime * -1;
    }

    void OnMove(InputValue value)
    {      
        direction = (Vector2) front.transform.position - (Vector2) transform.position;
        Debug.Log(direction);
        movement = value.Get<Vector2>();
    }

    void OnTurn(InputValue value)
    {
        rotDir = value.Get<Vector3>();
    }

    void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            Instantiate(blast, front.transform.position, Quaternion.identity);
        }
    }

    private void wrapAround()
    {
        if(transform.position.x > br.transform.position.x)
        {
            transform.position = new Vector3(tl.transform.position.x, transform.position.y, transform.position.z);
        }
        if(transform.position.x < tl.transform.position.x)
        {
            transform.position = new Vector3(br.transform.position.x, transform.position.y, transform.position.z);
        }
        if(transform.position.y < br.transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, tl.transform.position.y, transform.position.z);
        }
        if(transform.position.y > tl.transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, br.transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject[] asters = GameObject.FindGameObjectsWithTag("Asteroid");

        foreach(GameObject oids in asters)
        {
            Destroy(oids);
        }

        transform.position = start;
        transform.eulerAngles = Vector3.zero;
    }
}
