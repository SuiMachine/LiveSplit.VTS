---This script requires Sui's VTube Studio API extension
---It also requires beverage_Creature (@7MDigital).png and beverage_Soda_Cola (@7MDigital).png items

function SpawnRedLookingStuff()
    local p = Create_VTSExtendedDropItemRequest()
    p.fileName = "beverage_Soda_Cola (@7MDigital).png"
    p.count = 5

    local result = ExtendedDropImages(p)
end

function SpawnGreenLookingStuff()
    local p = Create_VTSExtendedDropItemRequest()
    p.fileName = "beverage_Creature (@7MDigital).png"
    p.count = 5
    
    local result = ExtendedDropImages(p)
end

function SpawnLoadsOfGreenLookingStuff()
    local p = Create_VTSExtendedDropItemRequest()
    p.fileName = "beverage_Creature (@7MDigital).png"
    p.count = 30

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

function OnGold()
    SpawnRedLookingStuff()

    local p2 = Create_VTSExtendedDropItemRequest()
    p2.fileName = "beverage_Creature (@7MDigital).png"
    p2.count = 1
    local result2 = ExtendedDropImages(p2)
end

---This is executed on new best split, but only if you are ahead of PB
function OnGoldSplit()
    SpawnLoadsOfGreenLookingStuff()
end

---This is executed when you finish the run and you didn't get to PB
function OnRunFinishedWithoutPB()
    OnRedSplit()
end

---This is executed when you finish the run and you managed to get a PB - congrats!
function OnRunFinishedWithPB()
    OnGoldSplit()
end