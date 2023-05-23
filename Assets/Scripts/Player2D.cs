using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player2D : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    private bool _jump;
    private bool _jumping;
    [SerializeField] private float _magnitudeJump = 15f;
    [SerializeField] private LayerMask _groundLayer;

    [SerializeField] private Animator _animator;
    [SerializeField] private UIController _uiController;
    [SerializeField] private AudioController _audioController;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _jumping = true;
        }
        else
        {
            _jumping = false;
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _jump = true;
        }
        
        _animator.SetBool("isGrounded", IsGrounded());
        _animator.SetFloat("YVelocity", _rigidbody2D.velocity.y);
    }

    private void FixedUpdate()
    {
        if (_jumping || _rigidbody2D.velocity.y < 0)
        {
            _rigidbody2D.drag = 0;
        }
        else
        {
            _rigidbody2D.drag = 5;
        }
        
        if (_jump)
        {
            _jump = false;
            _rigidbody2D.velocity = Vector2.zero;
            _rigidbody2D.AddForce(Vector2.up * _magnitudeJump, ForceMode2D.Impulse);
            _audioController.PlaySfx("JumpClip");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            _uiController.UpdateCoinsText(GameManager.Instance.CoinCounter++);
            _audioController.PlaySfx("CoinClip");
            Destroy(other.gameObject);
        }

        if (other.CompareTag("DeathBox"))
        {
            //die
            GameManager.Instance.GameOver = true;
            _audioController.PlaySfx("GameOverClip");
            Destroy(other.gameObject);
        }
    }

    private bool IsGrounded()
    {
        //RaycastHit2D hit = Physics2D.Raycast(_boxCollider2D.bounds.center, Vector2.down, 0.6f);
        // RaycastHit2D hit = Physics2D.Raycast(_boxCollider2D.bounds.center, Vector2.down, _boxCollider2D.bounds.extents.y + 0.1f,_groundLayer);
        RaycastHit2D hit = Physics2D.BoxCast(
            _boxCollider2D.bounds.center,
            _boxCollider2D.bounds.size, 
            0, 
            Vector2.down, 
            0.1f,
            _groundLayer);
        
        return hit.collider;
    }
}
