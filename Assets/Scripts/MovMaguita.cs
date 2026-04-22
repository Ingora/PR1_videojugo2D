    using UnityEngine;
    using UnityEngine.InputSystem;

public class MovMaguita : MonoBehaviour


{
    public float velocidad = 0.01f;
    public float impulsoSalto = 1.0f;
    public GameObject Maguita;
    public GameObject senyal;
    Rigidbody2D rb;
    Animator controlAnimacion; 
    bool  puedoSaltar = false;
    GameObject respawn;
    public string direccionMaguita = "quito";
    public bool direccionBalaDerecha = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();  

        controlAnimacion = GetComponent<Animator>(); 

        senyal = GameObject.Find("barril");

        respawn = GameObject.Find("Respawn");
       
       transform.position = respawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("Vidas: " + GameManager.vidas);
        Debug.Log("Puntos: " + GameManager.puntos);

//MOVIMIENTO
        Vector2 moveInput = InputSystem.actions["Move"].ReadValue<Vector2>();

        this.transform.Translate(moveInput.x*velocidad,moveInput.y*velocidad,0);

        //moveInput.x = (-1:A) ==== ==== (1:D)
        if(moveInput.x < 0)
        {
            this.GetComponent<SpriteRenderer>().flipX = true;
            direccionBalaDerecha = false;
            direccionMaguita = "izq";
        }

         else if(moveInput.x > 0)
        {
            direccionBalaDerecha = true;
            this.GetComponent<SpriteRenderer>().flipX = false;
            direccionMaguita = "drcha";
        }

       //Animacion caminado

        bool estaMoviendo = moveInput.x != 0 || moveInput.y != 0;
        controlAnimacion.SetBool("isMoving", estaMoviendo);

       if(moveInput.x != 0)
       {
        controlAnimacion.SetBool("activaCamina",true);
       }
       else
       {
        controlAnimacion.SetBool("activaCamina",false);
       }


        //SALTO
        
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

        bool salto = InputSystem.actions["Jump"].WasPressedThisFrame();
        if(salto == true && puedoSaltar == true)
        {
        rb.AddForce(transform.up*impulsoSalto,ForceMode2D.Impulse);  
        }

        if(transform.position.y <= -10)
        {
            Muerte();
        }
    
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Trigger con" + col.gameObject.name);

//Dead
        if(col.gameObject.name == "dead")
        {
            Muerte();
         
        }

        //Checkpoint
        if(col.gameObject.name == "checkpoint")
        {
            respawn.transform.position = col.transform.position;
        }

    }

    public void Muerte()
    {
           GameManager.vidas -= 1;
            transform.position = respawn.transform.position;

    }

    }