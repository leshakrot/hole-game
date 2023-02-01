using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleController : MonoBehaviour
{
	[SerializeField] private double viewAngle;
	private double xRangePerspective;

	[SerializeField] private float speed;
	[SerializeField] private float speedModifier;

	public float horizontalInput;
    public float verticalInput;


	[SerializeField] private float xRangeOrthogonal;
	[SerializeField] private float yUpperRange;
	[SerializeField] private float yLowerRange;

	public Touch touch;

	public static HoleController Instance;

    private void Awake()
    {
        if(Instance == null)
        {
			Instance = this;
        }
        else
        {
			Destroy(gameObject);
        }
		transform.parent = null;
    }

    private void Start()
    {
		Time.timeScale = 1f;
		viewAngle *= (Math.PI / 180); 
	}
	//Update is called once per frame
	private void Update()
	{
		xRangePerspective = xRangeOrthogonal + (transform.position.z * Math.Tan(viewAngle));

		horizontalInput = SimpleInput.GetAxis("Horizontal");
		transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
		verticalInput = SimpleInput.GetAxis("Vertical");
		transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);

		if (Input.touchCount > 0)
		{
			touch = Input.GetTouch(0);

			if (touch.phase == TouchPhase.Moved)
			{
				transform.position = new Vector3(
					transform.position.x - touch.deltaPosition.x * speedModifier,
					transform.position.y,
					transform.position.z - touch.deltaPosition.y * speedModifier);
			}
		}

		if (transform.position.x < (float)-xRangePerspective) transform.position = new Vector3((float)-xRangePerspective, transform.position.y, transform.position.z);
		if (transform.position.x > (float)xRangePerspective) transform.position = new Vector3((float)xRangePerspective, transform.position.y, transform.position.z);
		if (transform.position.z < yLowerRange) transform.position = new Vector3(transform.position.x, transform.position.y, yLowerRange);
		if (transform.position.z > yUpperRange) transform.position = new Vector3(transform.position.x, transform.position.y, yUpperRange);
	}

	public void PauseOn()
    {
		speedModifier = 0f;
    }

	public void PauseOff()
    {
		speedModifier = 0.0075f;
    }
}
