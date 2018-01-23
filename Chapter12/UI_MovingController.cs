using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_MovingController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    [SerializeField]
    private MovementComponent movementComponent;

    [SerializeField]
    private float direction = +1;

    private bool isHolding;

    // Use this for initialization
    void Awake() {
        //Destroy this script in case we are not running on mobile
        #if !(UNITY_STANDALONE || UNITY_EDITOR)
        Destroy(this);
        #endif

        //Disable this script in case the Movement Component reference is not set, and leave an error message.
        if (movementComponent == null) {
            Debug.LogError("Missing reference on MovementComponent on " + gameObject.name + " to run the Controller. Please add the reference.");
            Destroy(this);
        }
    }

    private void LateUpdate() {
        if (isHolding) {
            movementComponent.MoveCharacter(direction);
        }
    }

    public void OnPointerDown(PointerEventData eventData) {
        isHolding = true;
    }

    public void OnPointerUp(PointerEventData eventData) {
        isHolding = false;
    }
}
