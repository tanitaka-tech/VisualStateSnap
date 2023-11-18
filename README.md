# Visual State Snap

このパッケージは現在開発中です...

[![openupm](https://img.shields.io/npm/v/com.tanitaka.concurrent-unitask-handler?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/com.tanitaka.concurrent-unitask-handler/)
![license](https://img.shields.io/github/license/tanitaka-tech/ConcurrentUniTaskHandler)

## Features
- 複数のオブジェクトの状態を`VisualStateSnap`としてまとめて保存できます。
- `VisualStateSnap`を切り替えることで、複数のオブジェクトの状態を一括で変更できます。
- TimelineのClipとして`VisualStateSnap`を指定することで、複数のオブジェクトの状態をアニメーションできます。

## Installation

### Install via git URL
1. Open the Package Manager
1. Press [＋▼] button and click Add package from git URL...
1. Enter the following:
    - https://github.com/tanitaka-tech/Visual-State-Snap.git

### ~~Install via OpenUPM~~ (not yet)
```sh
openupm add com.tanitaka-tech.visual-state-snap
```

## Required
- [Unity SerializeReferenceExtensions](https://github.com/mackysoft/Unity-SerializeReferenceExtensions)

## Usage

### VisualStateSnapを定義する方法
1. 任意のGameObjectに`VisualStateSnapManager`をアタッチします。

2. `SnapTargetsReference`に状態として保存したいオブジェクトを追加します。
   指定できる状態は下記に定義されたclass群です。

3. `Visual State Snaps`に定義したい状態を追加します。
   - `Snap Visual State`ボタンを押すと、その時のEditor上の状態がSnappedValueに入ります。

4. `Apply` ボタンを押すと、SnappedValueが各オブジェクトに適用されます。

### Timelineでアニメーションさせる方法


## Roadmap
- さらに分かりやすく使いやすいように、編集用Windowの作成
- Import/Export機能
- Validation機能

## Contribution
IssueやPR作成、大歓迎です！
SnapPropertyの追加や、Editor拡張の作成など、様々な形での貢献をお待ちしています。

### 動作確認しながらCloneする方法
1. このRepositoryをForkします。
2. 手元のUnityProjectのPackagesフォルダ(manifest.jsonがあるところ)にCloneします。
3. manifest.jsonにdependenciesに下記を追記し依存を追加します。(既にある場合は一旦削除しておきます)
```json
    "com.tanitaka-tech.visual-state-snap": "../VisualStateSnap",
```
以上で、手元のUnityProjectで動作確認しつつ、準備が整いました！