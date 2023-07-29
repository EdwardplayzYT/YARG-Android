using System;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using YARG.Core;
using YARG.Input.Serialization;

namespace YARG.Input
{
    public class GameModeBindings
    {
        public GameMode GameMode { get; }

        public event Action BindingsChanged
        {
            add
            {
                Menu.BindingsChanged += value;
                Gameplay.BindingsChanged += value;
            }
            remove
            {
                Menu.BindingsChanged -= value;
                Gameplay.BindingsChanged -= value;
            }
        }

        public BindingCollection Menu { get; }
        public BindingCollection Gameplay { get; }

        public GameModeBindings(GameMode mode)
        {
            Menu = BindingCollection.CreateMenuBindings();
            Gameplay = BindingCollection.CreateGameplayBindings(mode);
        }

        public SerializedGameModeBindings Serialize()
        {
            return new()
            {
                Menu = Menu.Serialize(),
                Gameplay = Gameplay.Serialize(),
            };
        }

        public void Deserialize(SerializedGameModeBindings serialized)
        {
            Menu.Deserialize(serialized.Menu);
            Gameplay.Deserialize(serialized.Gameplay);
        }

        public void EnableInputs()
        {
            Menu.EnableInputs();
            Gameplay.EnableInputs();
        }

        public void DisableInputs()
        {
            Menu.DisableInputs();
            Gameplay.DisableInputs();
        }

        public void OnDeviceAdded(InputDevice device)
        {
            Menu.OnDeviceAdded(device);
            Gameplay.OnDeviceAdded(device);
        }

        public void OnDeviceRemoved(InputDevice device)
        {
            Menu.OnDeviceRemoved(device);
            Gameplay.OnDeviceRemoved(device);
        }

        public void ProcessInputEvent(InputEventPtr eventPtr)
        {
            Menu.ProcessInputEvent(eventPtr);
            Gameplay.ProcessInputEvent(eventPtr);
        }
    }
}