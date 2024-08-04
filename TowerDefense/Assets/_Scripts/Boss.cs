using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour
{
    public GameObject objetivo;
    public int vida = 100;

    public Animator anim;

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
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Objetivo")
        {
            anim.SetBool("IsMoving", false);
            anim.SetTrigger("OnObjectiveReached");
        }
    }
    public void Danar()
    {
        objetivo?.GetComponent<Objetivo>().RecibirDano(40);
    }

    public void RecibirDano(int dano = 5)
    {
        vida -= dano;
    }
}
