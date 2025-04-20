using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EscalarBoton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Vector3 escalaAlPasar = new Vector3(1.2f, 1.2f, 1.2f);
    private Vector3 escalaOriginal;

    void Start()
    {
        escalaOriginal = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = escalaAlPasar;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = escalaOriginal;
    }
}

