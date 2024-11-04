using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        // Déplacement vers le haut
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // Détruire la balle si elle sort de l'écran
        if (transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Détruire le canard s'il est touché
        if (other.CompareTag("Duck"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameManager.instance.AddScore(10); // Ajouter des points
        }
    }
}
