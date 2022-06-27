using NWH.DWP2.ShipController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatGame
{
    public class PhysicShipInputProvider : ShipInputProvider
    {
        [SerializeField] PhysicInput steeringInput;
        [SerializeField] PhysicInput throttleInput;

        public override float Steering()
        {
            if (steeringInput != null)
            {
                return steeringInput.Value;
            }

            return 0;
        }

        public override float Throttle()
        {
            if (throttleInput != null)
            {
                return throttleInput.Value;
            }

            return 0;
        }
    }
}