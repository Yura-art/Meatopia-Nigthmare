using UnityEngine;

public class MovimientoLuciernaga : MonoBehaviour
{
    public float velocidad = 1f;
    public float amplitud = 1f;
    private Vector3 posicionInicial;
    private SpriteRenderer sr;

    void Start()
    {
        posicionInicial = transform.position;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float desplazamientoY = Mathf.Sin(Time.time * velocidad) * amplitud;
        float desplazamientoX = Mathf.Cos(Time.time * velocidad * 0.5f) * (amplitud / 2f);
        transform.position = posicionInicial + new Vector3(desplazamientoX, desplazamientoY, 0);

        if (sr != null)
        {
            float t = Mathf.PingPong(Time.time * 0.5f, 1f);
            sr.color = Color.Lerp(new Color(1f, 0.8f, 0.5f, 0.5f), new Color(0.5f, 1f, 1f, 0.7f), t);
        }
    }

    
}

