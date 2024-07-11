using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private Player player;

    public void HandlePlayerCrashed() {
        gameOverUI.SetActive(true);
        player.enabled = false;
    }
}
