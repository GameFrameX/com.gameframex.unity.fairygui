using UnityEngine;
using UnityEngine.Scripting;

namespace GameFrameX.FairyGUI.Runtime
{
    [Preserve]
    public class GameFrameXFairyGUICroppingHelper : MonoBehaviour
    {
        private System.Type[] _types;
        [Preserve]
        private void Start()
        {
            _types = new[]
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