# SpritePositionAdjuster

[English version of this file](https://github.com/Kilimanjaro-a2/SpritePositionAdjuster/blob/master/README.md)

## 説明

このスクリプトは、スプライトの位置とスケールを保持して、

画面のアスペクト比や高さが変わっても同じ見た目を再現させることができます。

![AnimationGif](https://user-images.githubusercontent.com/30808673/69492978-6fdc4a00-0eec-11ea-8b11-7790c0f83c59.gif)

## デモ

WebGLでビルドされたデモです。

ブラウザのウィンドウの高さを変更することで、

普通のスプライトは位置や大きさが元のものから変わってしまいますが、

このスクリプトを適用したスプライト（Adjusted Sprite）は、位置が変わりません。

https://kilimanjaro-a2.github.io/SpritePositionAdjuster/


## Usage

### 初期設定

UnityEditor上で、任意のアスペクト比でスプライトをシーンに置き、位置やスケールを設定します。

その後、[SpritePositionAdjuster.cs](https://github.com/Kilimanjaro-a2/SpritePositionAdjuster/blob/master/Assets/Plugins/SpritePositionAdjuster/SpritePositionAdjuster.cs)をスプライトレンダラーを持つゲームオブジェクトに対しアタッチします。

そしてシーンをスタートすると、今のゲームビューの高さがコンソールに表示されます。

```
Current screen height is: 726. If you want to preserve current scale and position of this sprites, set originalHeight property 726 and restart the scene to check whether it works correctly.
```

![ScreenShot](https://user-images.githubusercontent.com/30808673/69491436-88426980-0ed8-11ea-8196-2ed46d034a6f.PNG)


コンソールに表示された高さの値を、インスペクタからSpritePositionAdjusterのOriginalScreenHeightに対して設定します（今回の場合は726）。

![ScreenShot](https://user-images.githubusercontent.com/30808673/69491512-a5c40300-0ed9-11ea-859c-d480e1e503e8.PNG)


以上で初期設定は終了です。

以降、ゲームビューのアスペクトや高さを変えても、

最初に設定したスプライトの位置やスケールが再現されます。

### KeepsPositionUpdated

KeepsPositionUpdateをtrueにした場合、Updateで常にスクリーンのサイズが変わっていないか監視し、

変わっていた場合、即座にスプライトの位置・スケールを調整します。

falseの場合、スクリーンサイズのチェックは最初にシーンが開始されたときのみになるため、

trueの場合に比べてパフォーマンスが改善します。

デフォルトの値はtrueになっています。