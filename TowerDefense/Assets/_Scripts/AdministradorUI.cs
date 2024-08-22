using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdministradorUI : MonoBehaviour
{
    public GameObject canvasPrincipal;
    public GameObject menuGameOver;
    public SpawnerEnemigos referenciaSpawner;
    public Objetivo refernciaObjetivo;


    private void OnEnable()
    {
        refernciaObjetivo.EnObjetivoDestruido += MostrarMenuGameOver;
    }
    private void OnDisable()
    {
        refernciaObjetivo.EnObjetivoDestruido -= MostrarMenuGameOver;

    }

    public void MostraMenuFinOleada()
    {

    }
    public void OcultarMenuFinOleada()
    {

    }
    public void MostrarMenuGameOver()
    {
        menuGameOver.SetActive(true);
    }
    public void OcultarMenuGameOver()
    {
        menuGameOver.SetActive(false);

    }
    public void FinalizarJuego()
    {
        Application.Quit();
    }
    public void CargarMenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }
    public void ReintentarNivel()
    {
        int escenaActual = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(escenaActual);
    }

}
