using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(AudioSource))]
public class DoorController : MonoBehaviour
{
    [SerializeField] private int m_NextScene;
    [SerializeField] private Sprite m_PartUpOpenDoor;
    [SerializeField] private Sprite m_PartDownOpenDoor;

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
        GetComponent<BoxCollider2D>().gameObject.SetActive(false);
        GetComponent<AudioSource>().Play();
        transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = m_PartUpOpenDoor;
        transform.GetChild(1).GetComponent<SpriteRenderer>().sprite = m_PartDownOpenDoor;
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