using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer2D.Character;

[RequireComponent(typeof(CharacterMovement2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    CharacterMovement2D playerMovement;
    SpriteRenderer spriteRenderer;
    PlayerInput playerInput;


    public Sprite crouchSprite;
    public Sprite idleSprite;
    void Start()
    {
        playerMovement = GetComponent<CharacterMovement2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerInput = GetComponent<PlayerInput>();
        
        
    }

    void Update()
    {
       Vector2 movementInput = playerInput.GetMovementInput();

        playerMovement.ProcessMovementInput(movementInput);
        


        if(movementInput.x > 0){
            spriteRenderer.flipX = false;
        }else if(movementInput.x < 0){
            spriteRenderer.flipX = true;
        }else{

        }


        if(playerInput.IsJumpButtonDown()){
            playerMovement.Jump();
        }

        if(playerInput.IsJumpButtonHeld() == false){
            //playerMovement.UpdateAbortJump();
        }

        // Agachar

        if(playerInput.IsCrouchButtonDown()){
            playerMovement.Crouch();
            spriteRenderer.sprite = crouchSprite;
        }else if(playerInput.IsCrouchButtonUp()){
            playerMovement.UnCrouch();
            spriteRenderer.sprite = idleSprite;
        }





        
    }
}
