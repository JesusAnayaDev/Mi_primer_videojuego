using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    public float speed = 2f;

    void Awake()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
	}

    public Vector2 direction;

    private void FixedUpdate()
	{
		//  Move object
		Vector2 movement = direction.normalized * speed;
		_rigidbody.velocity = movement;
	}
}
