using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatGame
{
    public class GasLever : PhysicInput
    {
        protected override void SetInput(float value)
        {
            shipInputHandler.Throttle = value;
        }
    }
}