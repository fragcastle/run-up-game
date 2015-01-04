using UnityEngine;
using System.Collections;

public class DieWhenBelowTheFold : BaseBehavior
{
    public float Buffer = 0;

    void Start()
    {

    }

    void Update()
    {
        if (IsBelowTheFold(Buffer))
        {
            Destroy(gameObject);
        }
    }
}
