using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public class TorreBase : MonoBehaviour
{
    public GameObject enemigo;
    public GameObject prefabBala;
    public List<GameObject> puntasCanon;

    private void Update()
    {
        if (enemigo != null)
        {
            Apuntar();
        }
    }
    public void Apuntar()
    {

        transform.LookAt(enemigo.transform); //lookat toma z = 1 del gameobject y lo voltea al enemigo
    }

    public virtual void Disparar()
    {
        foreach (GameObject punta in puntasCanon)
        {
            var tempBala = Instantiate<GameObject>(prefabBala, punta.transform.position, Quaternion.identity);
            tempBala.GetComponent<Bala>().destino= enemigo.transform.position;
        }
    }
}
