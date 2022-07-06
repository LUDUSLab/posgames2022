using System;
using UnityEngine;

namespace Game
{
    public class Birds : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
        }

        private void OnMouseDown()
        {
            GetComponent<SpriteRenderer>().color = Color.red;
        }

        private void OnMouseUp()
        {
            GetComponent<SpriteRenderer>().color = Color.white;
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

