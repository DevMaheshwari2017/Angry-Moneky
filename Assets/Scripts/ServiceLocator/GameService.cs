using UnityEngine;
using ServiceLocator.Utilities;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.Wave;
using ServiceLocator.UI;
using ServiceLocator.Map;
using ServiceLocator.Events;

public class GameService : GenericMonoSingleton<GameService>
{
    public PlayerService playerService { get; private set; }
    public EventService eventService { get; private set; }
    public SoundService soundService { get; private set; }
    public WaveService waveService { get; private set; }
    public MapService mapService { get; private set; }
    public UIService uIService => UIService;

    [SerializeField] private UIService UIService;

    [Header("Player Service ref")]
    [SerializeField] private PlayerScriptableObject playerScriptableObject;

    [Header("Sound Service refrences")]
    [SerializeField] private SoundScriptableObject soundScriptableObject;
    [SerializeField] private AudioSource audioEffects;
    [SerializeField] private AudioSource backgroundMusic;

    [Header("Wave Service refrences")]
    [SerializeField] private WaveScriptableObject waveScriptableObject;

    [Header("Map Service refrences")]
    [SerializeField] private MapScriptableObject mapScriptableObject;

    private void Start()
    {
        eventService = new EventService();
        UIService.SubscribeToEvents();
        playerService = new PlayerService(playerScriptableObject);
        soundService = new SoundService(soundScriptableObject, audioEffects, backgroundMusic);
        waveService = new WaveService(waveScriptableObject);
        mapService = new MapService(mapScriptableObject);
       
    }

    private void Update()
    {
        playerService.Update();
    }

}
