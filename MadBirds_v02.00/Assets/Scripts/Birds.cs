using System;
using System.Collections;
using UnityEngine;

namespace Game
{
    public class Birds : MonoBehaviour
    {
        [SerializeField] private float _launchForce = 500f;
        [SerializeField] private float _maxDragDistance = 3.5f;
        
        private Vector2 _startposition;
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Start is called before the first frame update
        private void Start()
        {
            _startposition = _rigidbody2D.position;
            _rigidbody2D.isKinematic = true;
        }

        private void OnMouseDown()
        {
            _spriteRenderer.color = Color.red;
        }

        private void OnMouseUp() 
        {
            Vector2 currentposition = _rigidbody2D.position;
            Vector2 direction = _startposition - currentposition;
            direction.Normalize();

            _rigidbody2D.isKinematic = false;
            _rigidbody2D.AddForce(direction * _launchForce);

            _spriteRenderer.color = Color.white;
        }

        private void OnMouseDrag()
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 desiredPosition = mousePosition;

            float distance = Vector2.Distance(desiredPosition, _startposition);
            if (distance > _maxDragDistance)
            {
                Vector2 direction = desiredPosition - _startposition;
                direction.Normalize();
                desiredPosition = _startposition + (direction * _maxDragDistance);
            }
            
            if (desiredPosition.x > _startposition.x)
            {
                desiredPosition.x = _startposition.x;
            }
            
            _rigidbody2D.position = desiredPosition;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            StartCoroutine(resetAfterDelay());
        }

        private IEnumerator resetAfterDelay()
        {
            yield return new WaitForSeconds(3f);
            _rigidbody2D.position = _startposition;
            _rigidbody2D.isKinematic = true;
            _rigidbody2D.velocity = Vector2.zero;
        }

        private void Update()
        {
            
        }
    }
}

