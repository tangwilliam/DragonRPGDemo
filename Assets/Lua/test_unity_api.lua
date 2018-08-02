function test_unity_api()

	print("test_unity_api executes ! ")


	
end

test_unity_api()

local TestClass = {};

function TestClass:New( entity )
	if self ~= TestClass then return nil, "First argument must be self." end
	local new_instance = setmetatable( {} , { __metatable = {}, __index = TestClass } );
	new_instance.entity = entity;

	return new_instance;
end

function TestClass:Start()

	print( "Lua TestClass Start: " .. self.entity:GetName() );


end

function TestClass:DoThings( param )
	
	print("TestClass : DoThings with " .. tostring(param) )
end

function  TestClass:CalcAddTwoNum( a , b )
	
	return a + b
end

--return TestClass;

TestClass:DoThings(2)

function CalcAddTwoNumFunc( a, b)
	return a + b
end


-- local Color = UnityEngine.Color
-- local GameObject = UnityEngine.GameObject
-- local ParticleSystem = UnityEngine.ParticleSystem 

-- function OnComplete()
-- 	print('OnComplete CallBack')
-- end                       

-- local go = GameObject('go')
-- go:AddComponent(typeof(ParticleSystem))
-- local node = go.transform
-- node.position = Vector3.one                  
-- print('gameObject is: '..tostring(go))                 
-- --go.transform:DOPath({Vector3.zero, Vector3.one * 10}, 1, DG.Tweening.PathType.Linear, DG.Tweening.PathMode.Full3D, 10, nil)
-- --go.transform:DORotate(Vector3(0,0,360), 2, DG.Tweening.RotateMode.FastBeyond360):OnComplete(OnComplete)            
-- GameObject.Destroy(go, 2)                  
-- go.name = '123'
-- --print('delay destroy gameobject is: '..go.name)  
