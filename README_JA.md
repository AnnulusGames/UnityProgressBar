# Unity Progress Bar
 Simple and robust progress bar components for Unity uGUI.

<img src="https://github.com/AnnulusGames/UnityProgressBar/blob/main/docs/images/header.png" width="800">

[![license](https://img.shields.io/badge/LICENSE-MIT-green.svg)](LICENSE)
![unity-version](https://img.shields.io/badge/unity-2019.1+-000.svg)
[![releases](https://img.shields.io/github/release/AnnulusGames/UnityProgressBar.svg)](https://github.com/AnnulusGames/UnityProgressBar/releases)

[English README is here.](README.md)

Unity Progress Barは`ProgressBar`コンポーネントをUntiy UI (uGUI)に追加するライブラリです。不必要な複雑さを避けシンプルで扱いやすい構成となっているほか、`ProgressBarBase`を継承することで独自のプログレスバーを簡単に作成することも可能になります。

## セットアップ

### 要件

* Unity 2019.1 以上
* Unity UI 1.0.0 以上

### インストール

1. Window > Package ManagerからPackage Managerを開く
2. 「+」ボタン > Add package from git URL
3. 以下のURLを入力する

```
https://github.com/AnnulusGames/UnityProgressBar.git?path=Assets/UnityProgressBar
```

またはPackages/manifest.jsonを開き、dependenciesブロックに以下を追記

```json
{
    "dependencies": {
        "com.annulusgames.ugui-progress-bar": "https://github.com/AnnulusGames/UnityProgressBar.git?path=Assets/UnityProgressBar"
    }
}
```

## 使い方

Unity Progress Barを導入すると、CreateメニューからProgress Barが作成可能になります。

<img src="https://github.com/AnnulusGames/UnityProgressBar/blob/main/docs/images/img-create.png" width="600">

## プロパティ

<img src="https://github.com/AnnulusGames/UnityProgressBar/blob/main/docs/images/img-inspector.png" width="600">

| プロパティ | 説明 |
| - | - |
| Min Value | プログレスバーの最小値 |
| Max Value | プログレスバーの最大値 |
| Value | プログレスバーの現在値 |
| Fill Mode | Fillの表示方法を指定 |
| Fill Image | (FillMode.FillAmountのみ) Fill部分に使用されるImage |
| Fill Rect | (FillMode.Stretchのみ) Fill部分に使用されるRectTransform |
| Direction | (FillMode.Stretchのみ) Fillを引き伸ばす方向 |
| On Value Changed | 値が変更された際に実行されるイベント |

## ライセンス

[MIT License](LICENSE)