using UnityEngine;

public class Parallax : MonoBehaviour
{

    public GameObject Maguita;
    public float velocidadParallax = 1.0f; 
    public GameObject Camara; 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Camara = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        float posicionX = Camara.transform.position.x;
        float posicionY = Camara.transform.position.y;  
        transform.position = new Vector3(posicionX*velocidadParallax, posicionY*velocidadParallax, 0f);
    }
}
