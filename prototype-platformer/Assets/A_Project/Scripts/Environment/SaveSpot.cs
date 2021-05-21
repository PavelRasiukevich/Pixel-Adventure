using PixelAdventure.Interfaces;
using TMPro;
using UnityEngine;

namespace PixelAdventure
{
    public class SaveSpot : MonoBehaviour
    {
        public readonly int INT_FLAGOUT = Animator.StringToHash("SaveSpotOutAnimation");
        public readonly int INT_LASTFRAME = Animator.StringToHash("isLastFrame");
        public readonly int INT_ISUSED = Animator.StringToHash("isUsed");

        [SerializeField] TextMeshProUGUI hintText;
        [SerializeField] bool isSaved;
        [SerializeField] int id;
        [SerializeField] string savedMsg;

        Animator anim;

        public bool IsSaved { get => isSaved; set => isSaved = value; }
        public int Id { get => id; }

        private void Awake()
        {
            anim = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            var _listOfListeners = anim.GetBehaviours<StateMachineListener>();

            foreach (var _listener in _listOfListeners)
            {
                _listener.ExitState = OnListenerExitStateHandler;
            }
        }

        private void OnListenerExitStateHandler(AnimatorStateInfo _info)
        {

            if (_info.shortNameHash == INT_FLAGOUT)
                anim.SetTrigger(INT_LASTFRAME);
        }

        private void OnTriggerStay2D(Collider2D collision)
        {

            IControllable _player = collision.GetComponentInParent<IControllable>();

            if (_player != null)
                if (Input.GetAxis("Use") > 0 && !isSaved)
                {
                    anim.SetBool(INT_ISUSED, true);
                    GameInfo.Instance.UserData.IsLoadAvaliable = true;
                    isSaved = true;
                    hintText.text = savedMsg;
                    GameInfo.Instance.SetSavePointId(id);
                    GameInfo.Instance.SaveGameProgress();
                }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            IControllable _player = collision.GetComponentInParent<IControllable>();

            if (_player != null)
                hintText.gameObject.SetActive(true);
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            IControllable _player = collision.GetComponentInParent<IControllable>();

            if (_player != null)
                hintText.gameObject.SetActive(false);
        }

        public Vector2 GetPosition()
        {
            return transform.position;
        }
    }
}
