using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class espadaScript : MonoBehaviour
{
    public float tiempoTotal = 1.5f;
    public float tiempoActual = 0;
    public float safeRange;
    public Transform espadaTransform;
    public Transform playerTransform;
    public float distanciaEspadaPlayer;
    public bool puedeCortar = false;

    // Start is called before the first frame update
    void Start()
    {
        tiempoTotal = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
       puedeCortar = IsOutOfSafeRange();
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Comprueba que la colisión es con el objeto deseado 
        comida comidaScript = collision.gameObject.GetComponent<comida>();

        if (IsOutOfSafeRange())
        {
            if (collision.gameObject.tag == "Comida")
            {
                comidaScript.CortarFruta();
                Debug.Log("collision");
                SoundManager.Instance.PlaySound(SoundManager.Instance.cortarComida);
                if (comidaScript.estaCortada == true)
                {
                    GameManager.Instance.SumarPuntos(comidaScript.puntajeC);
                }

            }
            if (collision.gameObject.tag == "plato")
            {
                SoundManager.Instance.PlaySound(SoundManager.Instance.cortarPlato);
                comidaScript.CortarFruta();
                Debug.Log("collision");

                StartCoroutine(Cuentaregresiva());
            }
        }
        
       
    }

    IEnumerator Cuentaregresiva()
    {
        yield return new WaitForSeconds(tiempoTotal);
        SceneManager.LoadScene("Perdiste");
        GameManager.Instance.yaToqueBoton = false; 
    }

    bool IsOutOfSafeRange()
    {
        distanciaEspadaPlayer = Vector3.Distance(espadaTransform.position, playerTransform.position);
        return distanciaEspadaPlayer > safeRange;
    }
}
