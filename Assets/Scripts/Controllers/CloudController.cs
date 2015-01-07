using System.Collections.Generic;
using UnityEngine;

public class CloudController : BaseBehavior
{
    private float _cloudSpeed;
    private float _cloudSpeedMod;

    public void Start()
    {
        _cloudSpeed = Random.Range(1f, 5f);
        _cloudSpeedMod = Random.Range(0f, 1f);

        var scale = Random.Range(1f, 2f);
        transform.localScale = new Vector3(scale, scale, scale);
    }

    public void Update()
    {
        transform.position = new Vector3(transform.position.x - (_cloudSpeed * _cloudSpeedMod), transform.position.y, transform.position.z);
    }
}
