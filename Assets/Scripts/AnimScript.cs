using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour
{
    public Animator anim;
    public PuntoDisparo puntodisparoScript; 
    void Awake()
    {
        anim = GetComponent<Animator>();
        puntodisparoScript = FindObjectOfType<PuntoDisparo>();
    }


    public void AnimacionAbrir()
    {
        anim.SetTrigger("Abrir");

    }

    public void AnimacionCerrar()
    {
        anim.SetTrigger("Cerrar");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
