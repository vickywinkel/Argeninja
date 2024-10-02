using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CuentaReg : MonoBehaviour
{
    public TextMeshProUGUI txt_countdown;
    public bool empezoC = false; 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartCountDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator StartCountDown()
    {
        txt_countdown.enabled = true;

        for (int i = 3; i > 0; i--)
        {
            txt_countdown.text = i.ToString();
            yield return new WaitForSeconds(1); 
        }

        txt_countdown.text = "GO!";
        yield return new WaitForSeconds(1);
        txt_countdown.enabled = false;
        empezoC = true;
    }
}
