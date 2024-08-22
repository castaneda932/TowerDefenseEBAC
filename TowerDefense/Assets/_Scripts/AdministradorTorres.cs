using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorTorres : MonoBehaviour
{
    public AdministradorToques referenciaAdminToques; //refererncia al gameobject de administrador toques

    public enum TorreSeleccionada// agregar las torres que tengamos
    {
        torre1, torre2, torre3, torre4, torre5
    }

    public TorreSeleccionada torreSeleccionada; // instanciar el enum
    public List<GameObject> prefabsTorres; //almacenamos las torres a instanciar

    private void OnEnable()
    {
        referenciaAdminToques.EnPlataformaTocada += CrearTorre;
    }

    

    private void OnDisable()
    {
        referenciaAdminToques.EnPlataformaTocada -= CrearTorre;

    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CrearTorre(GameObject plataforma)
    {
        if (plataforma.transform.childCount == 0)// en caso de que no exista una torre en la plataforma ahora instanciar la torre
        {
            Debug.Log("creando torre"); // mandar mensaje a la consola
            int indiceTorre = (int)torreSeleccionada;
            Vector3 posParaInstanciar = plataforma.transform.position; //instanciar en la plataforma seleccionada
            posParaInstanciar.y += 0.5f;//altura para instanciar la torre
            GameObject torreInstancida = Instantiate<GameObject>(prefabsTorres[indiceTorre], posParaInstanciar, Quaternion.identity);
            torreInstancida.transform.SetParent(plataforma.transform);
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
