using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.yaToqueBoton == false)
        {
            if (gameObject.tag == "creditos")
            {
                //SceneManager.LoadScene("creditos");
                GameManager.Instance.ChangeScene("creditos");
                Debug.Log("colison");
            }
            if (gameObject.tag == "volvermenu")
            {
                //SceneManager.LoadScene("creditos");
                GameManager.Instance.ChangeScene("menu");
                Debug.Log("colison");
            }
            if (gameObject.tag != "ExitHitBox")
            {
                GameManager.Instance.yaToqueBoton = true;
            }
        }
        if (gameObject.tag == "jugar")
        {
            Debug.Log("colison");
            GameManager.Instance.ChangeScene("juego");
            // SceneManager.LoadScene("juego");
            GameManager.Instance.puntos = 0;
            GameManager.Instance.vidas = 3;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (gameObject.tag == "ExitHitBox")
        {
            GameManager.Instance.yaToqueBoton = false;
        }
    }
}
