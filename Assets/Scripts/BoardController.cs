using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets.Scripts
{
    public class BoardController : MonoBehaviour
    {
        Tilemap _tilemap;
        Grid _grid;

        // Temporary field for testing.
        [SerializeField]
        TileBase _testTile;

        void Awake()
        {
            _tilemap = GetComponent<Tilemap>();
            _grid = GetComponentInParent<Grid>();
        }

        void Update()
        {
            if (PersistentGameManger.Instance.isPaused == true)
            {
                return;
            }

            if (Input.GetKeyUp(KeyCode.Mouse0) == true)
            {
                Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                // Get the position of the mouse in the grid.
                Vector3Int cellPosition = _grid.LocalToCell(mousePosition);

                if (_tilemap.HasTile(cellPosition) == true)
                {
                    _tilemap.SetTile(cellPosition, _testTile);
                }
            }
        }
    }

}
