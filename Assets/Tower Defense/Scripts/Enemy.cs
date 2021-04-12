using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
  public Path route;
  private Waypoint[] myPathThroughLife;
  public int coinWorth = 2;
  public float health = 40;
  public float speed = .25f;
  private int index = 0;
  private Vector3 nextWaypoint;
  private bool stop;
  public Purse coin;
  private float healthPerUnit;
  private PlayerScript homeBase;
  private ParticleSystem deathParticles;

  public Transform healthBar;
  public UnityEvent DeathEvent;

  void Awake()
  {
    deathParticles = GetComponent<ParticleSystem>();

  }

  private void Start()
  {
    homeBase = FindObjectOfType<PlayerScript>();
    coin = FindObjectOfType<Purse>();
    myPathThroughLife = FindObjectsOfType<Waypoint>();

    myPathThroughLife = route.path;
    transform.position = myPathThroughLife[index].transform.position;
    Recalculate();
    health = 40;
    healthPerUnit = 100f / health;
  }

  void Update()
  {
    if (!stop)
    {
      if ((transform.position - myPathThroughLife[index + 1].transform.position).magnitude < .1f)
      {
        index = index + 1;
        Recalculate();
      }


      Vector3 moveThisFrame = nextWaypoint * Time.deltaTime * speed;
      transform.Translate(moveThisFrame);
    }
    else
    {
      homeBase.damage(10 * Time.deltaTime);
    }
  }

  void Recalculate()
  {
    if (index < myPathThroughLife.Length - 1)
    {
      nextWaypoint = (myPathThroughLife[index + 1].transform.position - myPathThroughLife[index].transform.position)
        .normalized;

    }
    else
    {
      stop = true;
    }
  }

  public void Damage()
  {
    Damage(20);
  }


  public void Damage(float hitAmount)
  {
    health -= hitAmount;
    if (health <= 0)
    {
      deathParticles.Play();
      coin.addCoin(3);
      Debug.Log($"{transform.name} is Dead");
      DeathEvent.Invoke();
      DeathEvent.RemoveAllListeners();

      Destroy(gameObject, 0.8f);
    }

    float percentage = healthPerUnit * health;
    Vector3 newHealthAmount = new Vector3(percentage/100f , healthBar.localScale.y, healthBar.localScale.z);
    healthBar.localScale = newHealthAmount;
  }
}
