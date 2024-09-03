using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : EnemigoBase
{
    private void Awake()
    {
        vida = 10;
        _dano = 10;
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        ReferenciaAdminJuego.enemigosBaseDerrotado++;
    }
}
