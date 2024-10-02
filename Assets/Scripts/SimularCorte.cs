using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SimularCorte : MonoBehaviour
{
    comida comidaScript;
    bool cortastePlato;
    public float tiempoTotal = 1.5f;
    private float tiempoActual = 0;
    bool empezo = false;
    // Start is called before the first frame update
    void Start()
    {
        comidaScript = GetComponent<comida>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            comidaScript.CortarFruta();
            if (gameObject.tag == "plato")
            {
                SoundManager.Instance.PlaySound(SoundManager.Instance.cortarPlato);
                cortastePlato = true;
            }
            else if (comidaScript.estaCortada == true)
            {
                SoundManager.Instance.PlaySound(SoundManager.Instance.cortarComida);
                GameManager.Instance.SumarPuntos(comidaScript.puntajeC);
            }            
        }

        if (cortastePlato)
        {
            if (tiempoActual < tiempoTotal)
            {
                tiempoActual += Time.deltaTime;
            }
            else
            {
                SceneManager.LoadScene("Perdiste");
            }
        }
    }
}
