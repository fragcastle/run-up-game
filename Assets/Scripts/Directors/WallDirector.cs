using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class WallDirector : BaseBehavior
{
    public Transform Wall;
    public Transform EmptyObject;

    public int MaxSections = 12;
    public float GenerationDistance = 3f;

    public static float WallWidth = 0.3f;
    public static float WallHeight = 8.35f;

    private GameObject _player;
    private float _nextHeight = -8.35f;

    private int _generations;

    private Transform[] _pool;
    private int _moveIndex;
    

    public void Start()
    {
        _player = GameObject.Find(Constants.PlayerObjectName);

        _pool = new Transform[MaxSections];
        SpawnWallSections(MaxSections);
    }

    public void FixedUpdate()
    {
        if (_player != null)
        {
            var playerPos = _player.transform.position;
            if (playerPos.y >= _nextHeight - (MaxSections / 2 * WallHeight))
            {
                // move the section furthest down, up to the top
                MoveWallSectionUp();
            }
        }
    }

    private void MoveWallSectionUp()
    {
        var pos = _pool[_moveIndex].transform.position;
        _pool[_moveIndex].transform.position = new Vector3(pos.x, _nextHeight, pos.z);
        _moveIndex++;
        if (_moveIndex > _pool.Length - 1)
            _moveIndex = 0;
        _nextHeight += WallHeight;
    }

    private void SpawnWallSections(int count)
    {
        var screenWidth = ScreenWidth();
        var xRight = screenWidth / 2;
        var xLeft = -xRight;

        for (int i = 0; i < count; i++)
		{
            var section = (Transform)Instantiate(EmptyObject, new Vector3(0, _nextHeight, transform.position.z), Quaternion.identity);
			var left = SpawnWall(xLeft + WallWidth/2, section);
            var right = SpawnWall(xRight - WallWidth/2, section);

            section.transform.parent = transform;

            right.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));

            _pool[i] = section;
            _nextHeight += WallHeight;
		}        
    }

    private Transform SpawnWall(float x, Transform parent)
    {
        var wall = (Transform)Instantiate(Wall, new Vector3(x, _nextHeight, transform.position.z), Quaternion.identity);
        wall.transform.parent = parent.transform;
        return wall;
    }
}
