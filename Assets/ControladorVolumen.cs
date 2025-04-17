using UnityEngine;
using UnityEngine.UI;

public class ControlVolumen : MonoBehaviour
{
    public Slider sliderVolumen;

    void Start()
    {
        // Carga el volumen guardado si existe
        if (PlayerPrefs.HasKey("VolumenJuego"))
        {
            float volumenGuardado = PlayerPrefs.GetFloat("VolumenJuego");
            sliderVolumen.value = volumenGuardado;
            AudioListener.volume = volumenGuardado;
        }
        else
        {
            sliderVolumen.value = 1f;
            AudioListener.volume = 1f;
        }

        // Asigna la función al evento del slider
        sliderVolumen.onValueChanged.AddListener(CambiarVolumen);
    }

    public void CambiarVolumen(float valor)
    {
        AudioListener.volume = valor;
        PlayerPrefs.SetFloat("VolumenJuego", valor);
    }
}

