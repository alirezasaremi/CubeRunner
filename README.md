# CubeRunner

[![MIT License](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)
![Unity 6000.6.4f1](https://img.shields.io/badge/Unity-6000.6.4f1-black?logo=unity)

CubeRunner is a minimalist 3D endless runner built with Unity for Android. Jump over approaching blocks, survive as long as possible, and beat your local high score.

The first playable gameplay version is implemented. Android device testing and release builds are still pending.

## Features

Implemented features:

- A fixed side-view camera, cube player, and endless block obstacles.
- Space to jump on desktop and tap to jump on Android.
- One jump at a time, with physics-based landing.
- Survival score and a locally saved best score.
- Gradually faster obstacles with bounded spawn timing.
- Game Over, Restart, and Main Menu navigation.
- Fully offline gameplay with no account or network requirement.

## Requirements

- Unity Editor 6000.6.4f1 (Unity 6.6).
- Android Build Support for Android builds.

## Getting Started

1. Clone this repository: `git clone https://github.com/alirezasaremi/CubeRunner.git`.
2. In Unity Hub, add the cloned `CubeRunner` folder as a project.
3. Select Unity Editor 6000.6.4f1, then open the project.

## Play

Open `Assets/Scenes/MainMenu.unity` in Unity and enter Play mode. Select **Play** to start. You can also open `Assets/Scenes/Gameplay.unity` and enter Play mode directly.

- Android: Tap the gameplay area to jump.
- Desktop or Unity Editor: Press Space to jump.
- Jump over obstacles. The run ends on collision. Select **Restart** to try again or **Main Menu** to return.

The game uses landscape orientation. Your best score is saved locally with Unity PlayerPrefs.

## Project Structure

- `Assets/Scenes/MainMenu.unity` is the opening scene; `Assets/Scenes/Gameplay.unity` is the runner.
- `Assets/Scripts/` contains the small gameplay components and scoring rules.
- `Assets/Materials/` and `Assets/Resources/Obstacle.prefab` contain the simple URP visuals.
- `Packages/` contains package configuration and the dependency lock file.
- `ProjectSettings/` contains Unity project settings.

## Development Status

The gameplay MVP runs in the Unity Editor. Android build and device verification remain future work.

## License

CubeRunner is available under the [MIT License](LICENSE).
