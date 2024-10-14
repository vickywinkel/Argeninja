using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tirarscript : MonoBehaviour
{
    public GameObject[] comidas; //creamos el array
    public GameObject comidaAzar;

    public PuntoDisparo[] puntosDisparo;

    public float freq = 4.5f; //cada 4 segs salen los babys prefabs 
    public float freq2; 

    public float thrust = 13;
    public float fuerza = 5.5f;

    public float tiempoTotal = 3f;
    private float tiempoActual = 0;

    public bool listo = false;
   
    // Start is called before the first frame update
    void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        CuentaReg cuenta = gameObject.GetComponent<CuentaReg>();
        if (cuenta.empezoC == true)
        {
            freq = 4; 
            InvokeRepeating(nameof(DispararDeUnPuntoAlAzar), 0, freq); // ESTO DSP SE USA PARA HACER LO D AL LLEGAR A TAL PUNTAJE, AUMENTAR LA VELOCIDAD
            Debug.Log("freq = 3");
            cuenta.empezoC = false;
        }
        if (GameManager.Instance.puntos >= 1000 && listo == true)
        {
            freq = 2.5f;
            Debug.Log("freq = 1");
            InvokeRepeating(nameof(DispararDeUnPuntoAlAzar), 0, freq);
            listo = false;
        }
        if (GameManager.Instance.puntos >= 700 && listo == false && GameManager.Instance.puntos < 1000)
        {
            freq = 4f;
            Debug.Log("freq = 1");
            InvokeRepeating(nameof(DispararDeUnPuntoAlAzar), 0, freq);
            listo = true;
        }
        if (GameManager.Instance.puntos >= 250  && listo == true && GameManager.Instance.puntos < 700)
        {
            freq = 2f;
            Debug.Log("freq = 1");
            InvokeRepeating(nameof(DispararDeUnPuntoAlAzar), 0, freq);
            listo = false;
        }
        else if (GameManager.Instance.puntos >= 120 && GameManager.Instance.puntos < 250  && listo == false)
        {
            Debug.Log("hola");
            freq2 = 2.5f;
            InvokeRepeating(nameof(DispararDeUnPuntoAlAzar), 0, freq2);
            listo = true;
        }

        else if (GameManager.Instance.puntos >= 100 && GameManager.Instance.puntos < 120 && listo == true)
        {
            CancelInvoke(nameof(DispararDeUnPuntoAlAzar));
            freq = 2f;
            Debug.Log("freq = 1");
            InvokeRepeating(nameof(DispararDeUnPuntoAlAzar), 0, freq);
            listo = false;
        }

        else if (GameManager.Instance.puntos >= 20 && GameManager.Instance.puntos < 100 && listo == false)
        {
            CancelInvoke(nameof(DispararDeUnPuntoAlAzar));
            freq = 3f;
            Debug.Log("freq = 2");
            InvokeRepeating(nameof(DispararDeUnPuntoAlAzar), 0, freq);
            listo = true;
        }
   
    }

    void DispararDeUnPuntoAlAzar()
    {
        int nroAlAzar = Random.Range(0,puntosDisparo.Length);
        puntosDisparo[nroAlAzar].Disparar(GenerarRandom());
        SoundManager.Instance.PlaySound(SoundManager.Instance.nuevaComida);
        
    }

    GameObject GenerarRandom() //funcion para q aparezca un objeto random
    {
        int azar = Random.Range(0, comidas.Length);
        return comidaAzar = comidas[azar];

    }
}
