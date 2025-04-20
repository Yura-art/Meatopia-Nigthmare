using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    public ParallaxLayer[] layers;

    void Start()
    {
        foreach (var layer in layers)
        {
            layer.Initialize();
        }
    }

    void Update()
    {
        Vector2 mouseDir = GetNormalizedMousePosition();

        foreach (var layer in layers)
        {
            layer.UpdateLayer(mouseDir);
        }
    }

    Vector2 GetNormalizedMousePosition()
    {
        float x = (Input.mousePosition.x / Screen.width - 0.5f) * 2f;
        float y = (Input.mousePosition.y / Screen.height - 0.5f) * 2f;
        return new Vector2(x, y);
    }
}

