using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ServiceLocator.Utilities;
using ServiceLocator.Player;

public class GameService : GenericMonoSingleton<GameService>
{
    [SerializeField] public PlayerScriptableObject playerScriptableObject;

    public PlayerService playerService{get;private set;}

    private void Start()
    {
        playerService = new PlayerService(playerScriptableObject);
    }

    private void Update()
    {
        playerService.Update();
    }

}
