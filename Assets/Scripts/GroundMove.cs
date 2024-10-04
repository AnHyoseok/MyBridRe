using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBird
{

    public class GroundMove : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;



        private void Update()
        {
            MoveGround();
        }
        void MoveGround()
        {
            if (GameManager.IsDeath) return;
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed, Space.World);
            if (transform.localPosition.x <= -8.4f)
            {
                transform.localPosition = new Vector3(transform.localPosition.x + 8.4f, transform.localPosition.y, transform.localPosition.z);
            }
        }

    }
}