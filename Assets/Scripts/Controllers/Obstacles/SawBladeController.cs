using System.Collections.Generic;
using UnityEngine;

public class SawBladeController : BaseBehavior
{
    public int MaxRPM = 2000;
    public float Acceleration = 50f;
    public float Throttle = 1f;

    private float _currentRPM;

    public void Update()
    {
        var currentRotation = transform.rotation.eulerAngles;
        transform.rotation = Quaternion.EulerAngles(new Vector3(currentRotation.x, currentRotation.y, currentRotation.z += RevolutionsPerDelta()));
    }

    public void FixedUpdate()
    {
        if (_currentRPM < MaxRPM) _currentRPM += Acceleration * Throttle;
        if (_currentRPM > MaxRPM) _currentRPM = MaxRPM;
    }

    private float RevolutionsPerDelta()
    {
        return (_currentRPM / 60) * Time.deltaTime;
    }
}
