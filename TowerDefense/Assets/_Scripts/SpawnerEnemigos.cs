using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SpawnerEnemigos : MonoBehaviour
{
    public List<GameObject> prefabsEnemigos; //almacenar la lista de prefabs de enemigos
    public int oleada;// numero de oleada que estamos
    public List<int> enemigosPorOleada; //numeros de enemigos por oleada

    private int enemigosDuranteEstaOleada;

    public bool laOleadaHaIniciado;
    public List<GameObject> EnemigosGenerados;

    public delegate void EstadoOleada();
    public event EstadoOleada EnOleadaIniciada;
    public event EstadoOleada EnOleadaTerminada;
    public event EstadoOleada EnOleadaGanada;



    // Start is called before the first frame update
    void Start()
    {
        oleada = 0;
        ConfigurarCantidadDeEnemigos();
        
        
    }
    private void FixedUpdate()
    {
        if(laOleadaHaIniciado && EnemigosGenerados.Count ==0)
        {
            GanarOla();
        }
    }

    public void EmpezarOla()
    {
        laOleadaHaIniciado = true;
        if(EnOleadaIniciada != null)
        {
            EnOleadaIniciada();
        }
        ConfigurarCantidadDeEnemigos();
        InstanciarEnemigo();
    }

    private void GanarOla()
    {
        if(laOleadaHaIniciado && EnOleadaGanada != null)
        {
            EnOleadaGanada();
            laOleadaHaIniciado = false;
        }
    }

    public void TerminarOla()
    {
        if(EnOleadaTerminada != null)
        {
            EnOleadaTerminada();
        }
    }
    public void ConfigurarCantidadDeEnemigos()
    {
        enemigosDuranteEstaOleada = enemigosPorOleada[oleada];
    }
    public void InstanciarEnemigo()
    {
        int indiceAleatorio = Random.Range(0, prefabsEnemigos.Count);
        var EnemgigoTemporal = Instantiate<GameObject>(prefabsEnemigos[indiceAleatorio], transform.position, Quaternion.identity);
        EnemigosGenerados.Add(EnemgigoTemporal);

        enemigosDuranteEstaOleada--;
        if (enemigosDuranteEstaOleada < 0)
        {
            oleada++;
            ConfigurarCantidadDeEnemigos();
            TerminarOla();
            return;
        }
        Invoke("InstanciarEnemigo", 2);
       

    }

}
