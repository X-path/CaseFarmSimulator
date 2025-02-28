using System;
using UnityEngine;

public class UpdatingState : IBuildingState
{
    private int selectedObjectIndex = -1;
    private int gameObjectIndex = -1;
    private Grid grid;
    private PreviewSystem previewSystem;
    private GridData floorData;
    private GridData furnitureData;
    private ObjectPlacer objectPlacer;
    private SoundFeedback soundFeedback;

    public UpdatingState(Grid grid,
                         PreviewSystem previewSystem,
                         GridData floorData,
                         GridData furnitureData,
                         ObjectPlacer objectPlacer,
                         SoundFeedback soundFeedback)
    {
        this.grid = grid;
        this.previewSystem = previewSystem;
        this.floorData = floorData;
        this.furnitureData = furnitureData;
        this.objectPlacer = objectPlacer;
        this.soundFeedback = soundFeedback;
        //previewSystem.StartShowingMovePreview(placedGameObjects[gameObjectIndex]);
    }

    public void EndState()
    {
        previewSystem.StopShowingPreview();
    }

    public void OnAction(Vector3Int gridPosition)
    {
        // Nesnenin hangi grupta olduðunu bul (zemin mi, mobilya mý?)
        GridData selectedData = null;
        if (!furnitureData.CanPlaceObejctAt(gridPosition, Vector2Int.one))
        {
            selectedData = furnitureData;
        }
        else if (!floorData.CanPlaceObejctAt(gridPosition, Vector2Int.one))
        {
            selectedData = floorData;
        }

        // Eðer seçili nesne yoksa hata ver
        if (selectedData == null)
        {
            // soundFeedback.PlaySound(SoundType.wrongPlacement);
            return;
        }

        // Seçili nesnenin indeksini al
        gameObjectIndex = selectedData.GetRepresentationIndex(gridPosition);
        if (gameObjectIndex == -1)
            return;

        // **Mevcut nesneyi bul**
        GameObject selectedObject =objectPlacer.GetPlacedObject(gameObjectIndex);
        if (selectedObject == null)
            return;

        previewSystem.StartShowingMovePreview(selectedObject);

        // Nesnenin eski yerini boþalt
        selectedData.RemoveObjectAt(gridPosition);

        // Yeni konuma yerleþtir
        objectPlacer.MoveObject(gameObjectIndex, grid.CellToWorld(gridPosition));
        selectedData.AddObjectAt(gridPosition, Vector2Int.one, selectedObjectIndex, gameObjectIndex);

        // soundFeedback.PlaySound(SoundType.Move);
    }

    public void UpdateState(Vector3Int gridPosition)
    {
        bool validity = !floorData.CanPlaceObejctAt(gridPosition, Vector2Int.one) ||
                        !furnitureData.CanPlaceObejctAt(gridPosition, Vector2Int.one);
        previewSystem.UpdatePosition(grid.CellToWorld(gridPosition), validity);
    }
}
