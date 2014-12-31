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

    public static float GravityFactor = 0.85f;
    public static float GravitationalConstant = 9.81f;
    private BoxCollider2D _boxCollider;

    public void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
    }

    public void Update()
    {
        var x = 0f;
        if (GravityBinding == GravityType.BoundToLeft)
            x = Mathf.Max(MinX + _boxCollider.size.x, transform.position.x - (GravitationalConstant * GravityFactor * Time.deltaTime));
        else
            x = Mathf.Min(MaxX - _boxCollider.size.x, transform.position.x + (GravitationalConstant * GravityFactor * Time.deltaTime));
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
