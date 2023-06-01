using Firebase.Extensions;
using Firebase.Firestore;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentWaybill : MonoBehaviour
{
    [SerializeField] private string _car;
    [SerializeField] private Text _titleName;
    [SerializeField] private Image _titleImage;
    [Header("error")]
    [SerializeField] private ErrorMessage _errorMessage;
    [Header("shift area")]
    [SerializeField] private string _shiftStatus;
    [SerializeField] private Button _shiftBtn;
    [SerializeField] private Text _shiftText;
    [SerializeField] private Image _shiftImage;
    [SerializeField] private GameObject _shiftMenuButton;
    [Header("waybills text")]
    [SerializeField] private Text _date;
    [SerializeField] private Text _gosNomer;
    [SerializeField] private Text _driver;
    [SerializeField] private Text _speedMor;
    [SerializeField] private Text _speedEv;
    [SerializeField] private Text _fuel;
    [SerializeField] private Text _dir1;
    [SerializeField] private Text _prod1;
    [SerializeField] private Text _am1;
    [SerializeField] private Text _dir2;
    [SerializeField] private Text _prod2;
    [SerializeField] private Text _am2;
    [SerializeField] private Text _dir3;
    [SerializeField] private Text _prod3;
    [SerializeField] private Text _am3;
    [SerializeField] private Text _dir4;
    [SerializeField] private Text _prod4;
    [SerializeField] private Text _am4;
    [SerializeField] private Text _dir5;
    [SerializeField] private Text _prod5;
    [SerializeField] private Text _am5;
    [SerializeField] private Text _dir6;
    [SerializeField] private Text _prod6;
    [SerializeField] private Text _am6;
    [SerializeField] private Text _dir7;
    [SerializeField] private Text _prod7;
    [SerializeField] private Text _am7;
    [SerializeField] private Text _dir8;
    [SerializeField] private Text _prod8;
    [SerializeField] private Text _am8;
    [Header("interactable buttons")]
    [SerializeField] private List<Button> _buttonsBase;

    private Scene _scene;
    private DocumentReference _documentReference;
    private FirebaseFirestore _firebaseFirestore;
    private ListenerRegistration _listenerRegistration;

    public void Initialize(IFirestoreHolder firestoreHolder, Scene scene)
    {
        _scene = scene;
        SetFirestore(firestoreHolder.GetFirestore());
    }

    private void SetFirestore(FirebaseFirestore firebaseFirestore)
    {
        _firebaseFirestore = firebaseFirestore;
        Debug.Log("Current Waybill");
    }

    private void OnEnable()
    {
        if (_documentReference != null)
        {
            SetWaybill();
        }
    }

    public void SetCar(string carName)
    {
        _car = carName;
        _titleName.text = carName;
        _gosNomer.text = carName;
        _documentReference = _firebaseFirestore.Collection("waybills").Document(carName);
    }

    private void SetWaybill()
    {
        _listenerRegistration = _documentReference.Listen(snapshot =>
        {
            if (snapshot.Exists)
            {
                Debug.Log(string.Format("Document data for {0} document:", snapshot.Id));
                Dictionary<string, object> car = snapshot.ToDictionary();
                _shiftStatus = car["shift"].ToString();
                CheckShift();

                _date.text = car["date"].ToString();
                _driver.text = car["driver"].ToString();
                _speedMor.text = car["speedMor"].ToString();
                _speedEv.text = car["speedEv"].ToString();
                _fuel.text = car["fuel"].ToString();

                _dir1.text = car["dir1"].ToString();
                _prod1.text = car["prod1"].ToString();
                _am1.text = car["am1"].ToString();

                _dir2.text = car["dir2"].ToString();
                _prod2.text = car["prod2"].ToString();
                _am2.text = car["am2"].ToString();

                _dir3.text = car["dir3"].ToString();
                _prod3.text = car["prod3"].ToString();
                _am3.text = car["am3"].ToString();

                _dir4.text = car["dir4"].ToString();
                _prod4.text = car["prod4"].ToString();
                _am4.text = car["am4"].ToString();

                _dir5.text = car["dir5"].ToString();
                _prod5.text = car["prod5"].ToString();
                _am5.text = car["am5"].ToString();

                _dir6.text = car["dir6"].ToString();
                _prod6.text = car["prod6"].ToString();
                _am6.text = car["am6"].ToString();

                _dir7.text = car["dir7"].ToString();
                _prod7.text = car["prod7"].ToString();
                _am7.text = car["am7"].ToString();

                _dir8.text = car["dir8"].ToString();
                _prod8.text = car["prod8"].ToString();
                _am8.text = car["am8"].ToString();
            }
            else
            {
                Debug.Log(string.Format("Document {0} does not exist!", snapshot.Id));
            }
        });
    }

    private void ClearWaybill()
    {
        _date.text = "";
        _driver.text = "";
        _speedMor.text = "";
        _speedEv.text = "";
        _fuel.text = "";

        _dir1.text = "";
        _prod1.text = "";
        _am1.text = "";

        _dir2.text = "";
        _prod2.text = "";
        _am2.text = "";

        _dir3.text = "";
        _prod3.text = "";
        _am3.text = "";

        _dir4.text = "";
        _prod4.text = "";
        _am4.text = "";

        _dir5.text = "";
        _prod5.text = "";
        _am5.text = "";

        _dir6.text = "";
        _prod6.text = "";
        _am6.text = "";

        _dir7.text = "";
        _prod7.text = "";
        _am7.text = "";

        _dir8.text = "";
        _prod8.text = "";
        _am8.text = "";
        if (_scene == Scene.Admin)
        {
            _shiftMenuButton.SetActive(false);
        }
    }


    private void OnDisable()
    {
        if (_listenerRegistration != null)
        {
            _listenerRegistration.Stop();
        }
        ClearWaybill();
    }

    private void CheckShift()
    {
        if (_shiftStatus.Equals("open"))
        {
            _titleImage.color = new Color32(0, 159, 255, 255);
            _shiftImage.color = new Color32(0, 159, 255, 255);
            _shiftText.text = "«¿ –€“‹ —Ã≈Õ”";
            _shiftBtn.interactable = true;
            if (_scene == Scene.Admin)
            {
                _shiftMenuButton.SetActive(false);
            }
            foreach (Button button in _buttonsBase)
            {
                button.interactable = true;
            }
        }
        if (_shiftStatus.Equals("closed"))
        {
            _titleImage.color = new Color32(255, 0, 20, 255);
            _shiftImage.color = new Color32(255, 0, 20, 255);
            _shiftText.text = "—Ã≈Õ¿ «¿ –€“¿";
            _shiftBtn.interactable = false;
            if (_scene == Scene.Admin)
            {
                _shiftMenuButton.SetActive(true);
            }
            if (_scene == Scene.Base)
            {
                foreach (Button button in _buttonsBase)
                {
                    button.interactable = false;
                }
            }
        }
    }

    public void OpenShift()
    {

        if (InternetConnection.Check() != false)
        {
            Dictionary<string, object> data = new Dictionary<string, object>
            {
                {"shift", "open" },
            };
            _documentReference.SetAsync(data, SetOptions.MergeAll);
        }
        else
        {
            _errorMessage.Open();
        }
    }

    public void CloseShift()
    {
        if (InternetConnection.Check() != false)
        {
            Dictionary<string, object> data = new Dictionary<string, object>
            {
                {"shift", "closed" },
            };
            _documentReference.SetAsync(data, SetOptions.MergeAll);
        }
        else
        {
            _errorMessage.Open();
        }
    }
}
