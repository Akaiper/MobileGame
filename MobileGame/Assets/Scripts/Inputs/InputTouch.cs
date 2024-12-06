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
        private float threshold;

        private Vector2 dir;

        public UnityEvent<Vector2> TouchDirection;
       
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            TouchSimulation.Enable();

            initialTouch = Vector2.zero;
            
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.touchCount > 0)
            {
                currentTouch = Input.GetTouch(0).position;

              

                if(Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    initialTouch = currentTouch;
                }
                

                if(Vector2.Distance(initialTouch,currentTouch) > threshold)
                {
                    dir = currentTouch - initialTouch;

                    dir = dir.normalized;

                    if(math.abs(dir.x) > math.abs(dir.y))
                    {
                        if(dir.x > 0)
                        {
                            TouchDirection?.Invoke(new Vector2(1,0));
                            
                        }
                        else if(dir.x < 0)
                        {
                            TouchDirection?.Invoke(new Vector2(-1,0));
                            
                        }
                    }
                    else if(math.abs(dir.x) < math.abs(dir.y))
                    {
                        if(dir.y > 0)
                        {
                            TouchDirection?.Invoke(new Vector2(0,1));
                            
                        }
                        else if(dir.y < 0)
                        {
                            TouchDirection?.Invoke(new Vector2(0,-1));
                           
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
