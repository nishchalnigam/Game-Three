using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Target : MonoBehaviour {
    public int health = 4;
    private Animator animator;
    public AudioSource pigDeath;
    public AudioSource pigShot;
    public static Target instance = null;

    public Transform[] targets;
    int targetIndex;
    NavMeshAgent ai;
    public GameObject nextPig;


    void Awake()
    {
        animator = GetComponent<Animator>();
        //Check if instance already exists
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }
    // Use this for initialization
    void Start()
    {
        //nextPig = GameObject.Find("Pigman2");
        ai = gameObject.GetComponent<NavMeshAgent>();
        targetIndex = 0;
        pigShot = GameObject.Find("PigShot").GetComponent<AudioSource>();
        pigDeath = GameObject.Find("PigDeath").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (health > 0)
        {
            ai.destination = targets[targetIndex].position;
            if (Vector3.Distance(transform.position, targets[targetIndex].position) < 1.5)
            {
                targetIndex = (targetIndex + 1) % targets.Length;
            }
        }
    }


    public int getHealth()
    {
        return health;
    }


    public void TakeDamage(int amount)
    {
        if (health > 0)
        {
            StartCoroutine(Hit());

        }
        health -= amount;

        if(health <= 0f)
        {
            Die();
            nextPig.SetActive(true);
        }
    }

    IEnumerator Hit()
    {
        pigShot.Play();
        animator.SetBool("Hit", true);
        //animator.SetBool("Walk", false);
        Debug.Log("Hit me");
        yield return new WaitForSeconds(0.28f);
        Debug.Log("5 seconds");
        animator.SetBool("Hit", false);
        //animator.SetBool("Walk", true);
    }

    void Die()
    {
        animator.SetBool("Die", true);
        pigDeath.Play();
        // Destroy(gameObject);
    }
}
