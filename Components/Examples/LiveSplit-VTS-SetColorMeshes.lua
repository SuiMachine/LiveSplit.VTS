---This script will apply screen color to different art meshes depending on a split state (maximum of 11 defined)
---You'll need to edit it by providing your own art mesh names which you can find in VTube Studio for your model
---Make sure such post process presets are set up in VTS

ArtMeshesNames = {
    "ArtMesh139",
    "ArtMesh21",
    "ArtMesh14",
    "ArtMesh17",
    "ArtMesh10",
    "ArtMesh4",
    "ArtMesh7",
    "ArtMesh8",
    "ArtMesh12",
    "ArtMesh20",
    "ArtMesh91"
}

function OnInitialize()
    Log("Initialized table with " .. #ArtMeshesNames .. " elements")
end

---This is custom written function and not a part of Lua mappings
function ResetArtMeshes()
    local matcher = Create_ArtMeshMatcher()
    matcher.tintAll = true
    TintArtMesh(Create_ColorTint(255, 255, 255), 1.0, matcher)
end

---Sets a color for current split
---@param color ColorTint
function SetColor(color)
    local currentId = GetLiveSplitState().CurrentSplitIndex
    local artMeshesLength = #ArtMeshesNames
    if currentId >= artMeshesLength then
        LogError("There are more splits defined then art meshes!")
        return
    end

    local artMeshNameForCurrentSplit = ArtMeshesNames[currentId]
    Log("Color " .. artMeshNameForCurrentSplit)

    local matcher = Create_ArtMeshMatcher()
    matcher.nameExact = { artMeshNameForCurrentSplit }
    TintArtMesh(color, 1.0, matcher)
end

function OnStart()
    ResetArtMeshes()
end

---This is performed when the timer restarts
---You probably want to restart things to default here
function OnReset()
    ResetArtMeshes()
end

---This is executed when you end up loosing time and is executed both
---when splitting on red or when the current split ends up red already
function OnRedSplit()
    SetColor(Create_ColorTint(255, 0, 0))
end

---This is executed on split when you end up in the green
function OnGreenSplit()
    SetColor(Create_ColorTint(0, 255, 0))
end

---This is executed on new best split, but only if you are ahead of PB
function OnGoldSplit()
    SetColor(Create_ColorTint(255, 223, 0))
end
