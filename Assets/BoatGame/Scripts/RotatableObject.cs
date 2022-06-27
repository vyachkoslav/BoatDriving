using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatGame
{
    public class RotatableObject : MonoBehaviour
    {
        [SerializeField] Axis axis;
        
        [SerializeField] float maxAngle;
        public float MaxAngle => maxAngle;
        float defaultRotation;
        public float CurrentAngle => -current;
        float current;

        void Start()
        {
            defaultRotation = GetRotatingAngle();
        }
        public void SetPosition(Vector3 position)
        {
            Vector3 newPosOnAxis = axis.ClosestPointOnAxis(position);
            
            var upDir = axis.Up;
            var newDir = newPosOnAxis - axis.Center;

            float angle = Vector3.SignedAngle(upDir, newDir, axis.Forward);
            angle = ClampAngle(GetRotatingAngle() + angle, defaultRotation - maxAngle, defaultRotation + maxAngle);
            angle -= GetRotatingAngle();

            if (Mathf.Approximately(Mathf.Abs(angle), maxAngle * 2))
                current *= -1;
            else
                current += angle;
            current = Mathf.Clamp(current, -maxAngle, maxAngle);

            if (maxAngle < 180 || Mathf.Abs(current) < maxAngle)
                axis.Rotate(angle);

            
        }
        float GetRotatingAngle()
        {
            return axis.GetAngle();
        }
        static float ClampAngle(float angle, float min, float max)
        {
            float start = (min + max) * 0.5f - 180;
            float floor = Mathf.FloorToInt((angle - start) / 360) * 360;
            min += floor;
            max += floor;
            return Mathf.Clamp(angle, min, max);
        }
    }
}