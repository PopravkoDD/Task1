using UnityEngine;
using UnityEngine.UI;

public class SparrowController : MonoBehaviour
{
    [SerializeField] private GameObject[] _sparrowArray;
    [SerializeField] private int _currentIndex;
    [SerializeField] private int _maxIndex;
    [SerializeField] private Button _rightButton;
    [SerializeField] private Button _leftButton;
    [SerializeField] private Button _redButton;
    [SerializeField] private Button _blueButton;
    [SerializeField] private Button _yelowButton;
    [SerializeField] private Button _greenButton;
    [SerializeField] private MeshRenderer[] _sparrowsMashes;
    private GameObject _currentSparrow;

    private void Start()
    {
        _sparrowsMashes = new MeshRenderer[_sparrowArray.Length];
        _currentSparrow = _sparrowArray[0];
        
        _maxIndex = _sparrowArray.Length - 1;
        for (var i = 0; i <= _maxIndex; i++)
        {
            _sparrowsMashes[i] = _sparrowArray[i].GetComponent<MeshRenderer>();
            
            if (i == 0)
            {
                continue;
            }
            
            _sparrowArray[i].transform.position = _sparrowArray[0].transform.position;
            _sparrowArray[i].transform.rotation = _sparrowArray[0].transform.rotation;
        }
        
        _rightButton.onClick.AddListener(ChooseNextSparrow);
        _leftButton.onClick.AddListener(ChoosePreviousSparrow);
        _redButton.onClick.AddListener(PaintRed);
        _blueButton.onClick.AddListener(PaintBlue);
        _yelowButton.onClick.AddListener(PaintYellow);
        _greenButton.onClick.AddListener(PaintGreen);
    }

    void Update()
    {
        
    }

    private void ChooseNextSparrow()
    {
        ChangeSparrow(1);
    }

    private void ChoosePreviousSparrow()
    {
        ChangeSparrow(-1);
    }

    private void ChangeSparrow(int multiplier)
    {
        _sparrowArray[_currentIndex].SetActive(false);
        ChangeIndex(multiplier);
        _sparrowArray[_currentIndex].SetActive(true);
    }

    private void ChangeIndex(int multiplier)
    {
        _currentIndex += 1 * multiplier;
            
        if (_currentIndex > _maxIndex)
        {
            _currentIndex = 0;
        }
        else if (_currentIndex < 0)
        {
            _currentIndex = _maxIndex;
        }
    }

    private void PaintRed()
    {
        _sparrowsMashes[_currentIndex].material.color = Color.red;
    }

    private void PaintBlue()
    {
        _sparrowsMashes[_currentIndex].material.color = Color.blue;
    }
    
    private void PaintYellow()
    {
        _sparrowsMashes[_currentIndex].material.color = Color.yellow;
    }
    
    private void PaintGreen()
    {
        _sparrowsMashes[_currentIndex].material.color = Color.green;
    }

    
}
