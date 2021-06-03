using UnityEngine;

namespace PixelAdventure
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] float followSpeed;
        [SerializeField] float changeSizeSpeed;
        [SerializeField] Vector3 offset;
        [SerializeField] Vector2 vectorMin, vectorMax;

        [SerializeField] Transform target;
        [SerializeField] Camera _camera;
        [SerializeField] float reconfiguratedCameraSize;

        float _minX, _minY, _maxX, _maxy;
        float size;

        bool canChangeSize;

        void Awake()
        {
            _camera = GetComponent<Camera>();

            var _player = target.GetComponentInParent<BaseController>();
            _player.BeginConversation += DialogBeginHandler;
            _player.NotifyCameraAboutDialogEnd = DialogEndHandler;

            var _val = GameInfo.Instance.GetCameraBounds();

            vectorMin.x = _val.MinX;
            vectorMin.y = _val.MinY;
            vectorMax.x = _val.MaxX;
            vectorMax.y = _val.MaxY;
        }

        void OnEnable()
        {
            target.GetComponentInParent<BaseController>().ChangeCameraBound = SwitchBound;
        }

        private void DialogEndHandler()
        {
            canChangeSize = false;
            LoadSavedCameraValues();
        }

        private void DialogBeginHandler()
        {
            ReconfigureCameraForDialog();
        }

        private void ReconfigureCameraForDialog()
        {
            SaveCurrentCameraValues();

            vectorMin.x = -Mathf.Infinity;
            vectorMin.y = -Mathf.Infinity;
            vectorMax.x = Mathf.Infinity;
            vectorMax.y = Mathf.Infinity;

            canChangeSize = true;

        }

        private void SaveCurrentCameraValues()
        {
            size = _camera.orthographicSize;

            _minX = vectorMin.x;
            _minY = vectorMin.y;
            _maxX = vectorMax.x;
            _maxy = vectorMax.y;
        }

        private void LoadSavedCameraValues()
        {
            vectorMin.x = _minX;
            vectorMin.y = _minY;
            vectorMax.x = _maxX;
            vectorMax.y = _maxy;

            _camera.orthographicSize = size;
        }

        private void SwitchBound(CameraBoundValues _struct)
        {
            vectorMin.x = _struct.MinX;
            vectorMin.y = _struct.MinY;
            vectorMax.x = _struct.MaxX;
            vectorMax.y = _struct.MaxY;
        }

        private void LateUpdate()
        {
            Vector3 smoothPosition = Vector3.Lerp(transform.position, target.position + offset, followSpeed * Time.deltaTime);
            smoothPosition.x = Mathf.Clamp(smoothPosition.x, vectorMin.x, vectorMax.x);
            smoothPosition.y = Mathf.Clamp(smoothPosition.y, vectorMin.y, vectorMax.y);
            transform.position = smoothPosition;
        }

        private void Update()
        {
            if (canChangeSize)
                if (_camera.orthographicSize > reconfiguratedCameraSize)
                    _camera.orthographicSize -= changeSizeSpeed * Time.deltaTime;
                else
                    canChangeSize = false;
        }

        public void SetTargetToFollow(Transform transform)
        {
            target = transform;
        }
    }
}
