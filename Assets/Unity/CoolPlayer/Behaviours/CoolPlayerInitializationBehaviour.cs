using Lab.CoolPlayer.Core.Factory;
using Lab.CoolPlayer.Core.Domain;
using UnityEngine;

namespace Lab.CoolPlayer.Unity.Behaviours
{
    public class CoolPlayerInitializationBehaviour : MonoBehaviour
    {
        [SerializeField]
        private CoolPlayerBehaviour _coolPlayer;

        private CoolPlayerFactory factory = new();

        private void Awake()
        {
            Initialize();
        }

        //This can be called either from Awake if independent or from another orchestrator script
        public CoolPlayerDomain Initialize()
        {
            var domain = factory.Create(_coolPlayer);
            return domain;
        }

        public void OnDestroy()
        {
            factory.Clear();
        }
    }
}
