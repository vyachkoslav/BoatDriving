using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BoatGame {
    public class FuelPump : MonoBehaviour
    {
        [SerializeField] float fuelInSecond;
        private void OnTriggerStay(Collider other)
        {
            IFuelSystem objectWithFuel;
            if (!other.TryGetComponent(out objectWithFuel))
                objectWithFuel = other.GetComponentInParent<IFuelSystem>();

            if(objectWithFuel != null)
            {
                objectWithFuel.AddFuel(fuelInSecond * Time.deltaTime);
            }
        }
    }
}