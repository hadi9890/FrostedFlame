
using System.Collections;
using UnityEngine;

namespace RenewedMovement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float playerSpeed;
        [SerializeField] private float walkSpeed = 4.0f;
        [SerializeField] private float sprintSpeed = 6.0f;
        [SerializeField] private float rotationSpeed = 10f;
        [SerializeField] private float jumpHeight = 1.5f;
        [SerializeField] private float gravity = -9.81f;

        [SerializeField] private Camera followCamera;
        [SerializeField] LayerMask lavaLayer;
        private bool onLava;
        private Vector3 velocity;
        private bool grounded;
        private CharacterController cr;
        private Animator anim;
        private AudioSource audioSource;
        private static readonly int IsFalling = Animator.StringToHash("isFalling");
        private static readonly int Speed = Animator.StringToHash("Speed");

        void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            cr = GetComponent<CharacterController>();
            anim = GetComponentInChildren<Animator>();
            audioSource = GetComponentInChildren<AudioSource>();
        }

        private void Update()
        {
            Movement();
        }

        void FixedUpdate() {
            onLava = Physics.CheckSphere(transform.position,0.2f,lavaLayer);
            
            if(onLava){
                StartCoroutine(lavaDamage());
                onLava = false;
            }
        }

        void Movement()
        {  
            grounded = cr.isGrounded;
            if (!grounded)
            {
                anim.SetBool(IsFalling, true);
            } else
            {
                anim.SetBool(IsFalling, false);
            }
            
            if (grounded && velocity.y < 0)
            {
                velocity.y = -2.0f;
            }

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Vector3 movementInput = Quaternion.Euler(0, followCamera.transform.eulerAngles.y, 0) * new Vector3(horizontalInput, 0, verticalInput);
            Vector3 movementDirection = movementInput.normalized;

            cr.Move(Time.deltaTime * playerSpeed * movementDirection);
            
            if (movementDirection != Vector3.zero)
            {
                Quaternion desiredRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);

                if (Input.GetKey(KeyCode.LeftShift))
                {
                    Run();
                }
                else
                {
                    Walk();
                }
            }
            else if (movementDirection == Vector3.zero)
            {
                Idle();
            }

            if (Input.GetKeyDown(KeyCode.Space) && grounded)
            {
                Jump();
            }

            velocity.y += gravity * Time.deltaTime;
            cr.Move(velocity * Time.deltaTime);
        }

        private void Idle()
        {
            audioSource.mute = true;
            anim.SetFloat(Speed, 0.0f, 0.2f, Time.deltaTime);
        }

        private void Walk()
        {
            audioSource.mute = false;
            playerSpeed = walkSpeed;
            anim.SetFloat(Speed, 0.5f, 0.2f, Time.deltaTime);
        }

        private void Run()
        {
            audioSource.mute = false;
            playerSpeed = sprintSpeed;
            anim.SetFloat(Speed, 1.0f, 0.2f, Time.deltaTime);
        }

        private void Jump()
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }

        IEnumerator lavaDamage(){
            while(onLava){
                //Debug.Log(Health.health);
                Health.Health.takeDamage(1);
                yield return new WaitForSeconds(10f);
            }
        
        }
    }
}
