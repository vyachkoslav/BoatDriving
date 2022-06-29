using NWH.DWP2.ShipController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RPMGauge : MonoBehaviour
{
    [SerializeField] List<Image> rpmStrips;
    [SerializeField] Color stripLitColor;
    [SerializeField] Color stripOffColor;

    [SerializeField] AdvancedShipController shipController;
    List<Engine> engines;
    float maxRPM;

    private void Start()
    {
        engines = shipController.engines;
        foreach (Engine engine in engines)
        {
            maxRPM += engine.maxRPM;
        }
    }
    private void Update()
    {
        if (rpmStrips.Count == 0 || engines.Count == 0)
            return;

        float rpmSum = 0f;
        foreach(Engine engine in engines)
        {
            if (engine.isOn)
                rpmSum += engine.RPM;
        }

        float rpmRatio = rpmSum / maxRPM;
        int stripsOnCount = Mathf.RoundToInt(rpmRatio * rpmStrips.Count);

        for (int i = 0; i < rpmStrips.Count; ++i)
        {
            if (i < stripsOnCount)
                rpmStrips[i].color = stripLitColor;
            else
                rpmStrips[i].color = stripOffColor;
            
        }
    }
}
