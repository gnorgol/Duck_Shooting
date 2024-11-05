using UnityEngine;

public class CanonController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float moveSpeed = 5f;
    public Transform firePoint;
    public float fireCooldown = 0.5f; // Cooldown en secondes

    private float lastFireTime;

    void Update()
    {
        // Déplacement du canon de gauche à droite
        float move = Input.GetAxis("Horizontal") * -moveSpeed * Time.deltaTime;
        transform.Translate(0, move, 0);

        // Limite les déplacements aux bords de l'écran
        float clampedX = Mathf.Clamp(transform.position.x, -8f, 8f);
        transform.position = new Vector3(clampedX, transform.position.y, 0);

        // Tirer un projectile verticalement avec la touche espace
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && Time.time >= lastFireTime + fireCooldown)
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            lastFireTime = Time.time;
        }
    }
}
