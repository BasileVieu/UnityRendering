﻿using UnityEngine;

public abstract class Transformation : MonoBehaviour
{
    public Vector3 Apply(Vector3 _point)
    {
        return Matrix.MultiplyPoint(_point);
    }

    public abstract Matrix4x4 Matrix { get; }
}