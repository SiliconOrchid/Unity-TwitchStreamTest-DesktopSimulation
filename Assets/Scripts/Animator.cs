using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animator : MonoBehaviour
{

    [SerializeField]
    public GameObject _backgroundWindowBox;

    [SerializeField]
    public GameObject _codeBox;

    [SerializeField]
    public Camera _camera;

    private AppStateEnum currentAppState;

    private Vector3 leftPosition = new Vector3(-500, 10, -10);
    private Vector3 rightPosition = new Vector3(500, 10, -10);



    private enum AppStateEnum
    {
        Pausing,
        FirstMove,
        SecondMove,
        ThirdMove,
        FourthMove,
        Dormant
    }



    // Start is called before the first frame update
    void Start()
    {
       // Reset();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateRepositionMovingBox();
        UpdateClickHandler();
    }

    private void Reset()
    {
        currentAppState = AppStateEnum.Pausing;
        _codeBox.transform.position = leftPosition;
        StartCoroutine(PauserCoroutine());
    }


    private void UpdateRepositionMovingBox()
    {

            switch (currentAppState)
            {
                case AppStateEnum.Pausing:
                {
                    break;
                }

                case AppStateEnum.FirstMove:
                {
                    _codeBox.transform.position = Vector3.MoveTowards(_codeBox.transform.position, rightPosition, 300 * Time.deltaTime);

                    if (_codeBox.transform.position.x == rightPosition.x)
                    {
                        currentAppState = AppStateEnum.SecondMove;
                    }

                    break;
                }

                case AppStateEnum.SecondMove:
                {
                    _codeBox.transform.position = Vector3.MoveTowards(_codeBox.transform.position, leftPosition, 3000 * Time.deltaTime);

                    if (_codeBox.transform.position.x == leftPosition.x)
                    {
                        currentAppState = AppStateEnum.ThirdMove;
                    }

                    break;
                }

            case AppStateEnum.ThirdMove:
                {
                    _codeBox.transform.position = Vector3.MoveTowards(_codeBox.transform.position, rightPosition, 800 * Time.deltaTime);

                    if (_codeBox.transform.position.x == rightPosition.x)
                    {
                        currentAppState = AppStateEnum.FourthMove;
                    }

                    break;
                }

            case AppStateEnum.FourthMove:
                {
                    _codeBox.transform.position = Vector3.MoveTowards(_codeBox.transform.position, leftPosition, 2000 * Time.deltaTime);

                    if (_codeBox.transform.position.x == leftPosition.x)
                    {
                        currentAppState = AppStateEnum.Dormant;
                    }

                    break;
                }



            case AppStateEnum.Dormant:

                    break;

            }

    }



    private void UpdateClickHandler()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse clicked");
            Reset();
        }
    }


    IEnumerator PauserCoroutine()
    {
        yield return new WaitForSeconds(2);
        currentAppState = AppStateEnum.FirstMove;
    }

}
