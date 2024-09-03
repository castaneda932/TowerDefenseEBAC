using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdminJuego : MonoBehaviour
{
    public int enemigosBaseDerrotado;
    public int enemigosJefeDerrotado;
    public int recursos;

    public delegate void RecursosModificados();
    public event RecursosModificados EnRecursosModificados;

    public void ModificarRecursos(int modificacion)
    {
        recursos += modificacion;
        if(EnRecursosModificados != null)
        {
            EnRecursosModificados();
        }
    }

    public void ResetValores()
    {
        enemigosBaseDerrotado = 0;
        enemigosJefeDerrotado = 0;
    }
}
