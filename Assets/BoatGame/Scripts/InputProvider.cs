using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

namespace BoatGame
{
    public class InputProvider : MonoBehaviour
    {
        public static float Select(XRController xrInput)
        {
            var select = xrInput.selectUsage;

            float value;
            xrInput.inputDevice.TryReadSingleValue(select, out value);
            return value;
        }
    }
}