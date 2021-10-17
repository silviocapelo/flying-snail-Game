using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructableObject : MonoBehaviour
{
	public float resistance;
	public GameObject explosionPrefab; //Represnta a explosão uando o objeto foi destruido

	void OnCollisionEnter2D(Collision2D col) //
	{
		if (col.relativeVelocity.magnitude > resistance) //Verifica se a velocidade é maior que a resistencia
		{

			if (explosionPrefab != null)
			{
				var go = Instantiate(explosionPrefab, //Se for destroi o objeto
					transform.position,
					Quaternion.identity);
				Destroy(go, 3);
			}

			Destroy(gameObject, 0.1f); //Não destruir instantaneamente

		}
		else
		{
			resistance -= col.relativeVelocity.magnitude;

		}

	}

}
