using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatGame
{
    public class GrabbableObject : MonoBehaviour
    {
        [SerializeField] Transform transformToGrab;
        public Transform TransformToGrab => transformToGrab;
        public Transform point1, point2, point3;

        [SerializeField] float maxAngle;
        float defaultRotation;
        // Start is called before the first frame update
        void Start()
        {
            defaultRotation = transformToGrab.localEulerAngles.z;
        }
        public void SetPosition(Vector3 position)
        {
            Plane wheelNormal = new Plane(point1.position, point2.position, point3.position);
            Vector3 pointB = wheelNormal.ClosestPointOnPlane(position);
            
            var toPointA = point2.position - transformToGrab.position;
            var toPointB = pointB - transformToGrab.position;
            float angle = Vector3.Angle(toPointA, toPointB);
            angle *= Mathf.Sign(Vector3.Cross(toPointA, toPointB).y);

            float z = Mathf.Clamp(transformToGrab.localEulerAngles.z + angle, defaultRotation - maxAngle, defaultRotation + maxAngle);
            z -= transformToGrab.localEulerAngles.z;
            transformToGrab.Rotate(new Vector3(0, 0, z));
        }
    }
}