using System;
using FairyGUI;
using GameFrameX.Asset.Runtime;
using GameFrameX.Runtime;
using UnityEngine;

namespace GameFrameX.FairyGUI.Runtime
{
    internal class FairyGUILoadAsyncResourceHelper : IAsyncResource
    {
        public async void LoadResource(string assetName, Action<bool, object> action)
        {
            var assetComponent = GameEntry.GetComponent<AssetComponent>();
            var textAsset = await assetComponent.LoadAssetAsync<TextAsset>(assetName);
            Log.Info(assetName);
            action.Invoke(textAsset != null && textAsset.AssetObject != null, textAsset?.GetAssetObject<TextAsset>());
        }

        public void ReleaseResource(object obj)
        {
        }
    }
}