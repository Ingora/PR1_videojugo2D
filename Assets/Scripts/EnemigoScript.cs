using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemigoScript : MonoBehaviour
{
    GameObject Maguita;

    //estado de enemigo: patrulla, detección, persecución, ataque
    string estado = "patrulla";

    //Patrulla

    Vector3 posicionInicial;
    Vector3 posicionlimitIzq,
        posicionlimitDcha;
    public float distanciaPatrulla = 2.0f;
    public float velocidadPatrulla = 1f;
    bool dirPatrullaDcha = true;

    //ATAQUE
    public float distanciaAtaque = 1.0f;
    public float velocidadAtaque = 1.0f;
    public float distanciaEvitar = 3.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Maguita = GameObject.FindWithTag("Player");
        posicionInicial = transform.position;
        posicionlimitIzq = new Vector3(
            posicionInicial.x - distanciaPatrulla,
            posicionInicial.y,
            posicionInicial.z
        );
        posicionlimitDcha = new Vector3(
            posicionInicial.x + distanciaPatrulla,
            posicionInicial.y,
            posicionInicial.z
        );
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(transform.position, Maguita.transform.position);
        Debug.DrawRay(transform.position, Maguita.transform.position);

        //Detección

        if (distancia <= distanciaAtaque)
        {
            estado = "ataque";
        }
        //Vuelve a patrullar (distancia entre enemigo y maguita es mayor)
        if (distancia >= distanciaEvitar)
        {
            estado = "patrulla";
        }

        if (estado == "patrulla")
        {
            //si limite derecha (x)
            if (transform.position.x >= posicionlimitDcha.x)
            {
                dirPatrullaDcha = false;
                this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
            //si limite izquierda (x) TENGO QUE IR A LA DERECHA
            if (transform.position.x <= posicionlimitIzq.x)
            {
                dirPatrullaDcha = true;
                this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }

            //si limite derecha
            if (dirPatrullaDcha == true)
            {
                transform.Translate(velocidadPatrulla, 0, 0);
            }
            else
            {
                transform.Translate(velocidadPatrulla * -1, 0, 0);
            }
        }
        //ATAQUE

        if (estado == "ataque")
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                Maguita.transform.position,
                velocidadAtaque
            );

            if (AudioManager.Instance._audioSource.isPlaying == false)
            {
                AudioManager.Instance.SonarClipUnaVez(AudioManager.Instance.fantasmas);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Trigger con" + col.gameObject.name);

        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Muerte");
            GameManager.vidas -= 1;
            Maguita.GetComponent<MovMaguita>().Muerte();
        }

        if (col.gameObject.name == "Bala")
        {
            Destroy(this.gameObject, 0.5f);
            Destroy(col.gameObject, 0.5f);
        }
    }
}
