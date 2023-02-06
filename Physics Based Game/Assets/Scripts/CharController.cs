using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CharController : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;
    AudioSource audioSource;

    public float speed = 5f;
    public float rotationSpeed = 720f;
    private Vector3 velocity;

    public bool grounded;
    public float groundDistance;
    public LayerMask groundMask;
    [SerializeField]
    public float gravityVal = -9.81f;

    [SerializeField]
    public float jumpHeight = 1f;

    public float force = 10;
    
    public AudioClip meow;
    public float vol = 0.7f;
    public int wait = 5;
    bool soundPlaying = true;

    

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {   
        //check if character is on the ground
        grounded = Physics.CheckSphere(transform.position, groundDistance, groundMask);
        if (grounded && velocity.y < 0)
        {
            //velocity.y = 0f;
            velocity.y = -2f;
        }

        //Set input directions
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal , 0, vertical).normalized;

        //Movement logic

            if (direction != Vector3.zero) //moving
            {
                Walk();
                //turning character to face forward direction
                Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
                //transform.forward = direction.normalized;
            }
            else if( direction == Vector3.zero) //not moving
            {
                Idle();
            }
            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                Jump();
            }

        controller.Move(direction * speed * Time.deltaTime);

        velocity.y += gravityVal * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void Idle(){
        animator.SetFloat("moveState", 0, 0.1f, Time.deltaTime);
    }

    private void Walk(){
        animator.SetFloat("moveState", 1, 0.1f, Time.deltaTime);
    }

    private void Jump()
    {
        //animator.SetFloat("moveState", 1);
        animator.SetTrigger("Jump");
        velocity.y += Mathf.Sqrt(jumpHeight * -2 * gravityVal);
        //grounded = false; 
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody rb = hit.collider.attachedRigidbody;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            force += 5;
            animator.SetTrigger("Attack");
            StartCoroutine(SoundOut());
            
        }
        force = 10;
        if (rb == null || rb.isKinematic) return;
        rb.AddForceAtPosition(force * controller.velocity.normalized, hit.point);
    }

    IEnumerator SoundOut()
    {
        while (soundPlaying)
        {
            audioSource.PlayOneShot(meow, vol);
            Debug.Log("Meow");
            soundPlaying = false;
            yield return new WaitForSeconds(wait);
            soundPlaying = true;
        }
    }
    }
