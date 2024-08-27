using System;
using UnityEngine;
using UnityEngine.Scripting;

namespace GameFrameX.FairyGUI.Runtime
{
    [Preserve]
    public class GameFrameXFairyGUICroppingHelper : MonoBehaviour
    {
        private Type[] m_Types;

        [Preserve]
        private void Start()
        {
            m_Types = new[]
            {
                typeof(CloseUIFormCompleteEventArgs),
                typeof(IUIForm),
                typeof(IUIFormHelper),
                typeof(IUIGroup),
                typeof(IUIGroupHelper),
                typeof(IUIManager),
                typeof(OpenUIFormDependencyAssetEventArgs),
                typeof(OpenUIFormFailureEventArgs),
                typeof(OpenUIFormSuccessEventArgs),
                typeof(OpenUIFormUpdateEventArgs),
                typeof(UIManager),
                typeof(UILayer),
                typeof(GObjectHelper),
                typeof(FUI),
                typeof(FairyGUIComponent),
                typeof(FairyGUILoadAsyncResourceHelper),
                typeof(FairyGUIPackageComponent),
                typeof(FairyGUIPathFinderHelper),
            };
        }
    }
}