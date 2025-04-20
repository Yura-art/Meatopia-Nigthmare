using UnityEngine;

public class GeneradorLuciernagas : MonoBehaviour
{
    public GameObject prefabLuciernaga;
    public int cantidad = 20;
    public Vector2 area = new Vector2(10f, 5f);

    void Start()
    {
        for (int i = 0; i < cantidad; i++)
        {
            Vector3 pos = new Vector3(
                Random.Range(-area.x / 2, area.x / 2),
                Random.Range(-area.y / 2, area.y / 2),
                0
            );

            GameObject luciernaga = Instantiate(prefabLuciernaga, transform.position + pos, Quaternion.identity, transform);

            // Cambiar color aleatorio suave
            SpriteRenderer sr = luciernaga.GetComponent<SpriteRenderer>();
            if (sr != null)
            {
                sr.color = new Color(
                    Random.Range(0.8f, 1f),
                    Random.Range(0.8f, 1f),
                    Random.Range(0.5f, 1f),
                    Random.Range(0.5f, 1f)
                );
            }
        }
    }
}

