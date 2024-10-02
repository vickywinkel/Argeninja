using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class comida : MonoBehaviour
{
    public GameObject mitades;
    public GameObject entera;

    public int puntajeC;

    private float tiempodestr = 3.5f;
    public bool estaCortada = false;    

    public float radius = 8.0F;
    public float power = 20.0F;   

    public bool cortastePlato = false;

    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       


    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "piso")
        {
            DestruyoObjeto();
            Debug.Log("pisoo");
            if (estaCortada == false)
            {
                if (gameObject.tag != "plato")
                {
                    //vida = vida - 1;
                    estaCortada = true;
                    Debug.Log("perdiste una vida");
                    GameManager.Instance.PerderVida();
                }
            }
        }
   
    }


    public void CortarFruta()
    {

        mitades.SetActive(true);
        entera.SetActive(false);
        estaCortada = true;
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        Debug.Log("Colliders: " + colliders.Length);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(power, explosionPos, radius, 3.0F);

                // Aumentar la componente de velocidad en el eje X
                Vector3 velocity = rb.velocity;
                velocity.x *= 200f;  // Ajusta este valor para incrementar la fuerza en X
                rb.velocity = velocity;

                Debug.Log("Aplica fuerza");
            }

        }
        
    }

    void DestruyoObjeto()
    {
        Destroy(gameObject, tiempodestr);
    }

}
