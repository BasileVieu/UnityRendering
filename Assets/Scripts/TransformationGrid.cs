using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TransformationGrid : MonoBehaviour
{
    public Transform prefab;

    public int gridResolution = 10;

    private Transform[] grid;

    private List<Transformation> transformations;

    private Matrix4x4 transformation;

    void Awake()
    {
        grid = new Transform[gridResolution * gridResolution * gridResolution];

        for (int i = 0, z = 0; z < gridResolution; z++)
        {
            for (int y = 0; y < gridResolution; y++)
            {
                for (int x = 0; x < gridResolution; x++, i++)
                {
                    grid[i] = CreateGridPoint(x, y, z);
                }
            }
        }

        transformations = new List<Transformation>();
    }

    void Update()
    {
        UpdateTransformation();

        for (int i = 0, z = 0; z < gridResolution; z++)
        {
            for (int y = 0; y < gridResolution; y++)
            {
                for (int x = 0; x < gridResolution; x++, i++)
                {
                    grid[i].localPosition = TransformPoint(x, y, z);
                }
            }
        }
    }

    void UpdateTransformation()
    {
        GetComponents(transformations);

        if (transformations.Count > 0)
        {
            transformation = transformations[0].Matrix;

            for (int i = 1; i < transformations.Count; i++)
            {
                transformation = transformations[i].Matrix * transformation;
            }
        }
    }

    Vector3 GetCoordinates(int _x, int _y, int _z)
    {
        return new Vector3(_x - (gridResolution - 1) * 0.5f,
            _y - (gridResolution - 1) * 0.5f,
            _z - (gridResolution - 1) * 0.5f);
    }

    Transform CreateGridPoint(int _x, int _y, int _z)
    {
        Transform point = Instantiate(prefab);
        point.localPosition = GetCoordinates(_x, _y, _z);
        point.GetComponent<MeshRenderer>().material.color = new Color((float) _x / gridResolution,
            (float) _y / gridResolution,
            (float) _z / gridResolution);

        return point;
    }

    Vector3 TransformPoint(int _x, int _y, int _z)
    {
        Vector3 coordinates = GetCoordinates(_x, _y, _z);

        return transformation.MultiplyPoint(coordinates);
    }
}