using System.Collections;
using UnityEngine;

namespace Core
{
    public class AttackHandler : MonoBehaviour
    {
        private Sprite defaultSprite;
        private SpriteRenderer headSpriteRenderer;
        [SerializeField] private Sprite attackSprite;
        
        private void Awake()
        {
            headSpriteRenderer = GetComponent<SpriteRenderer>();
            defaultSprite = headSpriteRenderer.sprite;
        }

        public void Attack()
        {
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