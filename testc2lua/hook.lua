function hookfunc(event, line)
	local s = debug.getinfo(2).short_src
	CHook(s, line)
end

function printlocal(valname)
	-- lua中没法根据变量名获得变量的信息，所以下面只能取得栈中所有本地变量的信息
	-- 然后一一对比，看看是否是要查看的变量
	local i = 1
	repeat
		local name, value = debug.getlocal(4, i) -- 第1层是当前函数，第2层是c++中的CHook， 第3层是hookfunc，第4层才是我们要跟踪的函数栈
		if name == nil then
			print("变量不存在");
			return
		end
		if name == valname then
			print(name .. ": " .. value)
			return
		end
		i = i + 1
	until false
end

debug.sethook(hookfunc, "l")