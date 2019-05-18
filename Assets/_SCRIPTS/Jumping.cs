using UnityEngine;

namespace Assets._SCRIPTS
{
    public class Jumping : MonoBehaviour
    {

        int _jump2 = 0;
        public Rigidbody2D Rb;
        public Transform GroundCheck;
        public float GroundCheckRadius;
        public LayerMask WhatIsGround;
        private bool _grounded;
        private Animator _anim;
        public float JumpForce;

        void Start()
        {
            Rb = GetComponent<Rigidbody2D>();
            _anim = GetComponent<Animator>();

        }

        private bool _isGrounded = false;


        void FixedUpdate()
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.down * 0.05f, Vector2.down, .01f);
            _isGrounded = (hit.collider != null && hit.collider.gameObject.layer == 8);
            if (_isGrounded)
            {
                _jump2 = 0;
            }
        }


        void Update()
        {

            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0)) && (( _isGrounded || _jump2 < 1 )))
            {
                _anim.SetBool("jump",true);
        
                Rb.AddForce(new Vector2(0, JumpForce));
                _jump2++;
            }
        }

        void OnCollisionEnter2D(Collision2D col)
        {
            _anim.SetBool("jump", false);

        }
    }
}
