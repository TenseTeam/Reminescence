using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionComponent : MonoBehaviour
{
    public void Interact(ItemBaseData item, int questIndex)
    {
        //start interaction events chain
        GameManager.instance.EventManager.TriggerEvent(Constants.EVENT_INTERACTION, item, questIndex);
    }
}
