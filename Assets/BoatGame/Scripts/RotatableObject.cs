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
        public float CurrentAngle { get; private set; }

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
            angle = ClampAngle(GetRotatingAngle() + angle, defaultRotation - maxAngle, defaultRotation + maxAngle); // angle not out of max range
            angle -= GetRotatingAngle();

            if (Mathf.Abs(CurrentAngle + angle) <= MaxAngle)
                CurrentAngle += angle;

            if (Mathf.Abs(CurrentAngle) < maxAngle)
                axis.SetRotation(defaultRotation + CurrentAngle);

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