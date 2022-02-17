using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : Singleton<GameSceneManager>
{
    private Vector3 _spawnLocation;  // For now it will be set at runtime to the player's location
    public Rigidbody playerRb;

    // Start is called before the first frame update
    private void Start()
    {
        _spawnLocation = playerRb.gameObject.transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        CheckSpecialInput();
    }

    private void CheckSpecialInput() {
        // Respawn player at initial position.
        if (Input.GetKeyUp(KeyCode.BackQuote)) {  // I was never able to get tilde keycode to work, even in my other projects
            playerRb.transform.position = _spawnLocation;
        }
    }
}
