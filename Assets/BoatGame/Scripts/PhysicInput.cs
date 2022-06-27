using NWH.Common.SceneManagement;
using NWH.DWP2.ShipController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatGame
{
    public class PhysicInput : MonoBehaviour
    {
        [SerializeField] RotatableObject inputObject;

        public float Value => GetValue();

        float GetValue()
        {
            if (!inputObject)
                return 0f;

            float normalizedAngle = 0f;
            if (inputObject.MaxAngle != 0)
            {
                normalizedAngle = inputObject.CurrentAngle / inputObject.MaxAngle;
            }

            return normalizedAngle;
        }
    }
}