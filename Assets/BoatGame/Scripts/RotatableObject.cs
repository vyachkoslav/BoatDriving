using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatGame
{
    public class RotatableObject : MonoBehaviour
    {
        [SerializeField] Transform transformToGrab;
        public Transform TransformToGrab => transformToGrab;
        public Transform point2, point3;
        
        enum Axis { x, y, z }
        [SerializeField] Axis rotatingAxis;
        Vector3 filter;
        [SerializeField] float maxAngle;
        public float MaxAngle => maxAngle;
        float defaultRotation;
        public float CurrentAngle => GetRotatingAngle() - defaultRotation;

        // Start is called before the first frame update
        void Start()
        {
            defaultRotation = GetRotatingAngle();
            switch (rotatingAxis)
            {
                case Axis.x:
                    filter = Vector3.right;
                    break;
                case Axis.y:
                    filter = Vector3.up;
                    break;
                case Axis.z:
                    filter = Vector3.forward;
                    break;
            }
        }
        public void SetPosition(Vector3 position)
        {
            Plane wheelNormal = new Plane(transformToGrab.position, point2.position, point3.position);
            Vector3 pointB = wheelNormal.ClosestPointOnPlane(position);
            
            var toPointA = point2.position - transformToGrab.position;
            var toPointB = pointB - transformToGrab.position;
            float angle = Vector3.SignedAngle(toPointA, toPointB, transformToGrab.forward);

            angle = Mathf.Clamp(GetRotatingAngle() + angle, defaultRotation - maxAngle, defaultRotation + maxAngle);
            angle -= GetRotatingAngle();
            transformToGrab.Rotate(angle * filter);
        }
        float GetRotatingAngle()
        {
            switch (rotatingAxis)
            {
                case Axis.x:
                    return transformToGrab.localEulerAngles.x;
                case Axis.y:
                    return transformToGrab.localEulerAngles.y;
                case Axis.z:
                    return transformToGrab.localEulerAngles.z;
                default:
                    return transformToGrab.localEulerAngles.x;
            }
        }
    }
}