using System.Collections.Generic;
using UnityEngine;
 [RequireComponent(typeof(Animator))]
public class Weapon : MonoBehaviour {
    [SerializeField] private GameObject _ammoPrefab;
    [SerializeField] private float _weaponVelocity = 2;

    [SerializeField] private Vector3 _maxammo = new Vector3(2,2,2) ;
    private static List<GameObject> _ammoPool;
    [SerializeField] private int _poolSize = 7;

    private bool _isFiring;
    private Camera _localCamera;
    private float _positiveSlope;
    private float _negativeSlope;
    private Animator _anim;
    enum Quadrant {
        East,
        South,
        West,
        North
    }

    void Start() {
        _anim = GetComponent<Animator>();
        _isFiring = false;
        _localCamera = Camera.main;
        Vector2 lowerLeft = _localCamera.ScreenToWorldPoint(new Vector2(0, 0));
        Vector2 upperRight = _localCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        Vector2 upperLeft = _localCamera.ScreenToWorldPoint(new Vector2(0, Screen.height));
        Vector2 lowerRight = _localCamera.ScreenToWorldPoint(new Vector2(Screen.width, 0));
        _positiveSlope = GetSlope(lowerLeft, upperRight);
        _negativeSlope = GetSlope(upperLeft, lowerRight);
    }
    void Awake() {
        if (_ammoPool == null) {
            _ammoPool = new List<GameObject>();
        }
        for (int i = 0; i < _poolSize; i++) {
            GameObject ammoObject = Instantiate(_ammoPrefab);
            ammoObject.SetActive(false);
            _ammoPool.Add(ammoObject);
        }
    }
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            _isFiring=true;
            FireAmmo();
        }
        UpdateState();
    }

    float GetSlope(Vector2 pointOne, Vector2 pointTwo) {
        return (pointTwo.y - pointOne.y) / (pointTwo.x - pointOne.x);
    }
    public GameObject SpawnAmmo(Vector3 location) {
        foreach (GameObject ammo in _ammoPool) {
            if (ammo.activeSelf == false) {
                ammo.SetActive(true);
                ammo.transform.position = location;
                return ammo;
            }
        }
        return null;
    }
    void OnDestroy() {
        _ammoPool = null;
    }

    void FireAmmo() {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 difference= mousePosition - transform.position;
        Vector3 travel;
       // print("diff mag: "+difference.magnitude);
       // print("max: "+ _maxammo.magnitude);
        if(difference.magnitude > 11.0f){
           // print(difference.normalized);
            travel=new Vector3(2,2,2); // when ammo is fired at long distance it goes to a particular value of vector
        }
        else travel=mousePosition;
        GameObject ammo = SpawnAmmo(transform.position);
        if (ammo != null) {
            Arc arcScript = ammo.GetComponent<Arc>();
            float travelDuration = 1.0f / _weaponVelocity;
            StartCoroutine(arcScript.TravelArc(travel, travelDuration));
        }
    }

    bool HigherThanPositiveSlopeLine(Vector2 inputPosition) {
        Vector2 playerPosition = gameObject.transform.position;
        Vector2 mousePosition =_localCamera.ScreenToWorldPoint(inputPosition);
        float yIntercept = playerPosition.y - (_positiveSlope *playerPosition.x);
        float inputIntercept = mousePosition.y - (_positiveSlope *mousePosition.x);
        return inputIntercept > yIntercept;
        }
    bool HigherThanNegativeSlopeLine(Vector2 inputPosition) {
        Vector2 playerPosition = gameObject.transform.position;
        Vector2 mousePosition =
        _localCamera.ScreenToWorldPoint(inputPosition);
        float yIntercept = playerPosition.y - (_negativeSlope *playerPosition.x);
        float inputIntercept = mousePosition.y - (_negativeSlope *mousePosition.x);
        return inputIntercept > yIntercept;
    }

    Quadrant GetQuadrant() {
        Vector2 mousePosition = Input.mousePosition;
        Vector2 playerPosition = transform.position;
        bool higherThanPositiveSlopeLine = HigherThanPositiveSlopeLine(Input.mousePosition);
        bool higherThanNegativeSlopeLine = HigherThanNegativeSlopeLine(Input.mousePosition);
        if (!higherThanPositiveSlopeLine && higherThanNegativeSlopeLine) {
            return Quadrant.East;
        }
        else if (!higherThanPositiveSlopeLine && !higherThanNegativeSlopeLine) {
            return Quadrant.South;
        }
        else if (higherThanPositiveSlopeLine && !higherThanNegativeSlopeLine) {
            return Quadrant.West;
        }
        else {
            return Quadrant.North;
        }
    }

    void UpdateState() {
        if (_isFiring) {
            Vector2 quadrantVector;
            Quadrant quadEnum = GetQuadrant();
            switch (quadEnum) {
                case Quadrant.East:
                    quadrantVector = new Vector2(1.0f, 0.0f);
                    break;
                case Quadrant.South:
                    quadrantVector = new Vector2(0.0f, -1.0f);
                    break;
                case Quadrant.West:
                    quadrantVector = new Vector2(-1.0f, 0.0f);
                    break;
                case Quadrant.North:
                    quadrantVector = new Vector2(0.0f, 1.0f);
                    break;
                default:
                    quadrantVector = new Vector2(0.0f, 0.0f);
                    break;
            }
            _anim.SetBool("isFiring", true);
            _anim.SetFloat("fireXDir", quadrantVector.x);
            _anim.SetFloat("fireYDir", quadrantVector.y);
            _isFiring = false;
        }
        else {
            _anim.SetBool("isFiring", false);
        }
    }
}
