local startTime = os.clock()

local buff = ""
-- for line in io.lines("C:/Users/zhanglinqi/Desktop/Question01.txt") do
--     buff = buff .. line .. "\n"    
-- end

local endTime = os.clock()

print(collectgarbage("count") * 1024)

print("used time " .. (endTime - startTime) * 1000 .. " ms")

print(_VERSION)

for k, v in pairs(os) do
    print (k, v)
end
print (package.cpath, package.config, package.path, package.searchers)
--[[
    local startTime = os.clock()

    local buff = ""
    local tbl = {}
    for line in io.lines("C:/Users/zhanglinqi/Desktop/Question01.txt") do
        table.insert(tbl, line)
    end
    
    buff = table.concat(table, "\n")
    
    local endTime = os.clock()
    
    print(collectgarbage("count") * 1024)
    
    print("used time " .. (endTime - startTime) * 1000 .. " ms")
]]