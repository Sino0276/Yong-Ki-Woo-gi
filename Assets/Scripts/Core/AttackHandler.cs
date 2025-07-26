using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core
{
    public class AttackHandler : MonoBehaviour
    {
        private DragonController dragonController;
        private Sprite defaultSprite;
        private SpriteRenderer headSpriteRenderer;
        [SerializeField] private Sprite attackSprite;
        
        private void Awake()
        {
            dragonController = GetComponentInParent<DragonController>();
            headSpriteRenderer = GetComponent<SpriteRenderer>();
            defaultSprite = headSpriteRenderer.sprite;
        }

        public void Attack()
        {
            float damage = Managers.Utility.damageCalculator.CalculateDamage(dragonController, out bool isCritical);
            Projectile projectile = Instantiate(Managers.Game.projectilePrefab, transform.position, Quaternion.identity);
            projectile.transform.localScale = isCritical ? new Vector3(1.5f, 1.5f, 1) : Vector3.one;
            List<Sprite> projectileSprites = Managers.Resource.LoadProjectileSprites(dragonController.DragonData.projectileSpritePath);
            projectile.Init(damage, isCritical, projectileSprites);
            
            StartCoroutine(AttackAnimation());
        }

        private IEnumerator AttackAnimation()
        {
            headSpriteRenderer.sprite = attackSprite;
            yield return new WaitForSeconds(0.1f);
            headSpriteRenderer.sprite = defaultSprite;
        }
    }
}