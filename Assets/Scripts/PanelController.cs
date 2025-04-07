using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    [SerializeField] GameObject  panelPausa, panelGameover, panelJuego;

    private void OnEnable()
    {
        //GameManager.Instancia.JuegoIniciado += MostrarPanelDeJuego;
        GameManager.Instancia.JuegoPausado += MostrarPanelPausa;
        GameManager.Instancia.JuegoReanudado += MostrarPanelDeJuego;
        GameManager.Instancia.JuegoFinalizado += MostrarPanelGameOver;
    }
    public void MostrarPanelGameOver()
    {
        panelGameover.SetActive(true);
        panelPausa.SetActive(false);
        //panelInicio.SetActive(false);
        panelJuego.SetActive(false);
    }
    public void MostrarPanelPausa()
    {
        panelPausa.SetActive(true);
        panelGameover.SetActive(false);
        //panelInicio.SetActive(false);
        panelJuego.SetActive(false);
    }
    public void MostrarPanelDeJuego()
    {
        panelJuego.SetActive(true);
        panelGameover.SetActive(false);
        panelPausa.SetActive(false);
        //panelInicio.SetActive(false);
    }
}
