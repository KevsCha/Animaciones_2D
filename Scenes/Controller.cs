using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Controller : MonoBehaviour
{
	public TextMeshProUGUI txt_vida;
	public bool inicio = false;
	public GameObject btn;

	public void Btn_Start() 
	{
		Debug.Log("boton start");
		inicio = true;

	}
}
