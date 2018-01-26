using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//all the pickup should have Collider as well as MeshRenderer
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(MeshRenderer))]

public class PickUp : MonoBehaviour {

    //[SerializeField] private float respawnTime;
    [SerializeField] private float cooldownTime = 5.0f;
    private Collider m_Collider;
    private MeshRenderer m_MRenderer;
    private bool isCooldown;
    private float cooldownCounter;

    enum pickUpType
    {
        weapon = 0,
        powerUp = 1
    }


	// Use this for initialization
	void Start () {
        //set all the pickup to be a trigger
        m_Collider = GetComponent<Collider>();
        m_Collider.isTrigger = true;
        m_MRenderer = GetComponent<MeshRenderer>();
        m_MRenderer.enabled = true;
        //Remember to set all object to the state you want in the beginning
        isCooldown = false;
	}
	
	// Update is called once per frame
	void Update () {
        //if it is cooldonwing, reduce the cooldown time
        if (isCooldown)
        {
            cooldownCounter -= Time.deltaTime;
            if(cooldownCounter <= 0)
            {
                Respawn();
            }
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        //if it is not cooldowning, deal with its utility
        if (!isCooldown) {
            //it can only be interact with player
            if (other.CompareTag("Player")) 
            {
                BeTaken();
                //other.GetComponent<PlayerSatus>().updatePlayer()
            }
        }
    }

    public void Respawn()
    {
        isCooldown = false;
        m_MRenderer.enabled = true;
    }

    public void BeTaken()
    {
        m_MRenderer.enabled = false;
        isCooldown = true;
        cooldownCounter = cooldownTime;
        //PlayerUpdate(int power, string type,)
        //
    }
}
