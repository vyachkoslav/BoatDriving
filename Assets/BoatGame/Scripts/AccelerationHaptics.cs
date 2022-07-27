using Bhaptics.Tact;
using Bhaptics.Tact.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationHaptics : MonoBehaviour
{
    const int motorCount = 20;
    const HapticClipPositionType front = HapticClipPositionType.VestFront;
    const HapticClipPositionType back = HapticClipPositionType.VestBack;
    List<DotPoint> frontPoints = new();
    List<DotPoint> backPoints = new();

    string frontKey = System.Guid.NewGuid().ToString();
    string backKey = System.Guid.NewGuid().ToString();
    const int duration = 100;
    const int yDotOffset = 3;
    const int rowSize = 4;

    [SerializeField] float angleToDirectionForward;
    Vector3 lastPosition;
    Vector3 lastSpeed;

    float time = duration * 0.001f;

    private void Start()
    {
        for(int i = 0; i < motorCount; ++i)
        {
            frontPoints.Add(new DotPoint(i, 0));
            backPoints.Add(new DotPoint(i, 0));
        }
    }
    void Update()
    {
        time -= Time.deltaTime;
        if(time < 0)
        {
            time = duration * 0.001f;

            var acceleration = GetLocalDirection(GetAcceleration());
            int forwardAcceleration = PrepareAcceleration(acceleration.z);
            int upAcceleration = PrepareAcceleration(acceleration.y * 10);
            int rightAcceleration = PrepareAcceleration(acceleration.x * 10);
            print(rightAcceleration);

            var yOffset = (yDotOffset + upAcceleration) * rowSize;
            for (int i = 0; i < motorCount; ++i)
            {
                frontPoints[i].Intensity = backPoints[i].Intensity = 0;

                bool isOutOfRow = rightAcceleration > 0 ? i % rowSize < rowSize - rightAcceleration : // to fix: back and front have different indexes of motors
                                                          i % rowSize > Mathf.Abs(rightAcceleration);
                if (i < yOffset || isOutOfRow)
                    continue;
                if (Random.Range(0f, 1f) < 0.65f)
                    continue;

                if (forwardAcceleration < 0)
                    frontPoints[i].Intensity = forwardAcceleration * -1;
                else if (forwardAcceleration > 0)
                    backPoints[i].Intensity = forwardAcceleration;
            }

            Submit(frontKey, frontPoints, front);
            Submit(backKey, backPoints, back);
        }
    }
    int PrepareAcceleration(float value)
    {
        if (value > -0.1f && value < 0.1f)
            value = 0;

        var acceleration = value >= 0 ? Mathf.CeilToInt(value) : Mathf.FloorToInt(value);
        acceleration = Mathf.Clamp(acceleration, -3, 3);

        return acceleration;
    }
    Vector3 GetLocalDirection(Vector3 dir)
    {
        return Quaternion.AngleAxis(angleToDirectionForward, Vector3.up) * transform.InverseTransformDirection(dir);
    }
    Vector3 GetAcceleration()
    {
        Vector3 positionChange = transform.position - lastPosition;
        Vector3 speed = positionChange * (duration * 0.001f);
        Vector3 acceleration = (speed - lastSpeed) * (duration * 0.001f);
        lastSpeed = speed;
        lastPosition = transform.position;
        return acceleration * 1000;
    }
    void Submit(string key, List<DotPoint> dotPointList, HapticClipPositionType clipPositionType)
    {
        BhapticsManager.GetHaptic()?.Submit(key, BhapticsUtils.ToPositionType(clipPositionType), dotPointList, duration);
    }
}
