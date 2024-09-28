---This script requires Sui's VTube Studio API extension
---It also requires beverage_Creature (@7MDigital).png and beverage_Soda_Cola (@7MDigital).png items

function SpawnRedLookingStuff()
    LogWarning("Kurwa");
    local p = Create_VTSExtendedDropItemRequest()
    p.fileName = "beverage_Soda_Cola (@7MDigital).png"
    p.count = 5
    p.dropDefinition = Create_VTSVTSExtendedDropItemDefinition()

    local result = ExtendedDropImages(p)
end

function SpawnGreenLookingStuff()
    LogWarning("Kurwa");
    local p = Create_VTSExtendedDropItemRequest()
    p.fileName = "beverage_Creature (@7MDigital).png"
    p.count = 5
    p.dropDefinition = Create_VTSVTSExtendedDropItemDefinition()
    
    local result = ExtendedDropImages(p)
end

function SpawnLoadsOfGreenLookingStuff()
    local p = Create_VTSExtendedDropItemRequest()
    p.fileName = "beverage_Creature (@7MDigital).png"
    p.count = 50
    p.dropDefinition.bottomEdgeBounce = 0

    local result = ExtendedDropImages(p)
end

---This is executed when you end up loosing time and is executed both
---when splitting on red or when the current split ends up red already
function OnRedSplit()
    SpawnRedLookingStuff()
end

---This is executed on split when you end up in the green
function OnGreenSplit()
    SpawnGreenLookingStuff()
end

---This is executed on new best split, but only if you are ahead of PB
function OnGoldSplit()
    SpawnLoadsOfGreenLookingStuff()
end
