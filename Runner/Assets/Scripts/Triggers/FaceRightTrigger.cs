using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceRightTrigger : Trigger
{
        private PlayerController playerController;

        private void Start()
        {
                playerController = player.GetComponent<PlayerController>();
        }
        protected override void Action(GameObject collided)
        {
                playerController.FaceRight();
        }
}
