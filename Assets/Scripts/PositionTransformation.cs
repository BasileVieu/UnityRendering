using UnityEngine;

public class PositionTransformation : Transformation
{
    public Vector3 position;

    public override Matrix4x4 Matrix
    {
        get
        {
            Matrix4x4 matrix = new Matrix4x4();
            matrix.SetRow(0, new Vector4(1.0f, 0.0f, 0.0f, position.x));
            matrix.SetRow(1, new Vector4(0.0f, 1.0f, 0.0f, position.y));
            matrix.SetRow(2, new Vector4(0.0f, 0.0f, 1.0f, position.z));
            matrix.SetRow(3, new Vector4(0.0f, 0.0f, 0.0f, 1.0f));

            return matrix;
        }
    }
}