using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR;

public class Player : MonoBehaviour
{
    [SerializeField] private GameInput gameInput;
    [SerializeField] private GameObject[] botCars; // Array to hold bot-car references

    [SerializeField] private float moveSpeed = 5f;

    [SerializeField] private LayerMask carLayerMask;

    [SerializeField] private GameObject gameOverManager;
    private int score = 0;
    private HashSet<GameObject> passedBotCars = new HashSet<GameObject>();

    private void Update()
    {
        HandleMovement();
        PlayerScore();
    }

    private void PlayerScore() {
        foreach (var botCar in botCars) {
        // Check if this botCar has not been passed yet and player is ahead
        if (!passedBotCars.Contains(botCar) && transform.position.z > botCar.transform.position.z) {
            Debug.Log("Player Passed Bot Car" + botCar.name);
            score += 10; // Increase score
            Debug.Log("Player Scored. New Score: " + score);
            passedBotCars.Add(botCar); // Mark this botCar as passed
        }
    }
    }
    private void HandleMovement() {
        //Player movement
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);
        float carHeight = 1.5f;
        float carRadius = 0.5f;
        float moveDistance = moveSpeed * Time.deltaTime;

        if (Physics.CapsuleCast(transform.position, transform.position + Vector3.up * carHeight, carRadius, moveDir, moveDistance, carLayerMask)) {
            gameOverManager.GetComponent<GameOverManager>().HandlePlayerCrashed();
        }
        

        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * carHeight, carRadius, moveDir, moveDistance);
        if (!canMove) {
            Vector3 moveDirZ = new Vector3(moveDir.z, 0, 0).normalized;
            canMove = moveDir.z != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * carHeight, carRadius, moveDirZ, moveDistance);
            if (canMove) {
                moveDir = moveDirZ;
                Debug.Log("Can move on Z");
            } else {
                Vector3 moveDirX = new Vector3(0, 0, moveDir.x).normalized;
                canMove = moveDir.x != 0 && !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * carHeight, carRadius, moveDirX, moveDistance);
                if (canMove) {
                    moveDir = moveDirX;
                    Debug.Log("Can move on X");
                }
            }
        }

        if (canMove){
            transform.position += moveDir * moveSpeed * Time.deltaTime;
        }
    }
    
}
