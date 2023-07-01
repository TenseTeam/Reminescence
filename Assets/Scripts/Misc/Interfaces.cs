using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayer { }

public interface IInteractable
{
    public void Interact(InteractionComponent interaction);
}
