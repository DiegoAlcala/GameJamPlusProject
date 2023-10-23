using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Mele : Enemy_D
{
    GameObject power;


    // Sounds
    //public AudioManager audioManager;
    public AudioSource audioSourceAttacks;
    public AudioClip[] attackBossSounds;


    protected override void AttackEnemy()
    {
        if (timePassed >= attackTime)
        {
            // Si la sitancia entre el enemigo y el player es menor al rango de ataque entonces que ataque
            if (Vector3.Distance(player.transform.position, transform.position) <= attackRange)
            {
                animator.SetTrigger("attack");
                timePassed = 0;
                Invoke("CreatePower", .8f);
                //audioManager.PlayAudioClip(audioManager.RandomiseSounds(attackBossSounds), audioSourceAttacks);
            }
        }
        timePassed += Time.deltaTime;
    }
}
