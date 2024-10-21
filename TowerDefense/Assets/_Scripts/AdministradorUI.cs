using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdministradorUI : MonoBehaviour
{
    public GameObject canvasPrincipal;
    public GameObject menuGameOver;
    public GameObject menuOlaGanada;
    public GameObject mensajeFinOla;
    public SpawnerEnemigos referenciaSpawner;
    public Objetivo refernciaObjetivo;
    public AdminJuego referenciaAdminJuego;
    public TMPro.TMP_Text textoRecursos;
    public TMPro.TMP_Text textoOleada;
    public TMPro.TMP_Text textoEnemigos;
    public TMPro.TMP_Text textoJefes;




    public void OnEnable()
    {
        refernciaObjetivo.EnObjetivoDestruido += MostrarMenuGameOver;
        referenciaSpawner.EnOleadaIniciada += ActualizarOla;
        referenciaSpawner.EnOleadaTerminada += MostrarMensajeUltimoEnemigo;
        referenciaSpawner.EnOleadaGanada += MostrarMenuOlaGanada;
        referenciaAdminJuego.EnRecursosModificados += ActualizarRecursos;

    }

    public void ActualizarRecursos()
    {
        textoRecursos.text = $"Recursos: {referenciaAdminJuego.recursos}";
    }

    public void MostrarMensajeUltimoEnemigo()
    {
        mensajeFinOla.SetActive(true);
        Invoke("OcultarMensajeUltimoEnemigo", 3);
    }
    public void OcultarMensajeUltimoEnemigo()
    {
        mensajeFinOla.SetActive(false);
    }

    public void MostrarMenuOlaGanada()
    {
        textoEnemigos.text = $"Enemigos: \t {referenciaAdminJuego.enemigosBaseDerrotado}";
        textoJefes.text = $"Jefes: \t\t {referenciaAdminJuego.enemigosJefeDerrotado}";
        menuOlaGanada.SetActive(true);

    }

    public void OcultarMenuOlaGanada()
    {
        menuOlaGanada.SetActive(false);
    }

    public void ActualizarOla()
    {
        textoOleada.text = $"Ola: {referenciaSpawner.oleada}";
        OcultarMenuOlaGanada();
    }

    public void OnDisable()
    {
        refernciaObjetivo.EnObjetivoDestruido -= MostrarMenuGameOver;
        referenciaSpawner.EnOleadaIniciada -= ActualizarOla;
        referenciaSpawner.EnOleadaTerminada  -= MostrarMensajeUltimoEnemigo;
        referenciaSpawner.EnOleadaGanada -= MostrarMenuOlaGanada;
        referenciaAdminJuego.EnRecursosModificados -= ActualizarRecursos;

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
