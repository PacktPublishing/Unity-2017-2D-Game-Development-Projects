/* Copyright (C) 2017 Francesco Sapio - All Rights Reserved
 * 
 * This code has been taken from the book "Getting Started with Unity 5.x 2D Game Development"
 * available at the following link: https://www.packtpub.com/game-development/getting-started-unity-5x-2d-game-development
 *
 */
using UnityEngine;

public class StateMachineBehaviour_DestroyOnExit : StateMachineBehaviour {

    override public void OnStateExit(Animator Animator, AnimatorStateInfo stateInfo, int layerIndex) {
        //Destroy the gameobject where the Animator is attached to
        Destroy(Animator.gameObject);
    }

}

