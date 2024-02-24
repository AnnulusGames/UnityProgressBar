# Unity Progress Bar
 Simple and robust progress bar components for Unity uGUI.

<img src="https://github.com/AnnulusGames/UnityProgressBar/blob/main/docs/images/header.png" width="800">

[![license](https://img.shields.io/badge/LICENSE-MIT-green.svg)](LICENSE)
![unity-version](https://img.shields.io/badge/unity-2019.1+-000.svg)
[![releases](https://img.shields.io/github/release/AnnulusGames/UnityProgressBar.svg)](https://github.com/AnnulusGames/UnityProgressBar/releases)

[日本語版READMEはこちら](README_JA.md)

Unity Progress Bar is a library that adds a `ProgressBar` component to Unity UI (uGUI). It is designed to be simple and easy to use, avoiding unnecessary complexity, and allows for easy creation of custom progress bars by inheriting from `ProgressBarBase`.

## Setup

### Requirements

* Unity 2019.1 or later
* Unity UI 1.0.0 or later

### Installation

1. Open the Package Manager from Window > Package Manager.
2. Click the "+" button > Add package from git URL.
3. Enter the following URL:

```
https://github.com/AnnulusGames/UnityProgressBar.git?path=Assets/UnityProgressBar
```

Alternatively, open Packages/manifest.json and add the following to the dependencies block:

```json
{
    "dependencies": {
        "com.annulusgames.ugui-progress-bar": "https://github.com/AnnulusGames/UnityProgressBar.git?path=Assets/UnityProgressBar"
    }
}
```

## Usage

Once Unity Progress Bar is installed, you can create a Progress Bar from the Create menu.

<img src="https://github.com/AnnulusGames/UnityProgressBar/blob/main/docs/images/img-create.png" width="600">

## Properties

<img src="https://github.com/AnnulusGames/UnityProgressBar/blob/main/docs/images/img-inspector.png" width="600">

| Property | Description |
| - | - |
| Min Value | Minimum value of the progress bar |
| Max Value | Maximum value of the progress bar |
| Value | Current value of the progress bar |
| Fill Mode | Specifies how the fill is displayed |
| Fill Image | (Only for FillMode.FillAmount) Image used for the fill portion |
| Fill Rect | (Only for FillMode.Stretch) RectTransform used for the fill portion |
| Direction | (Only for FillMode.Stretch) Direction in which the fill is stretched |
| On Value Changed | Event executed when the value changes |

## License

[MIT License](LICENSE)
