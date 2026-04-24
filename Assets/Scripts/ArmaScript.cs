using UnityEngine;
using UnityEngine.InputSystem;

public class ArmaScript : MonoBehaviour
{
    public GameObject Bala;

    void Start() { }

    // Update is called once per frame
    void Update()
    {
        //DISPARO
        bool disparo = InputSystem.actions["Attack"].WasPressedThisFrame();

        if (disparo)
        {
            Instantiate(Bala, transform.position, Quaternion.identity);
            AudioManager.Instance.SonarClipUnaVez(AudioManager.Instance.Disparo);
        }
    }
}
