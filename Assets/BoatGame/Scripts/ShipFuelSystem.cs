using NWH.DWP2.ShipController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatGame
{
    public class ShipFuelSystem : MonoBehaviour, IFuelSystem
    {
        [SerializeField] float maxFuel;
        [SerializeField] float fuelAmount = 0f;
        public float MaxFuel => maxFuel;
        public float FuelAmount
        {
            get { return fuelAmount; }
            private set
            {
                fuelAmount = Mathf.Clamp(value, 0, MaxFuel);
            }
        }
        public float FuelRatio => FuelAmount / MaxFuel;

        [Range(0, 1)] [SerializeField] float fuelConsumptionRatio;

        [SerializeField] AdvancedShipController shipController;
        List<Engine> engines;

        void Start()
        {
            engines = shipController.engines;
            FuelAmount = fuelAmount;
        }
        public float AddFuel(float amount)
        {
            float addedFuel = Mathf.Clamp(FuelAmount + amount, 0, MaxFuel) - FuelAmount;
            FuelAmount += addedFuel;
            return addedFuel;
        }
        void Update()
        {
            if(FuelRatio > 0f)
            {
                if (!shipController.IsAwake)
                    shipController.Wake();

                float rpmSum = 0f;
                foreach (Engine engine in engines)
                {
                    if(engine.isOn)
                        rpmSum += engine.RPM;
                }
                FuelAmount -= rpmSum * fuelConsumptionRatio * Time.deltaTime * 0.0001f;
            }
            else if (shipController.IsAwake)
                shipController.Sleep();
        }
    }
}