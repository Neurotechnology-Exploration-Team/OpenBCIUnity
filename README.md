# OpenBCIUnity
Everything you need to transform your game into an OpenBCI compatible masterpiece.

Feel free to fork, clone, change, or use any of the code in this bundle however you wish. It is intended for educational purposes.

## Table of Contents
1. [Prerequisites](#1-prerequisites)
2. [Install 2D Sprites dependencies](#2-install-2d-sprites-dependencies)
3. [Add required assets](#3-add-required-assets)
4. [Add the .gitignore](#4-add-the-gitignore)
5. [Fixing errors](#5-fixing-errors)
6. [Creating required GameObjects](#6-creating-required-gameobjects)
7. [Using OpenBCIReader in your own code](#7-using-openbcireader-in-your-own-code)

## 1. Prerequisites

You must have an existing Unity project. This guide has been tested in Unity 2020.3.37f1, 2021.3.8f1, and 2021.3.6f1 on a blank 3D project.

Download the resources for this guide by clicking on the zip folder in the latest release on the [Releases](https://github.com/Neurotechnology-Exploration-Team/OpenBCIUnity/releases) page and extracting it

## 2. Install 2D Sprites dependencies

1. In the Unity editor, go to Window/Package Manager
2. Switch the second dropdown on the top left from Packages: In Project to Packages: Unity Registry
3. Select "2D," which should have 7 packages including 2D Sprite
4. Click Install at the bottom right
5. Close the Package Manager when it is finished

## 3. Add required assets

1. Install our provided Unity package
   - Open your Assets folder in the project window
   - Go to Assets/Import Package/Custom Package...
   - Select the openbcireadervx.x.x.unitypackage from this repository
   - Use the default imports

## 4. Add the .gitignore

1. Go to the top level Assets folder in your project
2. Right click in the project files window and select "Show in Explorer" or a similar option to view the folder in your system file explorer
3. Copy the .gitignore file from the zip folder to the top level of your Unity project using your system file explorer

## 5. Fixing errors

1. If you get the error: "Failed to load 'Assets/Packages/brainflow.4.9.0/lib/BoardController32.dll', expected x64 architecture, but was x86 architecture. You must recompile your plugin for x64 architecture."
   - First, try reopening the Unity project
   - If that doesn't work:
     - Find Assets\Packages\brainflow.x.x.x\lib\BoardController32.dll and click it to open it in the Unity inspector
     - In the properties window, on the left tab, under CPU, select "x86"
     - In the properties window, on the right tab, select ONLY the "x86" checkbox
2. If you aren't on Windows, you may have other issues with brainflow's "GENERAL_ERROR"s or compilation issues
   - Find the OpenBCIReader/brainflow folder
   - Delete everything from that folder
   - Follow Unity instructions from [this page](https://brainflow.readthedocs.io/en/stable/GameEngines.html) but place all files into the OpenBCIUnity/brainflow folder

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
