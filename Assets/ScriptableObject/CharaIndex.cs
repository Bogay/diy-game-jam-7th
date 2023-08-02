using UniDi;
using UnityEngine;

public class CharaIndex : MonoBehaviour
{
    [Inject]
    public CharaBinder.PlayerChara _playerChara;

    public int _currentSelect;

    public CharaIndex(CharaBinder.PlayerChara playerChara)
    {
        _playerChara = playerChara;
    }

    private void Update()
    {
        _currentSelect = _playerChara.currentSelect;
    }
}
