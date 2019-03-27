using System.Collections;
using UnityEngine;
/// <summary>
/// Generates corridors that connect to rooms, every room spawns up to 4 corridors, and every corridor has a chance to spawn a new room, spawn chance decreases during generation
/// </summary>
public class CorridorGenerator : MonoBehaviour
{
    private int _length, _xOffset, _yOffset;
    private bool[] _borders = { false, false, false, false };

    // Determine chances to generate new corridors
    public void CreateCorridors(Vector2 position, int width, int height)
    {
        MeasureBorderProximity(_borders, position);
        if (Random.Range(0f, 1f) < 0.8f / GridGenerator.Corridors && _borders[1]) StartCoroutine(PlaceCorridor(position, width, 0, 0, 1, 1));
        if (Random.Range(0f, 1f) < 0.8f / GridGenerator.Corridors && _borders[3]) StartCoroutine(PlaceCorridor(position, width, 0, 0, 1, -1));
        if (Random.Range(0f, 1f) < 0.8f / GridGenerator.Corridors && _borders[0]) StartCoroutine(PlaceCorridor(position, 0, height, 1, 0, 1));
        if (Random.Range(0f, 1f) < 0.8f / GridGenerator.Corridors && _borders[2]) StartCoroutine(PlaceCorridor(position, 0, height, 1, 0, -1));
    }

    // checks proximity of borders to determine if corridors are allowed to be generated, if too close to a border, it can only generate towards the opposite side
    bool[] MeasureBorderProximity(bool[] borders, Vector2 position)
    {
        if (position.x < GridGenerator.width - 37 && position.y < GridGenerator.height - 37 && position.x > 37) //Up (checks up, left and right)
            borders[0] = true;

        if (position.x < GridGenerator.width - 37 && position.y < GridGenerator.height - 37 && position.y > 37) //Right (checks up, down and right)
            borders[1] = true;

        if (position.x < GridGenerator.width - 37 && position.y > 37 && position.x > 37) //Down (checks down, left and right)
            borders[2] = true;

        if (position.x > 37 && position.y < GridGenerator.height - 37 && position.y > 37) //Left (checks up, down and left)
            borders[3] = true;

        return borders;
    }

    // Very complex and confusing calculations, do not touch as it is needed to use for all directions as a single method
    IEnumerator PlaceCorridor(Vector2 pos, int x, int y, int ix, int iy, int mult)
    {
        _length = Random.Range(20, 30);
        _xOffset = Mathf.FloorToInt(Random.Range(-x, x) / 2);
        _yOffset = Mathf.FloorToInt(Random.Range(-y, y) / 2);
        for (int i = 0; i < _length; i++)
        {
            RoomGenerator g = GridGenerator.objs[Mathf.RoundToInt(mult * i * ix + pos.x + iy * _xOffset + ix * mult * x / 2)][Mathf.RoundToInt(mult * i * iy + pos.y + ix * _yOffset + iy * mult * y / 2)].GetComponent<RoomGenerator>();
            g.ToFloor();
            if (i == _length - 1 && Random.Range(0f, 1f) <= 1/GridGenerator.Rooms)
                g.Generate();

            yield return new WaitForSeconds(0.01f*Time.deltaTime);
        }
    }
}
