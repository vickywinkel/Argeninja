using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class espadaScript : MonoBehaviour
{
    public float tiempoTotal = 1.5f;
    public float tiempoActual = 0;
    bool empezo = false;

    // Start is called before the first frame update
    void Start()
    {
        tiempoTotal = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Comprueba que la colisión es con el objeto deseado 
        comida comidaScript = collision.gameObject.GetComponent<comida>();

        if (collision.gameObject.tag == "Comida")
        {
            comidaScript.CortarFruta();
            Debug.Log("collision");
            SoundManager.Instance.PlaySound(SoundManager.Instance.cortarComida);
            if (comidaScript.estaCortada == true)
            {
                GameManager.Instance.SumarPuntos(comidaScript.puntajeC);}
        
        }
        if (collision.gameObject.tag == "plato")
        {
            SoundManager.Instance.PlaySound(SoundManager.Instance.cortarPlato);
            comidaScript.CortarFruta();
            Debug.Log("collision");

            StartCoroutine(Cuentaregresiva()); 
        }
       
    }

    IEnumerator Cuentaregresiva()
    {
        yield return new WaitForSeconds(tiempoTotal);
        SceneManager.LoadScene("Perdiste");
        GameManager.Instance.yaToqueBoton = false; 
    }
}
