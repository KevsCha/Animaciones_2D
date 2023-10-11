using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_2d : MonoBehaviour
{
	[SerializeField] float moveSpeed = 10f;
	[SerializeField] float jumpForce = 15f;
	[SerializeField] bool isGrow = true;
	public Vector3 inicio;
	public Controller script_control;
	//--------------------------------------------//
	Animator anim;
	//public GameObject[] enemy;

	float moveInput;
	Rigidbody2D rb2D;
	private void Awake()
	{

		script_control = GameObject.FindWithTag("GameController").GetComponent<Controller>();
		anim = this.gameObject.GetComponent<Animator>();
		rb2D = this.gameObject.GetComponent<Rigidbody2D>();
		inicio = new(-5f, 0, 0);
		//enemy = GameObject.FindGameObjectsWithTag("Enemy");
	}
	//TODO: crear un juego, un nivel de juego 2, meta, obstaculos, enemigos etc, algo cutre.
	void Update()
	{
			Move();
		/*
		if (script_control.inicio)
		{
		}*/

	}
	void Move() 
	{
		moveInput = Input.GetAxis("Horizontal");
		rb2D.velocity = new Vector3(moveInput * moveSpeed, rb2D.velocity.y, 0);
		/*TODO:
		 * hacer que mi personaje cambie de animacion segun requiera las caraceristicas, se mueve, corre salta, etc
		 * condicionales 
		 * buscar un metodo de como calcular la maxima altura posibel que le da el salto
		 * con la maxima altura pasar a la animacion para poder 
		 * ver como funcionaria las animaciones en un juego como actuan los personajes dependiendo a los personajes
		 * ver formas en como funcionaria los diferentes colliders, box_collider, edge_collider etc, y como funcionarian con el OncollisionEnter2D
		 */
		if (moveInput != 0)
			anim.SetBool("Caminando", true);
		if (moveInput < 0)
			this.gameObject.transform.localScale = new (-1, 1, 1);
		if (moveInput > 0)
			this.gameObject.transform.localScale = new (1, 1, 1);
		if (moveInput == 0)
			anim.SetBool("Caminando", false);
		//else if (moveInput < -0.1)

	}
	/*
	private void OnTriggerExit2D(Collider other)
	{
		if (Input.GetKeyDown(KeyCode.Space) && isGrow == true)
		{
			rb2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
			isGrow = false;
			//anim.setbool("Suelo", false)
			//anim.setTriger("Salto");
		}
	}
	*/
   
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("suelo"))
		{
			//anim.SetBool("Suelo", true);
			//
			isGrow = true;
		}
		if (collision.gameObject.CompareTag("Moneda"))
			Save(collision.gameObject);
		if (collision.gameObject.CompareTag("Finish"))
			Winner();
	}
    private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("collisionando");
		if (collision.gameObject.CompareTag("Enemy"))
			Reinicio();
	}
	private void Save(GameObject x) 
	{
		x.SetActive(false);
		inicio = this.gameObject.transform.position;
	}
	private void Reinicio() 
	{
		this.gameObject.transform.position = inicio;
	}
	private void Winner() 
	{
		Debug.Log("Siguiente Level");
	}
}
