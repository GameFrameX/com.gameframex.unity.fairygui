using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using FairyGUI;
using GameFrameX.Asset.Runtime;
using GameFrameX.Runtime;
using UnityEngine;

namespace GameFrameX.FairyGUI.Runtime
{
    /// <summary>
    /// 管理所有UI 包
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("Game Framework/FairyGUIPackage")]
    public sealed class FairyGUIPackageComponent : GameFrameworkComponent
    {
        private readonly Dictionary<string, UIPackage> _uiPackages = new Dictionary<string, UIPackage>(32);

        /// <summary>
        /// 异步添加UI 包
        /// </summary>
        /// <param name="descFilePath">UI包路径</param>
        /// <param name="isLoadAsset">是否在加载描述文件之后, 加载资源</param>
        /// <returns></returns>
        public UniTask<UIPackage> AddPackageAsync(string descFilePath, bool isLoadAsset = true)
        {
            if (!_uiPackages.TryGetValue(descFilePath, out var package))
            {
                var tcs = new UniTaskCompletionSource<UIPackage>();
                UIPackage.AddPackageAsync(descFilePath, (uiPackage) =>
                {
                    package = uiPackage;
                    if (isLoadAsset)
                    {
                        package.LoadAllAssets();
                    }

                    _uiPackages.Add(descFilePath, package);
                    tcs.TrySetResult(package);
                });
                return tcs.Task;
            }

            return UniTask.FromResult(package);
        }

        /// <summary>
        /// 同步添加UI 包
        /// </summary>
        /// <param name="descFilePath">包路径</param>
        /// <param name="complete">加载完成回调</param>
        /// <param name="isLoadAsset">是否在加载描述文件之后, 加载资源</param>
        public void AddPackageSync(string descFilePath, Action<UIPackage> complete, bool isLoadAsset = true)
        {
            if (!_uiPackages.TryGetValue(descFilePath, out var package))
            {
                UIPackage.AddPackageAsync(descFilePath, (uiPackage) =>
                {
                    package = uiPackage;
                    if (isLoadAsset)
                    {
                        package.LoadAllAssets();
                    }

                    _uiPackages.Add(descFilePath, package);
                    complete?.Invoke(package);
                });
            }
        }

        /// <summary>
        /// 移除UI 包
        /// </summary>
        /// <param name="descFilePath">UI包路径</param>
        public void RemovePackage(string descFilePath)
        {
            if (_uiPackages.TryGetValue(descFilePath, out var package))
            {
                UIPackage.RemovePackage(descFilePath);
                _uiPackages.Remove(descFilePath);
            }
        }

        /// <summary>
        /// 移除所有UI 包
        /// </summary>
        public void RemoveAllPackages()
        {
            UIPackage.RemoveAllPackages();
            _uiPackages.Clear();
        }


        /// <summary>
        /// 是否包含UI 包
        /// </summary>
        /// <param name="uiPackageName">UI包名称</param>
        /// <returns></returns>
        public bool Has(string uiPackageName)
        {
            return Get(uiPackageName) != null;
        }

        /// <summary>
        /// 获取UI 包
        /// </summary>
        /// <param name="uiPackageName">UI包名称</param>
        /// <returns></returns>
        public UIPackage Get(string uiPackageName)
        {
            if (_uiPackages.TryGetValue(uiPackageName, out var package))
            {
                return package;
            }

            return null;
        }

        protected override void Awake()
        {
            IsAutoRegister = false;
            base.Awake();
            UIPackage.SetAsyncLoadResource(new FairyGUILoadAsyncResourceHelper());
        }
    }
}