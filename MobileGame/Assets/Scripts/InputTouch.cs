using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem.EnhancedTouch;

namespace UFF
{
    public class InputTouch : MonoBehaviour
    {
        
        private Vector2 initialTouch;
        private Vector2 currentTouch;
        private Vector2 endTouch;

        [SerializeField]
        //botar pra ser uma linhazinha q mexe
        private float limite;

        private Vector2 dir;

        public UnityEvent<Vector2> TouchDirection;
       
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            TouchSimulation.Enable();

            initialTouch = Vector2.zero;
            //limite = 5f;
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.touchCount > 0)
            {
                currentTouch = Input.GetTouch(0).position;

               Debug.Log("a");

                if(Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    initialTouch = currentTouch;
                }
                

                if(Vector2.Distance(initialTouch,currentTouch) > limite)
                {
                    dir = currentTouch - initialTouch;

                    dir = dir.normalized;

                    if(math.abs(dir.x) > math.abs(dir.y))
                    {
                        if(dir.x > 0)
                        {
                            TouchDirection?.Invoke(new Vector2(1,0));
                            Debug.Log("right");
                        }
                        else if(dir.x < 0)
                        {
                            TouchDirection?.Invoke(new Vector2(-1,0));
                            Debug.Log("left");
                        }
                    }
                    else if(math.abs(dir.x) < math.abs(dir.y))
                    {
                        if(dir.y > 0)
                        {
                            TouchDirection?.Invoke(new Vector2(0,1));
                            Debug.Log("up");
                        }
                        else if(dir.y < 0)
                        {
                            TouchDirection?.Invoke(new Vector2(0,-1));
                            Debug.Log("down");
                        }
                    }
                }
            }
            else
            {
                initialTouch = Vector2.zero;
            }
            
        }
    }
}
