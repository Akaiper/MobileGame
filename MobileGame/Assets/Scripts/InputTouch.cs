using UnityEngine;

namespace UFF
{
    public class InputTouch : MonoBehaviour
    {
        
        private Vector3 initialTouch;
        private Vector3 currentTouch;

        private float limite;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            initialTouch = Vector3.negativeInfinity;
            limite = 5f;
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.touchCount > 0)
            {
                currentTouch = Input.GetTouch(0).position;

                if(initialTouch == Vector3.negativeInfinity)
                {
                    initialTouch = currentTouch;
                }

                if(Vector3.Distance(initialTouch,currentTouch) > limite)
                {

                }
            }
            else
            {
                initialTouch = Vector3.negativeInfinity;
            }
            
        }
    }
}
