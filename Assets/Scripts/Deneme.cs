using UnityEngine;

public class Deneme : MonoBehaviour
{
    public float speed = 10f;
    public float carpismaKuvveti = 5f; // Çarpışma kuvveti
    private void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = new Vector2(1, 1) * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.rigidbody;

            if (rb != null)
            {
                // Çarpışma noktasından diğer nesneye doğru bir yön vektörü hesapla
                Vector2 yon = collision.transform.position - transform.position;

                // Kuvveti uygula
                rb.AddForce(yon.normalized * carpismaKuvveti, ForceMode2D.Impulse);
            }

            // Kendi nesnenize de kuvvet uygulamak isterseniz:
            Rigidbody2D kendiRb = GetComponent<Rigidbody2D>();
            if (kendiRb != null)
            {
                Vector2 tersYon = transform.position - collision.transform.position;
                kendiRb.AddForce(tersYon.normalized * carpismaKuvveti, ForceMode2D.Impulse);
            }
        }
        // Çarpışan nesnenin Rigidbody 2D bileşenini al
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Wall"))
        {
            // �st veya alt duvarlara �arpt���nda y�n� de�i�tir
            if (collision.gameObject.name == "Wall (2)" || collision.gameObject.name == "Wall (3)")
            {
                GetComponent<Rigidbody2D>().linearVelocity = new Vector2(GetComponent<Rigidbody2D>().linearVelocity.x * -1, GetComponent<Rigidbody2D>().linearVelocity.y);

            }
            else
            {
                GetComponent<Rigidbody2D>().linearVelocity = new Vector2(GetComponent<Rigidbody2D>().linearVelocity.x, GetComponent<Rigidbody2D>().linearVelocity.y * -1);

            }
        }
    }
    /*
     *     public float donmeHizi = 10f; // Dönme hızı
     *     void OnCollisionEnter2D(Collision2D collision)
        {
            Rigidbody2D rb = collision.rigidbody;

            if (rb != null)
            {
                // Rastgele bir dönme yönü ve hızı belirle
                float donme = Random.Range(-donmeHizi, donmeHizi);

                // Dönme uygula
                rb.angularVelocity = donme;
            }

            Rigidbody2D kendiRb = GetComponent<Rigidbody2D>();
            if (kendiRb != null)
            {
                float kendiDonme = Random.Range(-donmeHizi, donmeHizi);
                kendiRb.angularVelocity = kendiDonme;
            }
        }
     */
}
