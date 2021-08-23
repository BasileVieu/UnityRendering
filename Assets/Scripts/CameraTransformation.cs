using UnityEngine;

public class CameraTransformation : Transformation
{
    public float focalLength = 1.0f;
    
    public override Matrix4x4 Matrix
    {
        get
        {
            Matrix4x4 matrix = new Matrix4x4();
            matrix.SetRow(0, new Vector4(focalLength, 0.0f, 0.0f, 0.0f));
            matrix.SetRow(1, new Vector4(0.0f, focalLength, 0.0f, 0.0f));
            matrix.SetRow(2, new Vector4(0.0f, 0.0f, 1.0f, 0.0f));
            matrix.SetRow(3, new Vector4(0.0f, 0.0f, 0.0f, 1.0f));

            return matrix;
        }
    }
}