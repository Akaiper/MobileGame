using UnityEngine;

namespace UFF
{
    [CreateAssetMenu(fileName = "TesteInput", menuName = "Scriptable Objects/TesteInput")]
    public class TesteInput : ScriptableObject
    {
        public KeyCode[] key;

        public bool GetkeyJumpDown()
        {   
            foreach(KeyCode a in key)
            {
                return Input.GetKeyDown(a);
            }
            return true;
        }
    }
}
