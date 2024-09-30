---This script a template file - you can write your functions using it

---This is performed when the timer starts
function OnStart()
end

---This is performed when the timer pauses
function OnPause()
end

---This is performed when the timer restarts
---You probably want to restart things to default here
function OnReset()
end

---This is performed when the timer resumes after pause
function OnResume()
end

---This is performed when the timer splits
---generally you probably don't want to handle this manualy and want to use
---OnGreenSplit() / OnRedSplit() / OnGold / OnGoldSplit instead
---but if you want advanced behaviours, you can write them here
function OnSplit()
end

---This is performed when you undo a split
---Probably you want to restart things here to previous state or default
function OnUndoSplit()
end

---This is performed when you skip split
---You may want to restart things here to default
function OnSkipSplit()
end

---This is executed when you end up loosing time and is executed both
---when splitting on red or when the current split ends up red already
function OnRedSplit()
end

---This is executed on split when you end up in the green
function OnGreenSplit()
end

---This is executed on new best split, but only if you are ahead of PB
function OnGoldSplit()
end

---This is executed on a new best split, but it can be behind the PB
function OnGold()
end

---This is executed when you finish the run and you didn't get to PB
function OnRunFinishedWithoutPB()
end

---This is executed when you finish the run and you managed to get a PB - congrats!
function OnRunFinishedWithPB()
end