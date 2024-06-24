using System;
using FairyGUI;
using GameFrameX.Asset.Runtime;
using GameFrameX.Runtime;
using UnityEngine;

namespace GameFrameX.FairyGUI.Runtime
{
    internal class FairyGUILoadAsyncResourceHelper : IAsyncResource
    {
        public async void LoadResource(string assetName, string extension, PackageItemType type, Action<bool, string, object> action)
        {
            var assetComponent = GameEntry.GetComponent<AssetComponent>();
            switch (type)
            {
                case PackageItemType.Spine:
                case PackageItemType.Misc:
                {
                    var assetHandle = await assetComponent.LoadAssetAsync<TextAsset>(assetName);
                    action.Invoke(assetHandle != null && assetHandle.AssetObject != null, assetName, assetHandle?.GetAssetObject<TextAsset>());
                    break;
                }
                case PackageItemType.Atlas:
                case PackageItemType.Image: //如果FGUI导出时没有选择分离通明通道，会因为加载不到!a结尾的Asset而报错，但是不影响运行
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
                case PackageItemType.Sound:
                {
                    var assetHandle = await assetComponent.LoadAssetAsync<AudioClip>(assetName);
                    action.Invoke(assetHandle != null && assetHandle.AssetObject != null, assetName, assetHandle?.GetAssetObject<AudioClip>());
                    break;
                }
                case PackageItemType.Font:
                {
                    var assetHandle = await assetComponent.LoadAssetAsync<Font>(assetName);
                    action.Invoke(assetHandle != null && assetHandle.AssetObject != null, assetName, assetHandle?.GetAssetObject<Font>());
                }
                    break;
//                 case PackageItemType.Spine:
//                 {
// #if FAIRYGUI_SPINE
//                     var assetHandle = await assetComponent.LoadAssetAsync<Spine.Unity.SkeletonDataAsset>(assetName);
//                     action.Invoke(assetHandle != null && assetHandle.AssetObject != null, assetName, assetHandle?.GetAssetObject<Spine.Unity.SkeletonDataAsset>());
// #else
//                             Log.Error("加载资源失败.暂未适配 Unknown file type: " + assetName + " extension: " + extension);
//                             action.Invoke(false, assetName, null);
// #endif
//                 }
                    // break;
                case PackageItemType.DragoneBones:
                {
#if FAIRYGUI_DRAGONBONES
                    var assetHandle = await assetComponent.LoadAssetAsync<DragonBones.DragonBonesData>(assetName);
                    action.Invoke(assetHandle != null && assetHandle.AssetObject != null, assetName, assetHandle?.GetAssetObject<DragonBones.DragonBonesData>());
#else
                    Log.Error("加载资源失败.暂未适配 Unknown file type: " + assetName + " extension: " + extension);
                    action.Invoke(false, assetName, null);
#endif
                }
                    break;
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