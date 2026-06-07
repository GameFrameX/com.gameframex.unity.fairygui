<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X FairyGUI 組件

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.fairygui)](https://github.com/GameFrameX/com.gameframex.unity.fairygui/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.fairygui)](https://github.com/GameFrameX/com.gameframex.unity.fairygui/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

獨立遊戲前後端一體化解決方案 · 獨立遊戲開發者的圓夢大使

<br />

[文檔](https://gameframex.doc.alianblank.com) · [快速開始](#快速開始) · QQ群: 467608841 / 233840761

<br />

[English](README.md) | [简体中文](README.zh-CN.md) | **繁體中文** | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## 項目簡介

**FairyGUI 組件 (FairyGUI Component)** - 提供FairyGUI組件相關的介面。

## 快速開始

### 安裝

選擇以下任一方式：

1. 編輯 Unity 專案的 `Packages/manifest.json`，添加 `scopedRegistries` 部分：
   ```json
   {
     "scopedRegistries": [
       {
         "name": "GameFrameX",
         "url": "https://gameframex.upm.alianblank.uk",
         "scopes": [
           "com.gameframex"
         ]
       }
     ],
     "dependencies": {
       "com.gameframex.unity.fairygui": "1.1.0"
     }
   }
   ```

   `scopes` 控制哪些套件透過此註冊表解析。只有以 `com.gameframex` 開頭的套件才會從這個註冊表取得。

2. 直接在 `manifest.json` 的 `dependencies` 節點下添加以下內容：
   ```json
   {
      "com.gameframex.unity.fairygui": "https://github.com/gameframex/com.gameframex.unity.fairygui.git"
   }
   ```
3. 在 Unity 的 `Package Manager` 中使用 `Git URL` 的方式添加庫，地址為：`https://github.com/gameframex/com.gameframex.unity.fairygui.git`
4. 直接下載倉庫放置到 Unity 專案的 `Packages` 目錄下，會自動載入識別。
## 文檔與資源

- [文檔](https://gameframex.doc.alianblank.com)

## 社區與支援

- QQ群: 467608841 / 233840761

## 更新日誌

查看 [Releases](https://github.com/gameframex/com.gameframex.unity.fairygui/releases) 了解更新日誌。


## 依賴

| 套件 | 說明 |
|------|------|
| (无) | - |

## 開源協議

詳見 [LICENSE.md](LICENSE.md) 檔案。
