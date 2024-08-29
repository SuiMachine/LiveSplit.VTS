---This script will load beverage_Soda_Cola (@7MDigital).png and beverage_Creature (@7MDigital).png items.
---Make sure you hae such items.
---Alost make sure to configure offset of items in relation to your character

PositionOffsetFromCharacterRoot = {
    x = 0,
    y = 1
}

SpawnSpace = 1

function ResetPostProcess()
    local p = Create_VTSItemUnloadOptions()
    p.unloadAllInScene = true
    UnloadItem(p)
end

function Pin()
    
end

function SetRedPostProcess()
    local res = GetCurrentModel()
    -- If there is no model, return
    if res == nil then 
        return
    end


    local modelPosition = res.data.modelPosition

    local center = modelPosition.positionX + PositionOffsetFromCharacterRoot.x
    local spawnPointX = center - SpawnSpace / 2
    local lastSplit = GetLiveSplitState().CurrentSplitIndex - 1
    local splitCount = #GetRunAsArray() - 1
    local percent = lastSplit / splitCount
    local offsetX = SpawnSpace * percent
    Log("Progress" .. tostring(lastSplit) .. "/" .. tostring(splitCount))
    
    local p = Create_VTSItemLoadOptions();
    p.fadeTime = 0.4
    p.size = 0.1
    p.order = 10
    p.positionX = spawnPointX + offsetX
    p.positionY = modelPosition.positionY + PositionOffsetFromCharacterRoot.y

    local loadResult = LoadItem("beverage_Creature (@7MDigital).png", p)
end

function SetGreenPostProcess()
    local res = GetCurrentModel()
    -- If there is no model, return
    if res == nil then 
        return
    end


    local modelPosition = res.data.modelPosition

    local center = modelPosition.positionX + PositionOffsetFromCharacterRoot.x
    local spawnPointX = center - SpawnSpace / 2
    local lastSplit = GetLiveSplitState().CurrentSplitIndex - 1
    local splitCount = #GetRunAsArray() - 1
    local percent = lastSplit / splitCount
    local offsetX = SpawnSpace * percent
    Log("Progress" .. tostring(lastSplit) .. "/" .. tostring(splitCount))
    
    local p = Create_VTSItemLoadOptions();
    p.fadeTime = 0.4
    p.size = 0.1
    p.order = 10
    p.positionX = spawnPointX + offsetX
    p.positionY = modelPosition.positionY + PositionOffsetFromCharacterRoot.y

    local loadResult = LoadItem("beverage_Soda_Cola (@7MDigital).png", p)
end

function LerpPositionBasedOnSplitNumber(width)
    
end

function SetGoldPostProcess()
    SetGreenPostProcess()
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
