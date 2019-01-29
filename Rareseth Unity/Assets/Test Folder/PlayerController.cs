﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_PlayerDirection { Left, Right, Up, Down }

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : MonoBehaviour
{

    #region Fields
    [Header("Player X-Axis Movement")]
    [SerializeField] private float m_XAxis;
    [Header("Player Y-Axis Movement")]
    [SerializeField] private float m_YAxis;
    [Header("Player Current Facing Direction?")]
    [SerializeField] private E_PlayerDirection m_PlayerDirection;

    [Header("Speed of Player")]
    [SerializeField] private float m_PlayerSpeed = 5f;
    [Header("Player Current Movement Speed")]
    [SerializeField] private float m_CurrentRunSpeed;

    [Header("Is the Player Dead?")]
    [SerializeField] private bool m_IsDead = false;
    [Header("Is the Player Moving?")]
    [SerializeField] private bool m_IsMoving;
    [Header("Can the Player Move?")]
    [SerializeField] private bool m_CanMove = true;
     
    [Header("Player's RigidBody")]
    [SerializeField] private Rigidbody2D m_PlayerRigidbody;
    [Header("Player's Animators")]
    [SerializeField] private Animator m_PlayerAnimator;
    [Header("Player's Sprite Renderer")]
    [SerializeField] private SpriteRenderer m_PlayerSpriteRenderer;
    #endregion

    #region Properties
    public float XAxis
    {
        get
        {
            return m_XAxis;
        }

        set
        {
            m_XAxis = value;
        }
    }
    public float YAxis
    {
        get
        {
            return m_YAxis;
        }

        set
        {
            m_YAxis = value;
        }
    }
    public E_PlayerDirection PlayerDirection
    {
        get
        {
            return m_PlayerDirection;
        }

        set
        {
            m_PlayerDirection = value;
        }
    }
    public float PlayerSpeed
    {
        get
        {
            return m_PlayerSpeed;
        }

        set
        {
            m_PlayerSpeed = value;
        }
    }
    public float CurrentRunSpeed
    {
        get
        {
            return m_CurrentRunSpeed;
        }

        set
        {
            m_CurrentRunSpeed = value;
        }
    }
    public bool IsDead
    {
        get
        {
            return m_IsDead;
        }

        set
        {
            m_IsDead = value;
        }
    }
    public bool IsMoving
    {
        get
        {
            return m_IsMoving;
        }

        set
        {
            m_IsMoving = value;
        }
    }
    public bool CanMove
    {
        get
        {
            return m_CanMove;
        }

        set
        {
            m_CanMove = value;
        }
    }
    public Rigidbody2D PlayerRigidbody
    {
        get
        {
            return m_PlayerRigidbody;
        }

        set
        {
            m_PlayerRigidbody = value;
        }
    }
    public Animator PlayerAnimator
    {
        get
        {
            return m_PlayerAnimator;
        }

        set
        {
            m_PlayerAnimator = value;
        }
    }
    public SpriteRenderer PlayerSpriteRenderer
    {
        get
        {
            return m_PlayerSpriteRenderer;
        }

        set
        {
            m_PlayerSpriteRenderer = value;
        }
    }
    #endregion

    //Default Value in Inspector
    void Reset()
    {
        m_XAxis = 0;
        m_YAxis = 0;
        m_PlayerDirection = E_PlayerDirection.Down;
        m_PlayerSpeed = 5f;
        m_CurrentRunSpeed = 0f;
        m_IsDead = false;
        m_IsMoving = false;
        m_CanMove = true;
        m_PlayerRigidbody = GetComponent<Rigidbody2D>();
        m_PlayerAnimator = GetComponent<Animator>();
        m_PlayerSpriteRenderer = GetComponent<SpriteRenderer>();

        m_PlayerRigidbody.gravityScale = 0;
        m_PlayerSpriteRenderer.sortingOrder = 1;
    }

    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.zero;
        if (m_CanMove == true)
        {
            m_XAxis = Input.GetAxisRaw("Horizontal");
            m_YAxis = Input.GetAxisRaw("Vertical");
            m_PlayerAnimator.SetFloat("XInput", m_XAxis);
            m_PlayerAnimator.SetFloat("YInput", m_YAxis);

            //Set Direction
            #region SetDirection
            if (m_XAxis > 0)
            {
                m_PlayerDirection = E_PlayerDirection.Right;

            }
            else if (m_XAxis < 0)
            {
                m_PlayerDirection = E_PlayerDirection.Left;
            }
            else if (YAxis < 0)
            {
                m_PlayerDirection = E_PlayerDirection.Down;
            }
            else if (YAxis > 0)
            {
                m_PlayerDirection = E_PlayerDirection.Up;
            }
            #endregion

            if (Mathf.Abs(m_XAxis) > 0 || Mathf.Abs(YAxis) > 0)
            {
                m_IsMoving = true;
                m_PlayerAnimator.SetBool("IsMoving", m_IsMoving);
            }
            else
            {
                m_IsMoving = false;
                m_PlayerAnimator.SetBool("IsMoving", m_IsMoving);
            }

            m_PlayerRigidbody.velocity = new Vector2(m_XAxis * m_PlayerSpeed, m_YAxis * m_PlayerSpeed);
        }
    }

    
}
