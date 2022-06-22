using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatGame
{
    public class SteeringWheel : MonoBehaviour
    {
        [SerializeField] float maxAngle;
        float defaultRotation;
        // Start is called before the first frame update
        void Start()
        {
            defaultRotation = transform.localEulerAngles.z;
            print(defaultRotation);
        }

        // Update is called once per frame
        void Update()
        {
            
            
        }
        public void RotateWheel(float angle)
        {
            float z = Mathf.Clamp(transform.localEulerAngles.z + angle, defaultRotation - maxAngle, defaultRotation + maxAngle);

            z -= transform.localEulerAngles.z;
            transform.Rotate(new Vector3(0, 0, z));
        }
    }
}