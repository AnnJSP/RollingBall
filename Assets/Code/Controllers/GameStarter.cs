using UnityEngine;
using UnityEngine.UI;


namespace Code
{
    public sealed class GameStarter : MonoBehaviour
    {
        private Controllers _controllers;
        private Transform _transform;
        private Data _data;

        private void Start()
        {
            _controllers = new Controllers();
            var gameInitialization = new GameInitialization(_controllers, _data, _transform);

            _controllers.Initialization();
        }

        private void Update()
        {
            var deltaTime = Time.deltaTime;
            _controllers.Run(deltaTime);
        }

        private void LateUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controllers.LateRun(deltaTime);
        }

        private void FixedUpdate()
        {
            var deltaTime = Time.deltaTime;
            _controllers.FixedRun(deltaTime);
        }

        private void OnDestroy()
        {
            _controllers.Clean();
        }
    }
}
