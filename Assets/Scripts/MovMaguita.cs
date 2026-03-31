    using UnityEngine;
    using UnityEngine.InputSystem;

public class MovMaguita : MonoBehaviour


{
    
    public float velocidad = 0.01f;
    public float impulsoSalto = 1.0f;

    public GameObject senyal;

    Vector3 inicioPersonaje = new Vector3(1,1,0);

    Rigidbody2D rb;
     
    bool  puedoSaltar = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        this.transform.position = inicioPersonaje;

        Debug.Log(this.transform.position);

        rb = GetComponent<Rigidbody2D>();   

        senyal = GameObject.Find("barril");
       
    }

    // Update is called once per frame
    void Update()
    {
         Vector2 moveInput = InputSystem.actions["Move"].ReadValue<Vector2>();

        this.transform.Translate(moveInput.x*velocidad,moveInput.y*velocidad,0);

        //moveInput.x = (-1:A) ==== ==== (1:D)
        if(moveInput.x < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }

         else if(moveInput.x > 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position,Vector2.down,0.5f);
        Debug.DrawRay(transform.position,Vector2.down*0.5f,Color.red);

        if(hit.collider == true)
        { 
            puedoSaltar = true; 
            this.GetComponent<SpriteRenderer>().color = Color.white;
        }
         else 
        { 
            puedoSaltar = false;
            this.GetComponent<SpriteRenderer>().color = Color.red;   
        }


        //SALTO

        bool salto = InputSystem.actions["Jump"].WasPressedThisFrame();
        if(salto == true && puedoSaltar == true)
        {
        rb.AddForce(transform.up*impulsoSalto,ForceMode2D.Impulse);  
        }
    


    //DISPARO
    bool disparo = InputSystem.actions["Attack"].WasPressedThisFrame();

    if (disparo)
{
Instantiate(senyal, new Vector3(0,0,0), Quaternion.identity);

}



    }

}