using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoBase : MonoBehaviour, IAtacante, IAtacable
{
    public GameObject objetivo;
    public int vida = 100;
    public int _dano = 5;

    public Animator anim;

    private void OnEnable()
    {
        objetivo = GameObject.Find("Objetivo");
        objetivo.GetComponent<Objetivo>().EnObjetivoDestruido += detener;

    }
    private void OnDisable()
    {
        objetivo.GetComponent<Objetivo>().EnObjetivoDestruido -= detener;
    }

   

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<NavMeshAgent>().SetDestination(objetivo.transform.position);
        anim = GetComponent<Animator>();
        anim.SetBool("IsMoving", true);
    }

    // Update is called once per frame
    void Update()
    {
        if(vida <=0)
        {
            anim.SetTrigger("OnDeath");
            GetComponent<NavMeshAgent>().SetDestination(transform.position);
            Destroy(gameObject, 3);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Objetivo")
        {
            anim.SetBool("IsMoving", false);
            anim.SetTrigger("OnObjectiveReached");
        }
    }
    private void detener()
    {
        anim.SetTrigger("OnObjectDestroyed");
        GetComponent<NavMeshAgent>().SetDestination(transform.position);
    }
    public void Danar(int dano)
    {
        if(dano == 0) dano = _dano;
        objetivo?.GetComponent<Objetivo>().RecibirDano(40);
    }

    public void RecibirDano(int dano = 5)
    {
        vida -= dano;
    }
}
