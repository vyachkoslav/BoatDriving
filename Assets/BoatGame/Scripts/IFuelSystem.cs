using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatGame
{
    public interface IFuelSystem
    {
        public float MaxFuel { get; }
        public float FuelAmount { get; }
        public float FuelRatio { get; }

        public float AddFuel(float amount);
    }
}
