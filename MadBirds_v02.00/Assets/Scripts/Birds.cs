using System;
using UnityEngine;

namespace Game
{
    public class Birds : MonoBehaviour
    {
        [SerializeField] private float _launchForce = 500;
        
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
            transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        }

        private void Update()
        {
            
        }
    }
}

