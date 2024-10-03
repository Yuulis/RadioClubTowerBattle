using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Camera mainCamera;      // �J�����Q�Ɨp
    public Text scoreText;         // �X�R�A��\������Text UI
    public Transform spawnPoint;   // �����𐶐�����n�_�iSpawnPoint�j
    private float highestPoint = 0f; // ���݂̍ō��_�i�����j
    private float maxHeightReached = 0f; // �ō����B�_�i�X�R�A�j

    public float cameraOffset = 10f; // �J�����̍����I�t�Z�b�g
    public float spawnOffset = 5f;  // SpawnPoint�𓮕��̏�ɔz�u����I�t�Z�b�g

    void Start()
    {
        // �J�������ݒ肳��Ă��Ȃ��ꍇ�̓��C���J�������Q��
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        // �X�R�A�����������ĕ\��
        UpdateScoreText();
    }

    // �X�R�A���X�V���A�J������SpawnPoint�𒲐����郁�\�b�h
    public void AddScoreAndAdjustCamera(float height)
    {
        // �V���������̍��������݂̍ō��_����������΍X�V
        if (height > highestPoint)
        {
            highestPoint = height;
            AdjustCameraPosition(); // �J�����ʒu���X�V
        }

        // �V�������������܂ł̍ō����B�_�imaxHeightReached�j�𒴂����ꍇ�A�X�R�A���X�V
        if (height > maxHeightReached)
        {
            maxHeightReached = height;
            UpdateScoreText(); // �X�R�A�\�����X�V
            AdjustSpawnPoint(); // SpawnPoint�ʒu���X�V
        }
    }

    // �X�R�A���X�V����UI�ɔ��f����
    void UpdateScoreText()
    {
        // �ō����B�_���X�R�A�Ƃ��ĕ\��
        scoreText.text = "Score: " + Mathf.RoundToInt(maxHeightReached);
    }

    // �J�����̈ʒu�𒲐�����
    void AdjustCameraPosition()
    {
        // �J�����̐V����Y���W�͍ō��_�ɃI�t�Z�b�g������������
        Vector3 targetPosition = new Vector3(
            mainCamera.transform.position.x,   // X���W�͌Œ�
            highestPoint + cameraOffset,       // Y���W�͍ō��_ + �I�t�Z�b�g
            mainCamera.transform.position.z    // Z���W�͌Œ�
        );

        // �J�����ʒu�����X�ɖڕW�Ɉړ�������
        mainCamera.transform.position = Vector3.Lerp(
            mainCamera.transform.position,    // ���݂̃J�����ʒu
            targetPosition,                   // �ڕW�ʒu
            Time.deltaTime * 2f               // �ړ����x����
        );
    }

    // SpawnPoint�̈ʒu�𒲐�����
    void AdjustSpawnPoint()
    {
        // maxHeightReached�ɉ����ăI�t�Z�b�g�����X�ɑ傫������
        spawnOffset = Random.Range(3f,5f);

        // �V����Y���W���v�Z����SpawnPoint���ړ�
        Vector3 newSpawnPosition = new Vector3(
            spawnPoint.position.x,            // X���W�͌Œ�
            maxHeightReached + spawnOffset,   // Y���W�͍ō����B�_ + ��������I�t�Z�b�g
            spawnPoint.position.z             // Z���W�͌Œ�
        );

        // �V�����ʒu��SpawnPoint���ړ�
        spawnPoint.position = newSpawnPosition;
    }


}
