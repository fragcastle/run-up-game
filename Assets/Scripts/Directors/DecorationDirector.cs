using System.Collections.Generic;
using UnityEngine;

public class DecorationDirector : BaseBehavior
{
    public List<Transform> Decorations;
    public int SpawnIntervalMin = 3;
    public int SpawnIntervalMax = 15;

    private int _spawnInterval;

    private float _spawnTimer;
    private GameObject _player;
    private PlayerController _playerController;

    private int _maxObjects = 0;

    void Start()
    {
        _player = GameObject.Find(Constants.PlayerObjectName);
        _playerController = _player.GetComponent<PlayerController>();
    }

    void FixedUpdate()
    {
        if (Decorations != null && Decorations.Count > 0 && _player != null)
        {
            if (_spawnTimer >= _spawnInterval)
            {
                _spawnTimer = 0f;
                _spawnInterval = Random.RandomRange(SpawnIntervalMin, SpawnIntervalMax);

                // spawn stuff!
                var index = Random.Range(0, Decorations.Count);

                var Obj = Decorations[index];
                var obj = (Transform)Instantiate(Obj, new Vector3(0, _player.transform.position.y + 5, transform.position.z), Quaternion.identity);
                var controller = obj.GetComponent<DecorationController>();
                var collider = obj.GetComponent<BoxCollider2D>();
                var x = Random.RandomRange(-1.85f, 1.85f);
                if (!controller.RandomizePlacement)
                {
                    x = 0; // center in the screen
                }

                obj.transform.parent = transform;
                obj.transform.position = new Vector3(x, obj.transform.position.y, transform.position.z);
            }
            _spawnTimer += Time.deltaTime;
        }
    }

    /// <summary>
    /// For object pooling later. Take how fast the player is traveling,
    /// how big the screen is, and what our spawn interval is and compute
    /// how many objects of each obstacle type we should pool.
    /// </summary>
    private void ComputePoolSize()
    {
        // how far will the player travel during our spawn interval
        var screenHeight = ScreenHeight(); // units of screen height
        var framesToScaleScreen = screenHeight / _playerController.RateOfTravel(); // how many frames will it take for the player to scale the screen?
        var timeToScaleScreen = framesToScaleScreen * Time.deltaTime; // at the current FPS, how long will it take the player to travel up the screen?
        if (timeToScaleScreen > _spawnInterval)
        {
            var numberOfObjects = timeToScaleScreen / _spawnInterval; // how many objects *could* exist on the screen at one time?
            var buffer = 3; // add some buffer
        }
    }
}
