using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 sonhız;
    public static float ilky, ilkx;
    public bool asagı, saga, sola, yukarı;
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(1, 1) * speed;
        // Rastgele bir y�nde ba�lat
        ilkx=transform.position.x;
        ilky=transform.position.y;
    }
    private void Update()
    {
        if (ilky > transform.position.y)
        {
            yukarı = false;
            asagı= true;
        }
        else
        {
            asagı = false;
            yukarı = true;
        }
        if (ilkx > transform.position.x)
        {
            sola = true;
            saga = false;
        }
        else
        {
            sola = false;
            saga = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(collision.transform.position.x > transform.position.x&&collision.transform.position.y>transform.position.y)
            {
                GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-1, -1) * speed;
            }
            if(collision.transform.position.x > transform.position.x && collision.transform.position.y < transform.position.y)
            {
                GetComponent<Rigidbody2D>().linearVelocity = new Vector2(-1, 1) * speed;
            }
            if((collision.transform.position.x < transform.position.x && collision.transform.position.y < transform.position.y))
            {
                GetComponent<Rigidbody2D>().linearVelocity = new Vector2(1, -1) * speed;
            }
            if ((collision.transform.position.x < transform.position.x && collision.transform.position.y > transform.position.y))
            {
                GetComponent<Rigidbody2D>().linearVelocity = new Vector2(1, 1) * speed;
            }

            Debug.Log("sa");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Wall"))
        {
            // �st veya alt duvarlara �arpt���nda y�n� de�i�tir
            if(collision.gameObject.name=="Wall (2)"||collision.gameObject.name=="Wall (3)")
            {
                GetComponent<Rigidbody2D>().linearVelocity = new Vector2(GetComponent<Rigidbody2D>().linearVelocity.x * -1, GetComponent<Rigidbody2D>().linearVelocity.y);
                ilkx=transform.position.x;
            }
            else
            {
                GetComponent<Rigidbody2D>().linearVelocity = new Vector2(GetComponent<Rigidbody2D>().linearVelocity.x, GetComponent<Rigidbody2D>().linearVelocity.y * -1);
                ilky=transform.position.y;
            }
        }
    }
}
