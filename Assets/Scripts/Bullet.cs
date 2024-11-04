using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // D�placement vers le haut
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // D�truire la balle si elle sort de l'�cran
        if (transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // D�truire le canard s'il est touch�
        if (other.CompareTag("Duck"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameManager.instance.AddScore(10); // Ajouter des points
        }
    }
}
