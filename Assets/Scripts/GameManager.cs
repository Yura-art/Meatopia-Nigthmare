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

    private void Awake()
    {
        if (Instancia == null)
        {
            Instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Time.timeScale = 1f;
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
}
