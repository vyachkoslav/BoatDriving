using NWH.Common.SceneManagement;
using NWH.DWP2.ShipController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatGame
{
    public abstract class PhysicInput : MonoBehaviour
    {
        [SerializeField] RotatableObject inputObject;
        protected ShipInputHandler shipInputHandler;
        private void FixedUpdate()
        {
            if(shipInputHandler == null)
                shipInputHandler = ((AdvancedShipController)VehicleChanger.ActiveVehicle).input;

            float normalizedAngle = 0f;
            if (inputObject.MaxAngle != 0)
            {
                normalizedAngle = inputObject.CurrentAngle / inputObject.MaxAngle;
            }

            SetInput(normalizedAngle);
        }

        protected abstract void SetInput(float value);
    }
}