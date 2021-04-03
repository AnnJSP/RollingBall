using UnityEngine;


namespace Code
{
    internal sealed class GameInitialization
    {
        public GameInitialization(Controllers controllers, Data _data, Transform transform)
        {
            var labyrinth = new LabyrinthGenerator(transform, _data);
            var pointController = new PointController();
            var player = new Player();
            var pointInitialization = new PointInitialization();
            var checkColliders = new CheckColliders();
            var inputInitialization = new InputInitialization();
            
            Camera camera = Camera.main;
            Camera miniMapCamera = new Camera();
            
            checkColliders.CheckLaberinthColliders(_data);
            player.Initialization();
            pointInitialization.Initialization();
            
            controllers.Add(labyrinth);
            controllers.Add(new Radar(player.GetPlayer(), miniMapCamera));
            controllers.Add(new MiniMap(player.GetPlayer(), miniMapCamera.transform));
            controllers.Add(new InputController(inputInitialization.GetInput()));
            controllers.Add(pointController);
            controllers.Add(new CameraController(player.GetPlayer(), camera.transform));
            controllers.Add(new PlayerController(player.GetPlayer(), inputInitialization.GetInput(), _data));
        }
    }
}