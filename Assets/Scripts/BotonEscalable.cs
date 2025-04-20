using UnityEngine;
using UnityEngine.EventSystems;

public class BotonEscalable : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 escalaOriginal;
    public Vector3 escalaAgrandada = new Vector3(1.2f, 1.2f, 1f);

    void Start()
    {
        escalaOriginal = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = escalaAgrandada;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = escalaOriginal;
    }
}

