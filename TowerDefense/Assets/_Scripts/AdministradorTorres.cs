using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorTorres : MonoBehaviour
{
    public AdministradorToques referenciaAdminToques; //refererncia al gameobject de administrador toques
    public AdminJuego referenciaAdminJuego; //referencia al administrador del juego
    public SpawnerEnemigos referenciaSpawner; // para validar que el juego ya se inicio
    public GameObject Objetivo; //para calcular la distancia entre el objetivo y los enemigos.

    public enum TorreSeleccionada// agregar las torres que tengamos
    {
        torre1, torre2, torre3, torre4, torre5
    }

    public TorreSeleccionada torreSeleccionada; // instanciar el enum
    public List<GameObject> prefabsTorres; //almacenamos las torres a instanciar
    public List<GameObject> torresInstanciadas; //almacenar las torres

    public delegate void EnemigoObjetivoActualizado();
    public event EnemigoObjetivoActualizado EnEnemigoObjetivoActualizado;

    private void OnEnable()
    {
        referenciaAdminToques.EnPlataformaTocada += CrearTorre;
        referenciaSpawner.EnOleadaIniciada += ActualizarObjetivo; //cuando empiece se actualize el enemigo mas cercano
        torresInstanciadas = new List<GameObject>(); //inicializar nuestar lista de torres instanciadas
    }

    

    private void OnDisable()
    {
        referenciaAdminToques.EnPlataformaTocada -= CrearTorre;
        referenciaSpawner.EnOleadaIniciada -= ActualizarObjetivo;

    }

   

    private void ActualizarObjetivo()
    {
        if (referenciaSpawner.laOleadaHaIniciado)
        {
            float distanciaMasCorta = float.MaxValue;
            GameObject enemigoMasCercano = null;
            foreach(GameObject enemigo in referenciaSpawner.EnemigosGenerados)
            {
                float dist = Vector3.Distance(enemigo.transform.position , Objetivo.transform.position);
                if (dist < distanciaMasCorta)
                {
                    distanciaMasCorta = dist;
                    enemigoMasCercano = enemigo;
                }
            }
            if (enemigoMasCercano != null)
            {
                foreach (GameObject torre in torresInstanciadas)
                {
                    torre.GetComponent<TorreBase>().enemigo = enemigoMasCercano;
                    torre.GetComponent<TorreBase>().Disparar();
                }
                if (EnEnemigoObjetivoActualizado != null)
                {
                    EnEnemigoObjetivoActualizado();
                }
            }
        }
        Invoke("ActualizarObjetivo", 1);
    }

    private void CrearTorre(GameObject plataforma)
    {
        int costo = torreSeleccionada switch
        {
            TorreSeleccionada.torre1 => 400,
            TorreSeleccionada.torre2 => 600,
            TorreSeleccionada.torre3 => 800,
            TorreSeleccionada.torre4 =>1000,
            TorreSeleccionada.torre5 => 1200,
            _ => 0
        };
        if (plataforma.transform.childCount == 0 && referenciaAdminJuego.recursos >= costo)// en caso de que no exista una torre en la plataforma ahora instanciar la torre
        {
            referenciaAdminJuego.ModificarRecursos(-costo);

            Debug.Log("creando torre"); // mandar mensaje a la consola
            int indiceTorre = (int)torreSeleccionada;
            Vector3 posParaInstanciar = plataforma.transform.position; //instanciar en la plataforma seleccionada
            posParaInstanciar.y += 0.5f;//altura para instanciar la torre
            GameObject torreInstancida = Instantiate<GameObject>(prefabsTorres[indiceTorre], posParaInstanciar, Quaternion.identity);
            torreInstancida.transform.SetParent(plataforma.transform);

            torresInstanciadas.Add(torreInstancida);
        }
    }

    public void ConfigurarTorre(int torre)
    {
        if(Enum.IsDefined(typeof(TorreSeleccionada), torre)) 
        {
            torreSeleccionada = (TorreSeleccionada)torre;
        }
        else
        {
            Debug.Log("esa torre no esta definida");
        }
    }

}
