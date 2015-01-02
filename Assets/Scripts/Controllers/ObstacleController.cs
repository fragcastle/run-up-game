using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class ObstacleController : BaseBehavior
{
    public bool KillPlayerInstantly;

    public void OnTriggerEnter2D(Collider2D collision2D)
    {
        if (KillPlayerInstantly)
        {
            collision2D.gameObject.GetComponent<PlayerController>().Die();
        }
    }
}
