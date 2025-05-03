using UnityEngine;

namespace Mehmet
{
    public class PickupFloat : MonoBehaviour
    {
        public float floatAmplitude = 0.1f;
        public float floatFrequency = 1.5f;
        public float rotateSpeed = 60f;

        private Vector3 startPos;

        void Start()
        {
            startPos = transform.position;
        }

        void Update()
        {
            float yOffset = Mathf.Sin(Time.time * floatFrequency) * floatAmplitude;
            transform.position = startPos + new Vector3(0f, yOffset, 0f);

            transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);
        }
    }
}
