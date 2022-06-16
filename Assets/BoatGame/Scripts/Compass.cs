using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BoatGame
{
    public class Compass : MonoBehaviour
    {
        [SerializeField] TMPro.TextMeshProUGUI output;
        void Update()
        {
            if (output)
                output.SetText(GetDirection(transform));
        }
        public static float GetCompassAngle(Transform obj)
        {
            float angle = Vector3.SignedAngle(Vector3.forward, obj.forward, Vector3.up);
            if (angle < 0)
            {
                angle += 360;
            }
            return angle;
        }
        public static string GetDirection(Transform obj)
        {
            int[] dirs = { 0, 45, 90, 135, 180, 225, 270, 315 };
            string[] names = { "N", "NW", "W", "SW", "S", "SE", "E", "NE" };

            float angle = GetCompassAngle(obj);
            for (int i = 0; i < dirs.Length; ++i)
            {
                if (Mathf.Abs(angle - dirs[i]) <= 22.5)
                {
                    return names[i];
                }
            }
            return names[0];
        }
    }
}