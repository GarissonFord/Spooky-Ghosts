using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;

    public bool isGhost;

    public bool npcInRange;

    public float h, v, moveSpeed = 200.0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        isGhost = true;
    }

    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(h, 0.0f, v) * moveSpeed * Time.deltaTime;
        //rb.AddForce(movement);
        rb.velocity = movement;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            Debug.Log("Possessed");
            Possess(other.transform);
        }
    }

    void Possess(Transform npc)
    {
        transform.parent = npc;
        Transform child = npc.transform.GetChild(0);
        child.gameObject.AddComponent<PlayerController>();
        Destroy(gameObject.GetComponent<PlayerController>());
    }
}
