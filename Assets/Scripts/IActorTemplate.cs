using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActorTemplate
{
    //An interface is simply all of actor must implement and comply to.
    int SendDamage();
    void TakeDamage(int incomingDamage);
    void Die();
    void ActorStats(SOActorModel actorModel);
}
