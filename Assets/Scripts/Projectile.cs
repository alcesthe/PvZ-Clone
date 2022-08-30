using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] float damage = 20f;
    [SerializeField] GameObject deathVFX;

    void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var health = collision.GetComponent<Health>();
        var attacker = collision.GetComponent<Attacker>();

        if (attacker && health)
        {
            TriggerDeathVFX();
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }

    private void TriggerDeathVFX()
    {
        if (!deathVFX) { return; }
        GameObject deathVFXObject = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, 1);
    }
}
