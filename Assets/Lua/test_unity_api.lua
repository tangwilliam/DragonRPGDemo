function test_unity_api()

	print("test_unity_api executes ! ")


	
end

test_unity_api()

local Color = UnityEngine.Color
local GameObject = UnityEngine.GameObject
local ParticleSystem = UnityEngine.ParticleSystem 

function OnComplete()
	print('OnComplete CallBack')
end                       

local go = GameObject('go')
go:AddComponent(typeof(ParticleSystem))
local node = go.transform
node.position = Vector3.one                  
print('gameObject is: '..tostring(go))                 
--go.transform:DOPath({Vector3.zero, Vector3.one * 10}, 1, DG.Tweening.PathType.Linear, DG.Tweening.PathMode.Full3D, 10, nil)
--go.transform:DORotate(Vector3(0,0,360), 2, DG.Tweening.RotateMode.FastBeyond360):OnComplete(OnComplete)            
GameObject.Destroy(go, 2)                  
go.name = '123'
--print('delay destroy gameobject is: '..go.name)  
