using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaUIManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> corazonesUI;
    [SerializeField] private Sprite corazonActivado;
    [SerializeField] private Sprite corazonDesactivado;
    [SerializeField] private CombatPvP playerCombat;

    private float corazonesActuales;

    public void InicializarCorazones()
    {
        corazonesActuales = playerCombat.life;

        for (int i = 0; i < corazonesUI.Count; i++)
        {
            Image imagenCorazon = corazonesUI[i].GetComponent<Image>();
            imagenCorazon.sprite = i < corazonesActuales ? corazonActivado : corazonDesactivado;
        }
    }

    public void QuitarCorazon()
    {
        if (corazonesActuales > 0)
        {
            corazonesActuales--;
            RestaCorazones(corazonesActuales);
            playerCombat.life = corazonesActuales;
        }
    }

    private void RestaCorazones(float indice)
    {
        if (indice >= 0 && indice < corazonesUI.Count)
        {
            Image imagenCorazon = corazonesUI[(int)indice].GetComponent<Image>();
            imagenCorazon.sprite = corazonDesactivado;
        }
    }
}
