using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public Task<UIPackage> AddPackage(string descFilePath)
        {
            if (!_uiPackages.TryGetValue(descFilePath, out var package))
            {
                if (descFilePath.IndexOf(Utility.Asset.Path.BundlesDirectoryName, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    var tcs = new TaskCompletionSource<UIPackage>();
                    UIPackage.AddPackageAsync(descFilePath, (uiPackage) =>
                    {
                        package = uiPackage;
                        package.LoadAllAssets();
                        _uiPackages.Add(descFilePath, package);
                        tcs.SetResult(uiPackage);
                    });
                    return tcs.Task;
                }

                package = UIPackage.AddPackage(descFilePath);
                package.LoadAllAssets();
                _uiPackages.Add(descFilePath, package);
            }

            return Task.FromResult(package);
        }

        public void RemovePackage(string descFilePath)
        {
            if (_uiPackages.TryGetValue(descFilePath, out var package))
            {
                UIPackage.RemovePackage(descFilePath);
                _uiPackages.Remove(descFilePath);
            }
        }

        public void RemoveAllPackages()
        {
            UIPackage.RemoveAllPackages();
            _uiPackages.Clear();
        }


        public bool Has(string uiPackageName)
        {
            return Get(uiPackageName) != null;
        }

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

        private AssetComponent _assetComponent;

        private void Start()
        {
            _assetComponent = GameEntry.GetComponent<AssetComponent>();
            if (_assetComponent == null)
            {
                Log.Fatal("Asset component is invalid.");
                return;
            }
        }
    }
}