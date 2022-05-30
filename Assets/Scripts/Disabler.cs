using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disabler : MonoBehaviour
{
	public Transform star1;
	public Transform star2;
	public Transform star3;
	public Transform starSlot1;
	public Transform starSlot2;
	public Transform starSlot3;
	public Transform stars;
	public Transform gameOverMenu;

	private bool verificar1;

	public void Start(){
		verificar1 = false;
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.CompareTag("Player") && !verificar1)
		{
			Destroy(collision.gameObject);
			Destroy(star1.gameObject);
			starSlot1.gameObject.SetActive(true);
			Direction.speed = 250f;
			verificar1= true;
		}
		
		if (collision.CompareTag("Player") && stars.childCount == 5)
		{
			Destroy(collision.gameObject);
			Destroy(star2.gameObject);
			starSlot2.gameObject.SetActive(true);
			Direction.speed = 250f;
		}
		
		if (collision.CompareTag("Player")&& stars.childCount == 4)
		{
			Destroy(collision.gameObject);
			Destroy(star3.gameObject);
			starSlot3.gameObject.SetActive(true);
			Time.timeScale = 0f;
			gameOverMenu.gameObject.SetActive(true);
			Direction.speed = 250f;
		}
		
	}
}
