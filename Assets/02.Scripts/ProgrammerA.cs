using UnityEngine;

namespace DevA
{
    public class ProgrammerA : MonoBehaviour
    {
        int num = 0;

        public int num2 = 1;

        private int num3 = 2;

        [SerializeField] int num4 = 3;

        [SerializeField]
        private int num5 = 4;

        void Update()
        {
            Debug.Log(this.num2);
        }
    }
}
