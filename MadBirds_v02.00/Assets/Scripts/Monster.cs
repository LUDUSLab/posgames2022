using System.Collections;
using UnityEngine;

namespace Game
{
    public class Monster : MonoBehaviour
    {
        [SerializeField] private Sprite _deadSprite;
        [SerializeField] private ParticleSystem _particleSystem;
        
        private bool _hasDied;

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (ShouldDieFromCollision(col))
            {
                StartCoroutine(Die());
            }
        }

        private bool ShouldDieFromCollision(Collision2D col)
        {
            if (_hasDied)
            {
                return false;
            }
            Birds birds = col.gameObject.GetComponent<Birds>();
            if (birds != null)
            {
                return true;
            }

            if (col.contacts[0].normal.y < -0.5)
            {
                return true;
            }
            
            return false;
        }
        
        private IEnumerator Die()
        {
            _hasDied = true;
            GetComponent<SpriteRenderer>().sprite = _deadSprite;
            _particleSystem.Play();
            
            yield return new WaitForSeconds(0.7f);
            gameObject.SetActive(false);
        }
    }
}

