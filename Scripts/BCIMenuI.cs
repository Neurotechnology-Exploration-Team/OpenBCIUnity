using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface BCIMenuI
{
    /// <summary>
    /// Call this method to stop time and make the BCIMenu canvas active
    /// </summary>
    public void Pause();
    /// <summary>
    /// Call this method to resume time and make the BCIMenu canvas disappear
    /// </summary>
    public void Resume();

    /// <summary>
    /// Call this method to get an ordered list of the current keybinds
    /// </summary>
    public List<string> GetKeybindNames();
    /// <summary>
    /// Call this method to provide the Menu with an ordered list of possible keybinds
    /// </summary>
    public void SetKeybindNames(List<string> keybinds);

    /// <summary>
    /// Call this method to get a true or false button like input for one of the possible keybinds
    /// </summary>
    public bool GetInputForKeybind(string keybind);
    /// <summary>
    /// Call this method to get a raw double input for one of the possible keybinds
    /// </summary>
    public double GetRawInputForKeybind(string keybind);

    /// <summary>
    /// ignore this method, for internal use only
    /// </summary>
    public void ResetThresholdSliders();
    /// <summary>
    /// ignore this method, for internal use only
    /// </summary>
    public void SetAllKeybinds();
    /// <summary>
    /// ignore this method, for internal use only
    /// </summary>
    public void SetAllThresholdParamters();
}
