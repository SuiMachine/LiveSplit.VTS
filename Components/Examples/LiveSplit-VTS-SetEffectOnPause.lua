---This script should set post processing to "Nothing" on restart, "RedSplits", "GreenSplits" and "Gold"
---Make sure such post process presets are set up in VTS

function SetPausePostProcess(isEnabled)
    local p = Create_VTSPostProcessingUpdateOptions()
    p.postProcessingOn = isEnabled
    p.setPostProcessingPreset = true
    p.presetToSet = "Pause"
    p.postProcessingFadeTime = 0.4
    SetPostProcessingEffectValues(p, {})
end

---This is performed when the timer restarts
---You probably want to restart things to default here
function OnReset()
    SetPausePostProcess(false)
end

---This is performed when the timer resumes after pause
function OnResume()
    SetPausePostProcess(false)
end

function OnPause()
    SetPausePostProcess(true)
end