using UnityEngine;
using Random = System.Random;

namespace Assets._SCRIPTS
{
    public class EnemyPatrol : MonoBehaviour {

        public float MoveSpeed;
        public bool MoveRight;

        public Transform WallCheck;
        public float WallCheckRadius;
        public LayerMask WhatIsWall;
        private bool _hittingWall;
        public int Seed = 1;
        private bool _atEdge;
        public Transform EdgeCheck;

        Random _rand;

        // Use this for initialization
        void Start () {
            _rand = new Random(Seed);
        }
	
        // Update is called once per frame
        void Update () {
            _hittingWall = Physics2D.OverlapCircle(WallCheck.position, WallCheckRadius, WhatIsWall);
            _atEdge = Physics2D.OverlapCircle(EdgeCheck.position, WallCheckRadius, WhatIsWall);

            if (_hittingWall || !_atEdge || _rand.Next(1000) < 5)
            { 
                if(_rand.Next(100) < 5)
                    MoveRight =! MoveRight;
            }
            if (MoveRight)
            {
                transform.localScale = new Vector3(-5f, 5f, 5f);
                GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                transform.localScale = new Vector3(5f, 5f, 5f);
                GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);

            }

            if(transform.position.y < 0)
            {
                Destroy(gameObject);
            }

        }
    }
}
