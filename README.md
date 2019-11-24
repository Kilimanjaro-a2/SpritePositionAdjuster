# SpritePositionAdjuster

[日本語版README](https://github.com/Kilimanjaro-a2/SpritePositionAdjuster/blob/master/README.ja.md)

## Description

This script preserves the sprite's position and scale and can reproduce the same look even if the aspect ratio or height of the screen changes.

![AnimationGif](https://user-images.githubusercontent.com/30808673/69492978-6fdc4a00-0eec-11ea-8b11-7790c0f83c59.gif)

## Demo

This is a demo built with WebGL.

By changing the browser window height,

sprites will change position and size from the original.

However, the sprite with this script applied (Adjusted Sprite) does not change position and scales.

https://kilimanjaro-a2.github.io/SpritePositionAdjuster/


## Usage

### Initial Setting

On the UnityEditor, place a sprite in the scene with an arbitrary aspect ratio, and set the position and scale.

Then attach [SpritePositionAdjuster.cs](https://github.com/Kilimanjaro-a2/SpritePositionAdjuster/blob/master/Assets/Plugins/SpritePositionAdjuster/SpritePositionAdjuster.cs) to the GameObject which has the SpriteRenderer component.

When you start the scene, the current GameView height is displayed on the console.

```
Current screen height is: 726. If you want to preserve current scale and position of this sprites, set originalHeight property 726 and restart the scene to check whether it works correctly.
```
![ScreenShot](https://user-images.githubusercontent.com/30808673/69491436-88426980-0ed8-11ea-8196-2ed46d034a6f.PNG)

Set the height value displayed in the console for the OriginalScreenHeight of the SpritePositionAdjuster from the Inspector (726 in this case).

![ScreenShot](https://user-images.githubusercontent.com/30808673/69491512-a5c40300-0ed9-11ea-859c-d480e1e503e8.PNG)

That's it. The initial setting has been completed.

After that, even if you change the aspect and height of the GameView,

the position and scale of the sprite set first are reproduced.

### KeepsPositionUpdated

If KeepsPositionUpdate is set to true, Update will always monitor the screen size for changes,

if it has changed, adjust the sprite position and scale immediately.

If false, the screen size will only be checked when the scene is first started,

performance is improved compared to true.

The default value is true.