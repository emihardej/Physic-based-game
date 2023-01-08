using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharController : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField]
    private float speed = 5f;

    [SerializeField] 
    private float force = 10;

    private bool grounded;
    private Vector3 jumping;
    
    [SerializeField]
    private float jumpHeight = 1f;

    [SerializeField]
    private float gravityVal = -9.81f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = controller.isGrounded;
        if (grounded && jumping.y < 0)
        {
            jumping.y = 0f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal , 0, vertical).normalized;

        controller.Move(direction * speed * Time.deltaTime);

        // if (direction != Vector3.zero)
        // {
        //     controller.Move(direction.normalized * speed * Time.deltaTime);
        // }

        if (Input.GetKey(KeyCode.Space) && grounded){
            Debug.Log("Jump");
            jumping.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityVal);
            grounded = false; 
            
        
        }
        controller.Move(jumping * Time.deltaTime);
        jumping.y += gravityVal * Time.deltaTime;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;
        if (rb == null || rb.isKinematic) return;
        rb.AddForceAtPosition(force * controller.velocity.normalized, hit.point);
    }
    }
