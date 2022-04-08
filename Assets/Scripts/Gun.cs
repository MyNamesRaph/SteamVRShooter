using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform ShootyPart;
    private bool shooting;
    public GameObject BulletPrototype;
    public float FiringForce = 1.0F;
    private AudioSource sfx;

    private void Start()
    {
        sfx = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (shooting)
        {
            //Debug.Log("Shooting");
            GameObject bullet = Instantiate(BulletPrototype);
            bullet.transform.position = ShootyPart.position;
            bullet.GetComponent<Rigidbody>().AddForce(ShootyPart.transform.forward * FiringForce, ForceMode.Impulse);
            sfx.mute = false;
        }
        else
        {
            //Debug.Log("Not Shooting");
            sfx.mute = true;
        }
    }

    public void OnTriggerPressed()
    {
        shooting = true;
    }

    public void OnTriggerReleased()
    {
        shooting = false;
    }
}
