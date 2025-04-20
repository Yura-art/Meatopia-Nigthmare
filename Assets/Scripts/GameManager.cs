using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia;

    public delegate void EstadosJuegoDelegado();
    public EstadosJuegoDelegado JuegoIniciado;
    public EstadosJuegoDelegado JuegoPausado;
    public EstadosJuegoDelegado JuegoReanudado;
    public EstadosJuegoDelegado JuegoFinalizado;

    [Header("Referencias UI")]
    public GameObject panelMenuPrincipal;
    public GameObject panelSettings;

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject);
        }

        Time.timeScale = 1f;
    }

    private void Start()
    {
        // Asegúrate de que el menú principal se muestre al inicio
        if (panelMenuPrincipal != null && panelSettings != null)
        {
            panelMenuPrincipal.SetActive(true);
            panelSettings.SetActive(false);
        }
    }

    public void IniciarJuego()
    {
        JuegoIniciado?.Invoke();
        SceneManager.LoadScene("world-1");
        Time.timeScale = 1;
    }

    public void PausarJuego()
    {
        JuegoPausado?.Invoke();
        Time.timeScale = 0;
    }

    public void ReanudarJuego()
    {
        JuegoReanudado?.Invoke();
        Time.timeScale = 1;
    }

    public void FinalizarJuego()
    {
        JuegoFinalizado?.Invoke();
        Time.timeScale = 1;
        SceneManager.LoadScene("UIMenu");
    }

    public void CerrarJuego()
    {
        Application.Quit();
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene("UIMenu");
    }

    // Métodos para cambiar entre paneles
    public void AbrirSettings()
    {
        panelMenuPrincipal.SetActive(false);
        panelSettings.SetActive(true);
    }

    public void VolverAlMenu()
    {
        panelSettings.SetActive(false);
        panelMenuPrincipal.SetActive(true);
    }
}
