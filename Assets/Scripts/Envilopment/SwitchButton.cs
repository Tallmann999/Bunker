using UnityEngine;

public class SwitchButton : MonoBehaviour
{

    [SerializeField] private SpriteRenderer _currentSprite;
    [SerializeField] private SpriteRenderer _onSpriteStatusSprite;

    public bool ButtonOn { get; set; } = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            if (player.CardAccessStatus)
            {
                _currentSprite.sprite = _onSpriteStatusSprite.sprite;
                ButtonOn = true;
            }
        }
    }
}
