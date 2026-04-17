using UnityEngine;
using UnityEngine.InputSystem;

public class Bala : MonoBehaviour
{

GameObject Maguita;

bool direccionMaguita;
public float velocidadBala = 0.5f;
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

        bool direccionMaguita = Maguita.GetComponent<MovMaguita>().direccionBalaDerecha;
        
        if(direccionMaguita)
        {
            disparo.transform.Translate(velocidadBala,0,0);
            transform.Rotate(0,0,0.5f);
        }

        else
        {
            disparo.transform.Translate(velocidadBala*-1,0,0);
            transform.Rotate(0,0,-0.5f);
        }
       
    }
}
