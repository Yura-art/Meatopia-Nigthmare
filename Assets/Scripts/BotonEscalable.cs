using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EscalarBoton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Escala")]
    public Vector3 escalaAlPasar = new Vector3(1.2f, 1.2f, 1.2f);
    private Vector3 escalaOriginal;

    [Header("Color")]
    public string colorHoverHex = "#FF9900"; // Cambia esto en el Inspector
    private Color colorHover;
    private Color colorOriginal;
    private Image imagenBoton;

    [Header("Sonido")]
    public AudioSource sonidoHover; // Sonido que se reproduce al pasar el mouse

    void Start()
    {
        escalaOriginal = transform.localScale;

        imagenBoton = GetComponent<Image>();
        if (imagenBoton != null)
        {
            colorOriginal = imagenBoton.color;
            ColorUtility.TryParseHtmlString(colorHoverHex, out colorHover);
        }
        else
        {
            Debug.LogWarning("Este objeto no tiene componente Image para cambiar el color.");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = escalaAlPasar;

        if (imagenBoton != null)
            imagenBoton.color = colorHover;

        if (sonidoHover != null && sonidoHover.clip != null)
            sonidoHover.Play();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = escalaOriginal;

        if (imagenBoton != null)
            imagenBoton.color = colorOriginal;
    }
}
