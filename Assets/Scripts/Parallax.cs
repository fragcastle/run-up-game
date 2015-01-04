using UnityEngine;
using System.Collections;

public class Parallax : BaseBehavior {
    public float ParallaxFactor;
    public bool ParallaxX = true;
    public bool ParallaxY = true;

    private Vector3 _lastCameraPosition;

    public void Update()
    {
        if (_lastCameraPosition != Vector3.zero)
        {
            var delta = Camera.main.transform.position - _lastCameraPosition;
            Move(delta);
        }

        _lastCameraPosition = Camera.main.transform.position;
    }

    public void Move(Vector3 delta)
    {
        Vector3 newPos = transform.localPosition;
        if (ParallaxX) newPos.x -= delta.x * ParallaxFactor;
        if (ParallaxY) newPos.y -= delta.y * ParallaxFactor;

        transform.localPosition = newPos;
    }
}
