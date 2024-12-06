using UnityEngine;

namespace UFF
{
    public class Movement : MonoBehaviour
    {

        private Vector3 direction;
        public float _speed;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            transform.position += direction * Time.deltaTime * _speed;

            direction = Vector2.zero;
        }

        public void RecieveDirection(Vector2 dir)
        {
            direction = dir;
        }
    }
}
