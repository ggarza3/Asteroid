using UnityEngine;


public class AsteroidSpawn : MonoBehaviour
{
    public bool isSmallest = false;
    public float speed;
    public Rigidbody2D rb;
    public GameObject smaller;
    private GameObject tl;
    private GameObject br;
    private Vector2 dir;
    System.Random rnd = new System.Random();
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float heading = rnd.Next(1, 11) / 10f;
        speed = rnd.Next(1, 5) / 10f;
        rb.gravityScale = 0;

        Transform target = GameObject.Find("Spaceship").transform;
        dir = target.position - transform.position;
        dir = new Vector2(dir.x, dir.y + rnd.Next(1, 10));
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
        if(collision.gameObject.tag.Equals("Blast")){
            if(isSmallest == false)
            {
                Instantiate(smaller, transform.position, Quaternion.identity);
                Instantiate(smaller, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
