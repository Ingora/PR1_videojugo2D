using UnityEngine;

public class MovMaguita : MonoBehaviour
{

    int miNumero = 1;

    float miNumeroFlotante = 0.8f;

    string miCadenaDetexto = "Hola esto es una cadena de texto";

    bool esEstrella = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float sumaEntreDecenas = Sumar (10,20,3.8f);
        Debug.Log("inicio");
        Debug.Log (sumaEntreDecenas);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Hola");
    }

    float Sumar(int Num1, int Num2, float Num3)
    {
        float suma = Num1 + Num2 + Num3;
        return suma;
    }




}
