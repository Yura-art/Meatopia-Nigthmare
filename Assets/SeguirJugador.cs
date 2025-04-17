using UnityEngine;

public class CamaraSeguirJugador : MonoBehaviour
{
    public Transform jugador; // Arrastra aquí el objeto del jugador en el Inspector
    public Vector3 offset = new Vector3(0f, 1.5f, -10f); // Ajusta la posición relativa de la cámara

    void LateUpdate()
    {
        if (jugador != null)
        {
            transform.position = jugador.position + offset;
        }
    }
}
