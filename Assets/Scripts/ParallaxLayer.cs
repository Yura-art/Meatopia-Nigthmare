using UnityEngine;

[System.Serializable]
public class ParallaxLayer
{
    public Transform layerTransform;
    public float intensity = 1f;
    public bool zoomEffect = false;
    public float zoomAmplitude = 0.5f;
    public float zoomSpeed = 1f;

    private Vector3 initialPosition;

    public void Initialize()
    {
        if (layerTransform != null)
            initialPosition = layerTransform.localPosition;
    }

    public void UpdateLayer(Vector2 inputDir)
    {
        if (layerTransform == null) return;

        Vector3 offset = new Vector3(inputDir.x, inputDir.y, 0f) * intensity;
        Vector3 target = initialPosition + offset;

        if (zoomEffect)
        {
            float zoom = Mathf.Sin(Time.time * zoomSpeed) * zoomAmplitude;
            target += new Vector3(0, zoom, 0);
        }

        layerTransform.localPosition = Vector3.Lerp(layerTransform.localPosition, target, 0.1f);
    }
}

