function hookfunc(event, line)
	local s = debug.getinfo(2).short_src
	CHook(s, line)
end

function printlocal(valname)
	-- lua��û�����ݱ�������ñ�������Ϣ����������ֻ��ȡ��ջ�����б��ر�������Ϣ
	-- Ȼ��һһ�Աȣ������Ƿ���Ҫ�鿴�ı���
	local i = 1
	repeat
		local name, value = debug.getlocal(4, i) -- ��1���ǵ�ǰ��������2����c++�е�CHook�� ��3����hookfunc����4���������Ҫ���ٵĺ���ջ
		if name == nil then
			print("����������");
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