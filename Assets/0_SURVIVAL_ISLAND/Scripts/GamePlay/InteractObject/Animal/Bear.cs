using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Bear : Animal
{

    [Header("Bear")]
    [SerializeField] private NavMeshAgent _agent;

    [SerializeField] private float rotationSpeed, moveSpeed, deltaCheckAttack;

    [SerializeField] private Vector3 originPos;

    
    [SerializeField] float moveRadius, moveInterval ; // Maximum distance from the origin position, // Time interval for random movement
      
    private Vector3 originPosition;
    private float timeSinceLastMove;

    [SerializeField]private StatControl hp;

    private void Start()
    {
        m_animator.Play("RunForward");
        originPosition = transform.position;
        timeSinceLastMove = moveInterval; // Initialize to trigger movement immediately
    }

    private void Update()
    {
        timeSinceLastMove += Time.deltaTime;

        if (timeSinceLastMove >= moveInterval)
        {
            // Check if the animal is too far from the origin position
            float distanceFromOrigin = Vector3.Distance(transform.position, originPosition);

            if (distanceFromOrigin > moveRadius)
            {
                // Return to the origin position
                _agent.SetDestination(originPosition);
            }
            else if (Vector3.Distance(transform.position, Player.instance.transform.position) < 8)
            {
                AttackPlayer();
            }
            else
            {
                // Generate a random direction
                Vector3 randomDirection = Random.insideUnitSphere * moveRadius;

                // Calculate the new destination
                Vector3 newDestination = originPosition + randomDirection;

                // Set the new destination for the NavMeshAgent
                _agent.SetDestination(newDestination);
            }

            // Reset the timer
            timeSinceLastMove = 0f;
        }

        
    }

    void AttackPlayer()
    {
        var player = Player.instance;
        // Rotate the Bear towards the Player
        Vector3 directionToPlayer = player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(directionToPlayer);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);

        // Move the Bear towards the Player
        if (_agent != null)
        {
            _agent.SetDestination(player.transform.position);
        }

        deltaCheckAttack -= Time.deltaTime;
        if (deltaCheckAttack <= 0)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < 3)
            {
                m_animator.Play("Attack1");
                PrefData.StatHealthPoint -= dameAtk ;
                hp.UpdateFill();
                deltaCheckAttack = 2;
            } 
        }
        
    }


    IEnumerator RandomNumber()
    {
        while (true)
        {
            randomNum = Random.Range(1, 5);
            if (randomNum == 1)
            {
                transform.DORotate(new Vector3(0, 0, 0), 1);
            }
            else if (randomNum == 2)
            {
                transform.DORotate(new Vector3(0, 90, 0), 1);
            }else if (randomNum == 3)
            {
                transform.DORotate(new Vector3(0, 180, 0), 1);
            }else if (randomNum == 4)
            {
                transform.DORotate(new Vector3(0, 270, 0), 1);
            }
            
            yield return new WaitForSeconds(10);
        }
    }
    
    private void OnEnable()
    {
        itemsGenerate = new List<Item>();
        Item item1 = new Item(typeItems[0], Random.Range(1, 3), icons[0]);
        Item item2 = new Item(typeItems[1], Random.Range(1, 3), icons[1]);
        // Item item3 = new Item(typeItems[2], Random.Range(1, 3), icons[2]);
        
        itemsGenerate.Add(item1);
        itemsGenerate.Add(item2);
        // itemsGenerate.Add(item3);
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("rayPlayer"))
        {
            var gController = GameController.instance;
            gController.attackObj = this;
            
            // change center color
            GamePlayUI.instance.centerImg.color = Color.red;
            
            gController.hpBarObj.DisplayBar(remainHp, maxHp);
            Debug.Log("targeted");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("rayPlayer"))
        {
            var gController = GameController.instance;
            gController.tarGetObj = null;
            gController.hpBarObj.HideBar();
            
            // change center color
            GamePlayUI.instance.centerImg.color = Color.white;
        }
    }

}
