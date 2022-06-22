using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatGame
{
    public class SteeringWheel : PhysicInput
    {
        protected override void SetInput(float value)
        {
            shipInputHandler.Steering = value;
        }
    }
}