# OpenBCIUnity
Everything you need to transform your game into an OpenBCI compatible masterpiece.

Feel free to fork, clone, change, or use any of the code in this bundle however you wish. It is intended for educational purposes.

## Table of Contents
1. [Prerequisites](#1-prerequisites)
2. [Install brainflow](#2-install-brainflow)
   - [Install NuGet for Unity](#install-nuget-for-unity)
   - [Install brainflow NuGet package](#install-brainflow-nuget-package)
3. [Add required assets](#3-add-required-assets)
4. [Add the .gitignore](#4-add-the-gitignore)
5. [Fixing errors](#5-fixing-errors)
6. [Creating required GameObjects](#6-creating-required-gameobjects)
7. [Creating optional GameObjects](#7-creating-optional-gameobjects)
8. [Using OpenBCIReader in your own code](#8-using-openbcireader-in-your-own-code)

## 1. Prerequisites

You must have an existing Unity project. This guide has been tested in Unity 2020.3.37f1.

Download the resources for this guide using the green Code -> Download ZIP button

## 2. Install brainflow

### Install NuGet for Unity

1. Download the latest NuGet Unity package from [NuGetForUnity](https://github.com/GlitchEnzo/NuGetForUnity/releases)
   - Click on NuGetForUnity.x.x.x.unitypackage under Assets in the latest release
2. Install in Unity editor
   - Open your Unity project
   - Go to Assets/Import Package/Custom Package...
   - Select the file from [NuGetForUnity](https://github.com/GlitchEnzo/NuGetForUnity/releases) then click Import
   - Use the default selection

### Install brainflow NuGet package

1. In the Unity editor, go to NuGet/Manage NuGet Packages
2. Search for brainflow (look for author Andrey1994) and click Install
3. Close NuGet window


## 3. Add required assets

1. Make a Scripts folder and a Prefabs folder in your project if you have not already
2. Copy the following scripts from the zip folder to your Scripts folder:
   - BCIMenu.cs
   - BCIMenuChannel.cs
   - BCIMenuI.cs
   - OpenBCIReaderDummy.cs
   - OpenBCIReaderI.cs
3. Copy the following prefabs from the zip folder to your Prefabs folder:
   - BCI Menu Canvas.prefab
   - Channel.prefab

## 4. Add the .gitignore

1. Copy the .gitignore file from the zip folder to the top level of your Unity project

## 5. Fixing errors

1. If you get the error: "Assets\Scripts\OpenBCIReaderDummy.cs(6,7): error CS0246: The type or namespace name 'brainflow' could not be found (are you missing a using directive or an assembly reference?)"
   - Create a folder called net45 inside Assets\Packages\brainflow.x.x.x\lib in your Unity project
   - Copy [brainflow.dll](https://github.com/Neurotechnology-Exploration-Team/OpenBCIUnity/blob/main/brainflow.dll) to Assets\Packages\brainflow.x.x.x\lib\net45
2. If you get the error: "Failed to load 'Assets/Packages/brainflow.4.9.0/lib/BoardController32.dll', expected x64 architecture, but was x86 architecture. You must recompile your plugin for x64 architecture."
   - First, try reopening the Unity project
   - If that doesn't work:
     - Find Assets\Packages\brainflow.x.x.x\lib\BoardController32.dll and click it to open it in the Unity inspector
     - In the properties window, on the left tab, under CPU, select "x86"
     - In the properties window, on the right tab, select ONLY the "x86" checkbox

## 6. Creating required GameObjects

1. Create an empty GameObject, optionally called bciReader
2. Attach the OpenBCIReaderDummy.cs script to the new GameObject
3. Create a new object using the BCI Menu Canvas prefab
4. Click the BCI Menu Canvas object; in the inspector, set the OpenBCIReaderI variable to your bciReader object

---

You now have everything you need to use OpenBCI in your project! If you have been working on a new project and want to test it out, follow step 7. If you have an existing project that you are adding OpenBCI functionality to, use the example files from step 7 and the additional notes in step 8 to continue.

---

## 7. Creating optional GameObjects

1. Create a new Cube or other solid object in the scene
2. Add InputHandler.cs and TopDownCarController.cs from the ZIP file
3. Click the GameObject and set the OpenBCIReaderI variable to your bciReader, and the BCIMenuI variable to your BCI Menu Canvas object

## 8. Using OpenBCIReader in your own code

OpenBCIReaderI and BCIMenuI provide documentation for all the methods available to you. For the vast majority of games, you will only need the code that InputHandler.cs uses. Provide the Menu with possible keybinds (such as left, right, shoot, jump, etc.) using bciMenu.SetKeybindNames with a List<string>. Then, use bciMenu.GetInputForKeybind with one of those strings to know whether or not the user is flexing the muscle that they have set to that keybind.
