using UnityEngine;
using UnityEngine.InputSystem;

public class CanonController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float moveSpeed = 5f;
    public Transform firePoint;
    public float fireCooldown = 0.5f; // Cooldown en secondes

    private float lastFireTime;
    public InputActionReference MoveAction;
    public InputActionReference ShootAction;

    private void OnEnable()
    {
        MoveAction.action.Enable();
        ShootAction.action.Enable();
        ShootAction.action.performed += ctx => FireBullet();
    }

    private void OnDisable()
    {
        MoveAction.action.Disable();
        ShootAction.action.Disable();
        ShootAction.action.performed -= ctx => FireBullet();
    }

    void Update()
    {
        // Déplacement du canon de gauche à droite
        Vector2 moveInput = MoveAction.action.ReadValue<Vector2>();
        float move = moveInput.x * moveSpeed * Time.deltaTime;
        transform.Translate(move, 0, 0);

        // Limite les déplacements aux bords de l'écran
        float clampedX = Mathf.Clamp(transform.position.x, -8f, 8f);
        transform.localPosition = new Vector3(clampedX, transform.position.y, 0);
    }

    private void FireBullet()
    {
        // Tirer un projectile verticalement avec la touche espace
        if (Time.time >= lastFireTime + fireCooldown && GameManager.instance.isGameActive)
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            lastFireTime = Time.time;
        }
    }
}
