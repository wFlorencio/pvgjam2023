using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PassThroughPlatform : MonoBehaviour
{
    private bool _playerOnPlatform;
    private Player player;

    private void Start()
    {

    }

    private void SetPlayerOnPlatform(Collision2D other, bool value)
    {
        player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            _playerOnPlatform = value;
        }
    }

    private void Update()
    {
        if (_playerOnPlatform && Input.GetAxisRaw("Vertical") < 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.GetComponent<CapsuleCollider2D>().enabled = false;

                StartCoroutine(EnableCollider());
            }
        }
    }

    private IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(0.35f);
        player.GetComponent<CapsuleCollider2D>().enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        SetPlayerOnPlatform(other, true);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        SetPlayerOnPlatform(other, false);
    }

}
