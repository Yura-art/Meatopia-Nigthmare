using UnityEngine;

public class CamaraSeguirJugador : MonoBehaviour
{
    public Transform jugador; // Arrastra aqu� el objeto del jugador en el Inspector
    public Vector3 offset = new Vector3(0f, 1.5f, -10f); // Ajusta la posici�n relativa de la c�mara

    void LateUpdate()
    {
        if (jugador != null)
        {
            transform.position = jugador.position + offset;
        }
    }
}
