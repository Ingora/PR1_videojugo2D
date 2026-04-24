using UnityEngine;
using UnityEngine.SceneManagement;

public class InicioScript : MonoBehaviour
{
    public GameObject panelInicio;
    public GameObject panelSettings;
    public AudioManager AudioManagerObj;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        panelSettings.SetActive(false);
    }

    // Update is called once per frame
    void Update() { }

    public void showSettings()
    {
        panelSettings.SetActive(true);
        panelInicio.SetActive(false);
        AudioManagerObj.GetComponent<AudioManager>().SonarBoton();
    }

    public void exitSettings()
    {
        panelSettings.SetActive(false);
        panelInicio.SetActive(true);
        AudioManagerObj.GetComponent<AudioManager>().SonarBoton();
    }

    public void Inicio()
    {
        SceneManager.LoadScene("juego");
        AudioManagerObj.GetComponent<AudioManager>().SonarBoton();
    }

    public void ExitGame()
    {
        Application.Quit();
        AudioManagerObj.GetComponent<AudioManager>().SonarBoton();
    }
}
