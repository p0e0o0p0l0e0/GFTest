mystr = "I'm lua"

myTable = {name = "xiaoming", id = 123456}

function print_hello()
	print("hello lua!")
end

function _add(a, b)
	local c = a + b
end

function RunPPP()
	local s = 55
	local _ppp = require("ppp")
	_ppp.x = 5;
	package.loaded["ppp"] = nil
    package.preload["ppp"] = nil
	local _qqq = require("ppp")
	print(_ppp.x);
	print(_qqq.x);
end

RunPPP()