using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteriorGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _enemy, _obstacle;
    private GameObject _o;

    public void Fill(Vector2 position, int height, int width)
    {
        for (int i = Mathf.RoundToInt(-width/2)+1; i < Mathf.RoundToInt(width/2)-1; i++)
            for (int j = Mathf.RoundToInt(-height/2)+1; j < (height/2)-1; j++)
            {
                if (Mathf.Abs(position.x + i - GridGenerator.width/2) < 2.5 || Mathf.Abs(position.y + j - GridGenerator.height/2) < 2.5)
                    return;
                float rand = Random.Range(0f, 1f);
                if (rand < 0.1)
                    _o = Instantiate(_enemy);
                if (rand > 0.85)
                    _o = Instantiate(_obstacle);
                if (_o != null)
                    _o.transform.position = new Vector3(position.x + i - GridGenerator.width/2, position.y + j - GridGenerator.height/2, -0.05f);
            }
    }
}
