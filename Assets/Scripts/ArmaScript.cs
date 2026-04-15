using UnityEngine;

public class ArmaScript : MonoBehaviour
{
       void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         //DISPARO
        bool disparo = InputSystem.actions["Attack"].WasPressedThisFrame();

        if(disparo)
        {
            Instantiate(Bala, transform.position, Quaternion.identity);
        }
    }
}
