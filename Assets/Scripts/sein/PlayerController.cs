using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPunCallbacks, IPunObservable
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // �ٸ� Ŭ���̾�Ʈ���� �����ϴ� �÷��̾� ������Ʈ�� ��Ȱ��ȭ
        if (!photonView.IsMine)
        {
            GetComponent<PlayerController>().enabled = false;
        }
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            movement.x = Input.GetAxis("Horizontal");
            movement.y = Input.GetAxis("Vertical");
        }
    }

    void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            // �ڽ��� �����͸� ����
            stream.SendNext(rb.position);
            stream.SendNext(rb.velocity);
        }
        else
        {
            // �ٸ� Ŭ���̾�Ʈ�� �����͸� ����
            rb.position = (Vector2)stream.ReceiveNext();
            rb.velocity = (Vector2)stream.ReceiveNext();
        }
    }
}
