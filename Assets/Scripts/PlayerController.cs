using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PlayerController : MonoBehaviour
{
    public SteamVR_Action_Vector2 input;
    public float speed = 1.0F;
    public Rigidbody player;
    public Vector2 axis;

    private void Start()
    {
        input.onChange += Input_onChange;
    }

    private void Input_onChange(SteamVR_Action_Vector2 fromAction, SteamVR_Input_Sources fromSource, Vector2 axis, Vector2 delta)
    {
        this.axis = axis;
        Transform leftHand = Player.instance.leftHand.gameObject.transform;
        Vector3 movement = leftHand.forward * axis.y + leftHand.right * axis.x;
        movement.y = 0;

        //player.AddForce(movement*speed,ForceMode.VelocityChange);
        transform.position += movement * speed;
    }

    private void Update()
    {
        //Debug.Log(axis.x.ToString() + ", " + axis.y.ToString());
    }
}
