using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyBird
{

    public class CamerController : MonoBehaviour
    {
        //카메라이동

        public Transform player;
        [SerializeField] private float offset = 1.5f;

        void FollowPlayer()
        {
            transform.position = new Vector3(player.position.x+ offset, transform.position.y,transform.position.z);
        }

        private void LateUpdate()
        {
           FollowPlayer();
        }
    }

}