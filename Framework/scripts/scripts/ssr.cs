using UnityEngine;

[ExecuteInEditMode]
public class ssr : MonoBehaviour
{
    public Material material;
    public float reflectionStrength = 0.5f;

    private Camera reflectionCamera;
    private RenderTexture reflectionTexture;

    void Start()
    {
        reflectionCamera = GetComponent<Camera>();
        reflectionTexture = new RenderTexture(reflectionCamera.pixelWidth, reflectionCamera.pixelHeight, 0);
        reflectionCamera.targetTexture = reflectionTexture;
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (material != null)
        {
            material.SetTexture("_ReflectionTex", reflectionTexture);
            material.SetFloat("_ReflectionStrength", reflectionStrength);
            Graphics.Blit(source, destination, material);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }
}