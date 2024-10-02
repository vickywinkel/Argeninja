using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class corazones : MonoBehaviour
{
    public GameObject todasLasVidas;
    public GameObject dosVidas;
    public GameObject unavida;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.vidas == 3)
        {
            todasLasVidas.SetActive(true);
            dosVidas.SetActive(false);
            unavida.SetActive(false);
        }
        if (GameManager.Instance.vidas == 2)
        {
            todasLasVidas.SetActive(false);
            dosVidas.SetActive(true);
            unavida.SetActive(false);
        }
        if (GameManager.Instance.vidas == 1)
        {
            todasLasVidas.SetActive(false);
            dosVidas.SetActive(false);
            unavida.SetActive(true);
        }
    }
}
