using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LazerPointer : MonoBehaviour {

    // 변수           
    private LineRenderer lineRendererComp;
    private RaycastHit raycastHit;
    private GameObject currentRay;

    public float raycastDistance = 50f;


    // 초기화          
    private void Awake() {

        lineRendererComp = this.gameObject.AddComponent<LineRenderer>();

        // 라인 설정        
        Material mat = new Material(Shader.Find("Standard"));
        //mat.color = new Color(0, 251, 255, 0.5f);

        lineRendererComp.material = mat;
        lineRendererComp.positionCount = 2;
        lineRendererComp.startWidth = 0.01f;
        lineRendererComp.endWidth = 0.01f;
    }


    // Loop         
    private void Update() {

        // 시작 위치        
        lineRendererComp.SetPosition(0, transform.position);


        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green, 0.5f,true);


        // 충돌 감지 시      
        if(Physics.Raycast(transform.position, transform.forward, out raycastHit, raycastDistance) && gameObject.activeInHierarchy) {
            //Debug.Log(raycastHit.collider.gameObject.tag);
            lineRendererComp.SetPosition(1, raycastHit.point);

            // 버튼 충돌        
            if (raycastHit.collider.gameObject.CompareTag("Button")) 
                ButtonRayProcess();

            // 스크롤바 충돌    
            /*if (raycastHit.collider.gameObject.CompareTag("Scrollbar"))
                ScrollbarRayProcess();*/

            // 기타 충돌        
            /*else
            {
                if (currentRay != null)
                {

                    // 버튼 전용        
                    if (currentRay.gameObject.CompareTag("Button"))
                        currentRay.GetComponent<Button>().OnPointerExit(null);

                    // 스크롤바 전용    
                    else if (currentRay.gameObject.CompareTag("Scrollbar"))
                        currentRay.GetComponent<Scrollbar>().OnPointerExit(null);

                    currentRay = null;
                }
            }
            */
        }

        // 충돌 미 감지 시    
        else {
            lineRendererComp.SetPosition(1, transform.position + (transform.forward * raycastDistance));

            if(currentRay != null) {

                if (currentRay.gameObject.CompareTag("Button"))
                    currentRay.GetComponent<Button>().OnPointerExit(null);

                else if (currentRay.gameObject.CompareTag("Scrollbar"))
                    currentRay.GetComponent<Scrollbar>().OnPointerExit(null);

                currentRay = null;
            }
        }
    }
    


    // 버튼 감지            
    private void ButtonRayProcess() {
        // 클릭 Down          
        if (OVRInput.GetDown(OVRInput.Button.One))
            raycastHit.collider.gameObject.GetComponent<Button>().OnPointerClick(null);

        // 클릭 Up            
        else if (OVRInput.GetUp(OVRInput.Button.One) || Input.GetKeyDown(KeyCode.E)) {
            Button temp = raycastHit.collider.gameObject.GetComponent<Button>();
            if (temp.interactable == true) {
                temp.onClick.Invoke();
                /*EventSystem.current.SetSelectedGameObject(raycastHit.collider.gameObject);
                PointerEventData pointerEventData = new PointerEventData(null);
                pointerEventData.position = new Vector2(raycastHit.point.x, raycastHit.point.y);
                */

                //temp.OnSelect(pointerEventData);
                //temp.OnPointerClick(pointerEventData);
            }

        }

        else
            raycastHit.collider.gameObject.GetComponent<Button>().OnPointerEnter(null);


        currentRay = raycastHit.collider.gameObject;
    }


    // 스크롤 바 감지         
    private void ScrollbarRayProcess() {

        // 클릭 Down          
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            raycastHit.collider.gameObject.GetComponent<Scrollbar>().OnSelect(null);

        // 클릭 중            
        else if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)) {
            Scrollbar temp = raycastHit.collider.gameObject.GetComponent<Scrollbar>();

            if (temp.interactable == true) {
                PointerEventData pointerEventData = new PointerEventData(null);
                pointerEventData.position = new Vector2(raycastHit.point.x, raycastHit.point.y);
                //pointerEventData.selectedObject = raycastHit.collider.gameObject;
                temp.OnDrag(pointerEventData);

                //temp.value = 1f;

            }

        }

        // 클릭 UP                
        else if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyUp(KeyCode.Z)) {
            Scrollbar temp = raycastHit.collider.gameObject.GetComponent<Scrollbar>();

            if (temp.interactable == true) {
                PointerEventData pointerEventData = new PointerEventData(null);
                pointerEventData.position = new Vector2(raycastHit.point.x, raycastHit.point.y);

                //try { temp.GetComponent<VolumeScrollbarPointerEvent>().OnPointerUp(pointerEventData); }
                //catch (Exception) { }
            }
        }

        else
            raycastHit.collider.gameObject.GetComponent<Scrollbar>().OnPointerEnter(null);

        currentRay = raycastHit.collider.gameObject;
    }
}