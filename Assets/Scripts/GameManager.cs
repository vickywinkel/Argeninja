using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int vidas = 3;
    public int puntos;
    public int mayorPuntaje;

   // public GameObject todasLasVidas;
    //public GameObject dosVidas;
    //public GameObject unavida;

    int contadorCor = 0;
    //public TextMeshProUGUI txt_puntos;
    //public TextMeshProUGUI txt_mayorpuntaje;
   
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else //si instance es nulo, vacio
        {
            Instance = this; //yo soy instance --> este script
        }

        DontDestroyOnLoad(this); //para q esto se manetenga en tds las escenas 
       
    }



    // Update is called once per frame
    void Update()
    {
        //mayor puntaje
        if (puntos > mayorPuntaje) 
        {
            mayorPuntaje = puntos;
        }
    }

    public void PerderVida()
    {
        vidas--; 
        Debug.Log("Vidas restantes: " + vidas);
        if (vidas == 0)
        {
            ChangeScene("Perdiste");
        }
    } 

    public void SumarPuntos(int puntosGanados)
    {
        puntos += puntosGanados;
        Debug.Log("Puntos: " + puntos);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
