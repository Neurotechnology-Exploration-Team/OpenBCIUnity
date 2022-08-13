# OpenBCIUnity
Everything you need to transform your game into an OpenBCI compatible masterpiece.

Feel free to fork, clone, change, or use any of the code in this bundle however you wish. It is intended for educational purposes.

## Table of Contents
1. [Prerequisites](#1-prerequisites)
2. [Install brainflow and 2D Sprites dependencies](#2-install-brainflow-and-2d-sprites-dependencies)
   - [Install NuGet for Unity](#install-nuget-for-unity)
   - [Install brainflow NuGet package](#install-brainflow-nuget-package)
   - [Install 2D sprites and other packages needed for UI](#install-2d-sprites-and-other-packages-needed-for-ui)
3. [Add required assets](#3-add-required-assets)
4. [Add the .gitignore](#4-add-the-gitignore)
5. [Fixing errors](#5-fixing-errors)
6. [Creating required GameObjects](#6-creating-required-gameobjects)
7. [Using OpenBCIReader in your own code](#7-using-openbcireader-in-your-own-code)

## 1. Prerequisites

You must have an existing Unity project. This guide has been tested in Unity 2020.3.37f1 on a blank 3D project.

Download the resources for this guide using the green Code -> Download ZIP button

## 2. Install brainflow and 2D Sprites dependencies

### Install NuGet for Unity

1. Download the latest NuGet Unity package from [NuGetForUnity](https://github.com/GlitchEnzo/NuGetForUnity/releases)
   - Click on NuGetForUnity.x.x.x.unitypackage under Assets in the latest release
   - This guide has been tested with release 3.0.5
2. Install in Unity editor
   - Open your Unity project
   - Go to Assets/Import Package/Custom Package...
   - Select the file from [NuGetForUnity](https://github.com/GlitchEnzo/NuGetForUnity/releases) then click Import
   - Use the default import selection

### Install brainflow NuGet package

1. In the Unity editor, go to NuGet/Manage NuGet Packages
2. Search for brainflow (look for author Andrey1994) and click Install
   - This guide has been tested with brainflow version 5.1.1
3. Close NuGet window

### Install 2D sprites and other packages needed for UI

1. In the Unity editor, go to Window/Package Manager
2. Switch the second dropdown on the top left from Packages: In Project to Packages: Unity Registry
3. Select "2D," which should have 7 packages including 2D Sprite
4. Click Install at the bottom right
5. Close the Package Manager when it is finished


## 3. Add required assets

1. Install our provided Unity package
   - Go to Assets/Import Package/Custom Package...
   - Select the openbcireadervx.x.x.unitypackage from this repository
   - Use the default imports

## 4. Add the .gitignore

1. Go to the top level Assets folder in your project
2. Right click in the project files window and select "Show in Explorer" or a similar option to view the folder in your system file explorer
3. Copy the .gitignore file from the zip folder to the top level of your Unity project using your system file explorer

## 5. Fixing errors

1. If you get the error: "Assets\Scripts\OpenBCIReaderDummy.cs(6,7): error CS0246: The type or namespace name 'brainflow' could not be found (are you missing a using directive or an assembly reference?)"
   - Create a folder called net45 inside Assets\Packages\brainflow.x.x.x\lib in your Unity project
   - Copy brainflow.dll from the zip folder to Assets\Packages\brainflow.x.x.x\lib\net45
2. If you get the error: "Failed to load 'Assets/Packages/brainflow.4.9.0/lib/BoardController32.dll', expected x64 architecture, but was x86 architecture. You must recompile your plugin for x64 architecture."
   - First, try reopening the Unity project
   - If that doesn't work:
     - Find Assets\Packages\brainflow.x.x.x\lib\BoardController32.dll and click it to open it in the Unity inspector
     - In the properties window, on the left tab, under CPU, select "x86"
     - In the properties window, on the right tab, select ONLY the "x86" checkbox

## 6. Creating required GameObjects

1. Create an empty GameObject, optionally called bciReader
2. Attach the OpenBCIReaderDummy.cs script from the imported Scripts folder to the new GameObject
3. Create a new object using the BCI Menu Canvas prefab inside the imported Prefabs folder
4. If prompted to import TMP Essentails, click "Import TMP Essentails" and wait for the import to finish, then close the TMP Importer
5. Click the BCI Menu Canvas object; in the inspector, set the BCI Reader Object variable to your bciReader object
6. Add an EventSystem game object; Right click in the hierarchy, then select UI / Event System
7. Switch to the Game tab from the Scene tab
8. Select "16:9 Aspect" instead of "Free Aspect" from the resolution dropdown
9. Click play to test the menu

## 7. Using OpenBCIReader in your own code

OpenBCIReaderI and BCIMenuI provide documentation for all the methods available to you. For the vast majority of games, you will only need to provide the Menu with possible keybinds (such as left, right, shoot, jump, etc.) using bciMenu.SetKeybindNames with a List<string> and use bciMenu.GetInputForKeybind with one of those strings to know whether or not the user is flexing the muscle that they have set to that keybind.
