using UnityEngine;
using UnityEngine.InputSystem;

public class Bala : MonoBehaviour
{
    GameObject Maguita;

    bool direccionMaguita;
    public float velocidadBala = 0.5f;
    public GameObject disparo;

    float heNacido;
    public float tiempoHastaDestruccion = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Maguita = GameObject.Find("Maguita");
        direccionMaguita = Maguita.GetComponent<MovMaguita>().direccionBalaDerecha;
        heNacido = Time.time; //4.0 //10.0 //...
    }

    // Update is called once per frame
    void Update()
    {
        if (direccionMaguita)
        {
            disparo.transform.Translate(velocidadBala * Time.deltaTime, 0, 0);
            transform.Rotate(0, 0, 0.5f);
        }
        else
        {
            disparo.transform.Translate(velocidadBala * -1 * Time.deltaTime, 0, 0);
            transform.Rotate(0, 0, -0.5f);
        }

        //Destruccion por tiempo
        if (Time.time >= heNacido + tiempoHastaDestruccion)
        {
            Destroy(disparo);
        }
    }
}
