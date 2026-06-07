<div align="center">

<img src="https://download.alianblank.com/gameframex/gameframex_logo_320.png" alt="Game Frame X Logo" width="160" />

# Game Frame X FairyGUI Component

[![License](https://img.shields.io/github/license/GameFrameX/com.gameframex.unity.fairygui)](https://github.com/GameFrameX/com.gameframex.unity.fairygui/blob/main/LICENSE.md)
[![Version](https://img.shields.io/github/v/release/GameFrameX/com.gameframex.unity.fairygui)](https://github.com/GameFrameX/com.gameframex.unity.fairygui/releases)
[![Unity Version](https://img.shields.io/badge/Unity-2019.4-black?logo=unity)](https://unity.com/)
[![Documentation](https://img.shields.io/badge/Documentation-docs-blue)](https://gameframex.doc.alianblank.com)

All-in-One Solution for Indie Game Development · Empowering Indie Developers' Dreams

<br />

[Documentation](https://gameframex.doc.alianblank.com) · [Quick Start](#quick-start) · QQ Group: 467608841 / 233840761

<br />

**English** | [简体中文](README.zh-CN.md) | [繁體中文](README.zh-TW.md) | [日本語](README.ja.md) | [한국어](README.ko.md)

</div>

## Project Overview

The **FairyGUI Component** provides interfaces for integrating FairyGUI within the Game Frame X framework.

## Quick Start

### Installation

Choose one of the following methods:

1. Edit your Unity project's `Packages/manifest.json` and add the `scopedRegistries` section:
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

   `scopes` controls which packages are resolved through this registry. Only packages whose names start with `com.gameframex` will be fetched from it.

2. Add to `manifest.json` dependencies:
   ```json
   {
      "com.gameframex.unity.fairygui": "https://github.com/gameframex/com.gameframex.unity.fairygui.git"
   }
   ```
3. Use **Package Manager** in Unity with **Git URL**: `https://github.com/gameframex/com.gameframex.unity.fairygui.git`
4. Clone the repository into your Unity project's `Packages` directory. It will be loaded automatically.
## Documentation & Resources

- [Documentation](https://gameframex.doc.alianblank.com)

## Community & Support

- QQ Group: 467608841 / 233840761

## Changelog

See [Releases](https://github.com/gameframex/com.gameframex.unity.fairygui/releases) for changelog.


## Dependencies

| Package | Description |
|---------|-------------|
| (无) | - |

## License

See [LICENSE.md](LICENSE.md) for license information.
