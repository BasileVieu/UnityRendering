using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class DeferredFogEffect : MonoBehaviour
{
    public Shader deferredFog;

    [NonSerialized] private Material fogMaterial;

    [NonSerialized] private Camera deferredCamera;

    [NonSerialized] private Vector3[] frustumCorners;

    [NonSerialized] private Vector4[] vectorArray;

    [ImageEffectOpaque]
    void OnRenderImage(RenderTexture _source, RenderTexture _destination)
    {
        if (fogMaterial == null)
        {
            deferredCamera = GetComponent<Camera>();
            frustumCorners = new Vector3[4];
            vectorArray = new Vector4[4];
            fogMaterial = new Material(deferredFog);
        }

        deferredCamera.CalculateFrustumCorners(new Rect(0.0f, 0.0f, 1.0f, 1.0f), deferredCamera.farClipPlane, deferredCamera.stereoActiveEye, frustumCorners);

        vectorArray[0] = frustumCorners[0];
        vectorArray[1] = frustumCorners[3];
        vectorArray[2] = frustumCorners[1];
        vectorArray[3] = frustumCorners[2];
        fogMaterial.SetVectorArray("_FrustumCorners", vectorArray);

        Graphics.Blit(_source, _destination, fogMaterial);
    }
}