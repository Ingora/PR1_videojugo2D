using UnityEngine;
using UnityEngine.InputSystem;

public class Bala : MonoBehaviour
{

public GameObject disparo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Maguita = GameObject.Find("Maguita");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,0.5f);

        bool direccionMaguita = MovMaguita.GetComponent<MovMaguita>().direccionBalaDerecha;
        
        if(direccionMaguita)
        {
            disparo.transform.Translate(0.01f,0,0);
        }

        else
        {
            disparo.transform.Translate(-0.01f,0,0);
        }
       
    }
}
