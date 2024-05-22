using System;
using FairyGUI;
using GameFrameX.Asset.Runtime;
using GameFrameX.Runtime;
using UnityEngine;

namespace GameFrameX.FairyGUI.Runtime
{
    internal class FairyGUILoadAsyncResourceHelper : IAsyncResource
    {
        public async void LoadResource(string assetName, string extension, Action<bool, string, object> action)
        {
            var assetComponent = GameEntry.GetComponent<AssetComponent>();
            switch (extension)
            {
                case Utility.Const.FileNameSuffix.Binary:
                {
                    var assetHandle = await assetComponent.LoadAssetAsync<TextAsset>(assetName);
                    action.Invoke(assetHandle != null && assetHandle.AssetObject != null, assetName, assetHandle?.GetAssetObject<TextAsset>());
                    break;
                }
                case Utility.Const.FileNameSuffix.PNG: //如果FGUI导出时没有选择分离通明通道，会因为加载不到!a结尾的Asset而报错，但是不影响运行
                {
                    if (assetName.IndexOf("!a", StringComparison.OrdinalIgnoreCase) > -1)
                    {
                        action.Invoke(false, assetName, null);
                        break;
                    }

                    var assetHandle = await assetComponent.LoadAssetAsync<Texture>(assetName);
                    action.Invoke(assetHandle != null && assetHandle.AssetObject != null, assetName, assetHandle?.GetAssetObject<Texture>());
                    break;
                }
                case Utility.Const.FileNameSuffix.Wav:
                case Utility.Const.FileNameSuffix.Mp3:
                {
                    var assetHandle = await assetComponent.LoadAssetAsync<AudioClip>(assetName);
                    action.Invoke(assetHandle != null && assetHandle.AssetObject != null, assetName, assetHandle?.GetAssetObject<AudioClip>());
                    break;
                }
                default:
                {
                    Log.Error("加载资源失败 Unknown file type: " + assetName + " extension: " + extension);
                    action.Invoke(false, assetName, null);
                    // assetComponent.LoadAssetAsync(assetName,)
                    // var req = _assetComponent.LoadAssetSync(uiNamePath, type);
                    // return req.AssetObject;
                    break;
                }
            }
        }

        public void ReleaseResource(object obj)
        {
        }
    }
}