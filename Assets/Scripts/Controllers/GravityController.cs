using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GravityController : BaseBehavior
{
    public enum GravityType
    {
        BoundToLeft,
        BoundToRight
    }

    public GravityType GravityBinding;

    public void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, ApplyGravity());
    }

    public void Update()
    {
        transform.position = ApplyGravity();
    }

    private float GravityEffect
    {
        get
        {
            return Constants.Gravity * Constants.GravityFactor * Time.deltaTime;
        }
    }

    private Vector3 ApplyGravity()
    {
        var x = transform.position.x;
        if (GravityBinding == GravityType.BoundToLeft)
            x = Mathf.Max(MinX, x - GravityEffect);
        else
            x = Mathf.Min(MaxX, x + GravityEffect);
        return new Vector3(x, transform.position.y, transform.position.z);
    }
}
