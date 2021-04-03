using System.Collections.Generic;


namespace Code
{
    internal sealed class Controllers : IRun, IFixedRun, ILateRun, IClean

    {
        private readonly List<IInitialization> _initializationsController;
        private readonly List<IRun> _runsController;
        private readonly List<IFixedRun> _fixedRunsController;
        private readonly List<ILateRun> _lateRunController;
            private readonly List<IClean> _cleansController;

        internal Controllers()
        {
            _initializationsController = new List<IInitialization>();
            _runsController = new List<IRun>();
            _fixedRunsController = new List<IFixedRun>();
            _lateRunController = new List<ILateRun>();
            _cleansController = new List<IClean>();
        }

        internal Controllers Add(IController controller)
        {
            if (controller is IInitialization initializationsController)
            {
                _initializationsController.Add(initializationsController);
            }

            if (controller is IRun runsController)
            {
                _runsController.Add(runsController);
            }

            if (controller is IFixedRun fixedRunsController)
            {
                _fixedRunsController.Add(fixedRunsController);
            }
            
            if (controller is ILateRun lateRunController)
            {
                _lateRunController.Add(lateRunController);
            }

            if (controller is IClean cleanController)
            {
                _cleansController.Add(cleanController);
            }

            return this;
        }

        public void Initialization()
        {
            for (var i = 0; i < _initializationsController.Count; i++)
            {
                _initializationsController[i].Initialization();
            }
        }

        public void Run(float deltaTime)
        {
            for (var i = 0; i < _runsController.Count; i++)
            {
                _runsController[i].Run(deltaTime);
            }
        }

        public void FixedRun(float deltaTime)
        {
            for (var i = 0; i < _fixedRunsController.Count; i++)
            {
                _fixedRunsController[i].FixedRun(deltaTime);
            }
        }
        
        public void LateRun(float deltaTime)
        {
            for (var i = 0; i < _lateRunController.Count; i++)
            {
                _lateRunController[i].LateRun(deltaTime);
            }
        }

        public void Clean()
        {
            for (int i = 0; i < _cleansController.Count; i++)
            {
                _cleansController[i].Clean();
            }
        }
    }
}