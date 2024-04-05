using System.Collections.Generic;
using UnityEngine;
using ServiceLocator.Utilities;
using ServiceLocator.Sound;
using ServiceLocator.Player;
using ServiceLocator.Wave;


/*  This script demonstrates the implementation of Object Pool design pattern.
 *  If you're interested in learning about Object Pooling, you can find
 *  a dedicated course on Outscal's website.
 *  Link: https://outscal.com/courses
 * */

namespace ServiceLocator.Wave.Bloon
{
    public class BloonPool : GenericObjectPool<BloonController>
    {
        private SoundService soundService;
        private PlayerService playerService;
        private WaveService waveService;

        private BloonView bloonPrefab;
        private List<BloonScriptableObject> bloonScriptableObjects;
        private Transform bloonContainer;

        public BloonPool(PlayerService playerService, WaveService waveService, SoundService soundService, WaveScriptableObject waveScriptableObject)
        {
            this.soundService = soundService;
            this.waveService = waveService;
            this.playerService = playerService;

            this.bloonPrefab = waveScriptableObject.BloonPrefab;
            this.bloonScriptableObjects = waveScriptableObject.BloonScriptableObjects;
            bloonContainer = new GameObject("Bloon Container").transform;
        }

        public BloonController GetBloon(BloonType bloonType)
        {
            BloonController bloon = GetItem();
            BloonScriptableObject scriptableObjectToUse = bloonScriptableObjects.Find(so => so.Type == bloonType);
            bloon.Init(scriptableObjectToUse);
            return bloon;
        }

        protected override BloonController CreateItem() => new BloonController(playerService, waveService,soundService, bloonPrefab, bloonContainer);
    }
}