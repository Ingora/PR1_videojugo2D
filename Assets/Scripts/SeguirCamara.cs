using UnityEngine;

public class SeguirCamara : MonoBehaviour
{

    public GameObject Maguita;
    Vector3 dondeMaguita;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dondeMaguita = Maguita.transform.position;
        transform.position = new Vector3(dondeMaguita.x,dondeMaguita.y,-10.0f);
    }
}
