---This script should set post processing to "Nothing" on restart, "RedSplits", "GreenSplits" and "Gold"
---Make sure such post process presets are set up in VTS

function ResetPostProcess()
    local p = Create_VTSPostProcessingUpdateOptions()
    p.postProcessingOn = true
    p.setPostProcessingPreset = true
    p.presetToSet = "Nothing";
    p.postProcessingFadeTime = 0.4
    SetPostProcessingEffectValues(p, {},
    function (onSuccess)
        
    end,
    function (onError)
        
    end)
end

function SetRedPostProcess()
    local p = Create_VTSPostProcessingUpdateOptions()
    p.postProcessingOn = true
    p.setPostProcessingPreset = true
    p.presetToSet = "RedSplits";
    p.postProcessingFadeTime = 0.4
    SetPostProcessingEffectValues(p, {},
    function (onSuccess)
        
    end,
    function (onError)
        
    end)
end

function SetGreenPostProcess()
    local p = Create_VTSPostProcessingUpdateOptions()
    p.postProcessingOn = true
    p.setPostProcessingPreset = true
    p.presetToSet = "GreenSplits";
    p.postProcessingFadeTime = 0.4
    SetPostProcessingEffectValues(p, {}, 
    function (onSuccess)
        
    end,
    function (onError)
        
    end)
end

function SetGoldPostProcess()
    local p = Create_VTSPostProcessingUpdateOptions()
    p.postProcessingOn = true
    p.setPostProcessingPreset = true
    p.presetToSet = "Gold";
    p.postProcessingFadeTime = 0.4
    SetPostProcessingEffectValues(p, {}, function (onSuccess)
        
    end,
    function (onError)
        
    end)
end

---This is performed when the timer starts
function OnStart()
end

---This is performed when the timer pauses
function OnPause()
end

---This is performed when the timer restarts
---You probably want to restart things to default here
function OnReset()
    ResetPostProcess()
end

---This is performed when the timer resumes after pause
function OnResume()
end

---This is performed when the timer splits
---generally you probably don't want to handle this manualy and want to use
---OnGreenSplit() / OnRedSplit() / OnGoldSplit instead
---but if you want advanced behaviours, you can write them here
function OnSplit()
end

---This is performed when you undo a split
---Probably you want to restart things here to previous state or default
function OnUndoSplit()
    ResetPostProcess()
end

---This is performed when you skip split
---You may want to restart things here to default
function OnSkipSplit()
    ResetPostProcess()
end

---This is executed when you end up loosing time and is executed both
---when splitting on red or when the current split ends up red already
function OnRedSplit()
    SetRedPostProcess()
end

---This is executed on split when you end up in the green
function OnGreenSplit()
    SetGreenPostProcess()
end

---This is executed on new best split, but only if you are ahead of PB
function OnGoldSplit()
    SetGoldPostProcess()
end