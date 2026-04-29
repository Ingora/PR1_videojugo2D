using UnityEngine;

public class Manzana : MonoBehaviour
{
    Animator controlAnimacion;
    public int vida = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controlAnimacion = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() { }

    void OnTriggerEnter2D(Collider2D col)
    {
        //manzana
        controlAnimacion.SetBool("obtenerManzana", true);

        if (col.gameObject.name == "Maguita")
        {
            GameManager.vidas += vida;
            gameObject.GetComponent<Animator>().SetBool("obtenerManzana", true);
            Destroy(this.gameObject, 1.0f);
        }
    }
}
