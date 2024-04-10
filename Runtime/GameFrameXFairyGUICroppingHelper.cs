using UnityEngine;
using UnityEngine.Scripting;

namespace GameFrameX.FairyGUI.Runtime
{
    [Preserve]
    public class GameFrameXFairyGUICroppingHelper : MonoBehaviour
    {
        [Preserve]
        private void Start()
        {
            _ = typeof(CloseUIFormCompleteEventArgs);
            _ = typeof(IUIForm);
            _ = typeof(IUIFormHelper);
            _ = typeof(IUIGroup);
            _ = typeof(IUIGroupHelper);
            _ = typeof(IUIManager);
            _ = typeof(OpenUIFormDependencyAssetEventArgs);
            _ = typeof(OpenUIFormFailureEventArgs);
            _ = typeof(OpenUIFormSuccessEventArgs);
            _ = typeof(OpenUIFormUpdateEventArgs);
            _ = typeof(UIManager);
            _ = typeof(UILayer);
            _ = typeof(GObjectHelper);
            _ = typeof(FUI);
            _ = typeof(FairyGUIComponent);
            _ = typeof(FairyGUILoadAsyncResourceHelper);
            _ = typeof(FairyGUIPackageComponent);
            _ = typeof(FairyGUIPathFinderHelper);
        }
    }
}