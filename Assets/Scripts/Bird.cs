using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
	public Transform pivot;
	public float springRange;
	public float maxVel;

	Rigidbody2D rb;//
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();//Referencia a rigidBody
		rb.bodyType = RigidbodyType2D.Kinematic; //A física não afeta
	}

	bool canDrag = true;
	Vector3 dis;
	void OnMouseDrag()
	{
		if (!canDrag)
			return;

		var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);//ponto onde esta tocando o mouse
		dis = pos - pivot.position; //referencia
		dis.z = 0;
		if (dis.magnitude > springRange) //Se estiver longe do pivot executa o if
		{
			dis = dis.normalized * springRange;//1 multiplicado por range com velocidade
		}
		transform.position = dis + pivot.position;//
	}

	void OnMouseUp() //Executa uando deixa de dar clic
	{
		if (!canDrag)//Se não pode arrastar fica do jeito que está
			return;
		canDrag = false;

		rb.bodyType = RigidbodyType2D.Dynamic;
		rb.velocity = -dis.normalized * maxVel * dis.magnitude / springRange; //Altera a velocidade de acordo com o range
	}
}

