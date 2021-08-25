using System.Collections.Generic;
using Code.Interfaces;

namespace Code.Controller
{
    public sealed class Controllers : IInitialization, IExecute, ILateExecute, ICleanup    
    {
        
        //TrulyThieved
        private readonly List<IInitialization> _initializeControllers;
        private readonly List<IExecute> _executeControllers;
        private readonly List<ILateExecute> _lateControllers;
        private readonly List<ICleanup> _cleanupControllers;

        internal Controllers()
        {
            _initializeControllers = new List<IInitialization>(8);
            _executeControllers = new List<IExecute>(8);
            _lateControllers = new List<ILateExecute>(8);
            _cleanupControllers = new List<ICleanup>(8);
        }

        internal Controllers Add(IController controller)
        {
            if (controller is IInitialization initializeController)
            {
                _initializeControllers.Add(initializeController);
            }

            if (controller is IExecute executeController)
            {
                _executeControllers.Add(executeController);
            }

            if (controller is ILateExecute lateExecuteController)
            {
                _lateControllers.Add(lateExecuteController);
            }
            
            if (controller is ICleanup cleanupController)
            {
                _cleanupControllers.Add(cleanupController);
            }

            return this;
        }
        internal Controllers Delete(IController controller)
        {
            if (controller is IInitialization initializeController)
            {
                _initializeControllers.Remove(initializeController);
            }

            if (controller is IExecute executeController)
            {
                _executeControllers.Remove(executeController);
            }

            if (controller is ILateExecute lateExecuteController)
            {
                _lateControllers.Remove(lateExecuteController);
            }
            
            if (controller is ICleanup cleanupController)
            {
                _cleanupControllers.Remove(cleanupController);
            }

            return this;
        }
        public void Initialization()
        {
            for (var index = 0; index < _initializeControllers.Count; ++index)
            {
                _initializeControllers[index].Initialization();
            }
        }
        
        public void Execute(float deltaTime)
        {
            for (var index = 0; index < _executeControllers.Count; ++index)
            {
                _executeControllers[index].Execute(deltaTime);
            }
        }
        
        public void LateExecute(float deltaTime)
        {
            for (var index = 0; index < _lateControllers.Count; ++index)
            {
                _lateControllers[index].LateExecute(deltaTime);
            }
        }

        public void Cleanup()
        {
            for (var index = 0; index < _cleanupControllers.Count; ++index)
            {
                _cleanupControllers[index].Cleanup();
            }
        }
    }
}