using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(AudioSource))]
public class DoorController : MonoBehaviour
{
    [SerializeField] private int m_NextScene;


    private void Start()
    {
        GameManager.instance.EventManager.Register(Constants.EVENT_UNLOCK_DOOR, ThroughDoor);
    }

    /// <summary>
    /// makes gameObject throughable
    /// </summary>
    /// <param name="parameters"></param>
    public void ThroughDoor(object[] parameters)
    {
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<AudioSource>().Play();
        transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
        transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
    }

    /// <summary>
    /// check if player is over the door, if it is start event of end of level
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.instance.EventManager.TriggerEvent(Constants.EVENT_END_LEVEL, m_NextScene);
    }
}