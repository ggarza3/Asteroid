using UnityEngine;
using UnityEngine.InputSystem;

public class BlastPattern : MonoBehaviour
{
    public Rigidbody2D rb;
    private GameObject tl;
    private GameObject br;
    public Vector2 dir;
    public float speed = 4;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Transform back = GameObject.Find("Spaceship").transform;
        rb.gravityScale = 0;
        dir = transform.position - back.position;
        tl = GameObject.Find("TopLeft");
        br = GameObject.Find("BottomRight");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = (Vector2) transform.position + dir * speed * Time.deltaTime;
        deletion();
    }

    private void deletion()
    {
        if(transform.position.x > br.transform.position.x)
        {
            Destroy(gameObject);
        }
        if(transform.position.x < tl.transform.position.x)
        {
            Destroy(gameObject);
        }
        if(transform.position.y < br.transform.position.y)
        {
            Destroy(gameObject);
        }
        if(transform.position.y > tl.transform.position.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag.Equals("Asteroid")){
            Destroy(gameObject);
        }
    }
}
