using UnityEngine;

namespace Code
{
    internal sealed class MiniMap : IController, ILateRun
    {
	    private Transform _player;
	    private Transform _miniMapTransform;
	    private Camera _miniMap;

	    public MiniMap(Transform player, Transform miniMapCamera)
	    {
		    _player = player;
		    _miniMapTransform = miniMapCamera;
		    _miniMapTransform.parent = null;
		    _miniMapTransform.rotation = Quaternion.Euler(90.0f, 0, 0);
		    _miniMapTransform.position = _player.position + new Vector3(0, 5.0f, 0);
		    
		    var rt = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");
		    _miniMap.targetTexture = rt;
	    }


	    public void LateRun(float deltaTime)
	    {
		    var newPosition = _player.position;
		    newPosition.y = _miniMapTransform.position.y;
		    _miniMapTransform.position = newPosition;
		    _miniMapTransform.rotation = Quaternion.Euler(90, _player.eulerAngles.y, 0);
	    }
    }
}