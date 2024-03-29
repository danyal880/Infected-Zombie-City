﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
namespace TPSShooter
{
  [RequireComponent(typeof(ZombieBehaviour))]
  public class ZombieHealthBar : MonoBehaviour
  {
    public Transform holder;
    public Image fillImage;

    private ZombieBehaviour zombie;
    private Transform player;

        public UnityEvent killDone;
        private void Start()
    {
      player = PlayerBehaviour.GetInstance().transform;
      zombie = GetComponent<ZombieBehaviour>();

      zombie.onHpChanged += OnHpChanged;
      zombie.onDied += OnDied;
      UpdateHP();
    }

    private void Update()
    {
      holder.LookAt(player);
      holder.AnulateRotationExceptY();
    }

    private void OnHpChanged()
    {
      UpdateHP();
    }

    private void OnDied()
    {
      holder.gameObject.SetActive(false);
            EnemyGenerator.instance.ZombieDie();
        }

    private void UpdateHP()
    {
      fillImage.fillAmount = zombie.GetHP() / 100;
    }
  }
}
