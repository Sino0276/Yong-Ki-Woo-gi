using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float damage;
    private bool isCritical;
    private Vector3 direction;
    private List<Sprite> projectileSprites;

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float speed = 1f;

    public void Init(float damage, bool isCritical, List<Sprite> projectileSprites)
    {
        this.damage = damage;
        this.isCritical = isCritical;
        this.projectileSprites = projectileSprites;
    }

    private void Start()
    {
        direction = Managers.Game.enemySpawnPoint.transform.position - transform.position;
        StartCoroutine(ProjectileAnimation());
    }

    private void Update()
    {
        transform.Translate(direction * (speed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    private IEnumerator ProjectileAnimation()
    {
        int index = 0;
        
        while (true)
        {
            spriteRenderer.sprite = projectileSprites[index];
            yield return new WaitForSeconds(0.1f);
            index++;
            if (index >= projectileSprites.Count)
            {
                index = 0;
            }
        }
    }
}
