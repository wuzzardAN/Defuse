using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Wire : MonoBehaviour,
         IDragHandler, IBeginDragHandler, IEndDragHandler {
   public bool IsLeftWire;
   public Color CustomColor;

   private Image image;
   private LineRenderer lineRenderer;

   private Canvas canvas;
   private bool isDragStarted = false;
   private WireTask wireTask;
   public bool IsSuccess = false;
   private void Awake() {
      image = GetComponent<Image>();
      lineRenderer = GetComponent<LineRenderer>();
      canvas = GetComponentInParent<Canvas>();
      wireTask = GetComponentInParent<WireTask>();
   }

   private void Update() {
      if (isDragStarted) {
         Vector2 movePos;
         RectTransformUtility.ScreenPointToLocalPointInRectangle(
                     canvas.transform as RectTransform,
                     Input.mousePosition,
                     canvas.worldCamera,
                     out movePos);
         lineRenderer.SetPosition(0, transform.position);
         lineRenderer.SetPosition(1,
              canvas.transform.TransformPoint(movePos));
      }
      else {
         // Hide the line if not dragging.
         // We will not hide it when it connects, later on.
         if (!IsSuccess) {
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, Vector3.zero);
         }
      }
      bool isHovered =
        RectTransformUtility.RectangleContainsScreenPoint(
            transform as RectTransform, Input.mousePosition,
                                    canvas.worldCamera);
      if (isHovered) {
         wireTask.CurrentHoveredWire = this;
      }
   }

   public void SetColor(Color color) {
      image.color = color;
      lineRenderer.startColor = color;
      lineRenderer.endColor = color;
      CustomColor = color;
   }
   public void OnDrag(PointerEventData eventData) {
      // needed for drag but not used
   }

   public void OnBeginDrag(PointerEventData eventData) {
      if (!IsLeftWire) { return; }
      // Is is successful, don't draw more lines!
      if (IsSuccess) { return; }
      isDragStarted = true;
      wireTask.CurrentDraggedWire = this;
   }

   public void OnEndDrag(PointerEventData eventData) {
      if (wireTask.CurrentHoveredWire != null) {
         if (wireTask.CurrentHoveredWire.CustomColor ==
                                                CustomColor &&
             !wireTask.CurrentHoveredWire.IsLeftWire) {
            IsSuccess = true;

            // Set Successful on the Right Wire as well.
            wireTask.CurrentHoveredWire.IsSuccess = true;
         }
      }
      isDragStarted = false;
      wireTask.CurrentDraggedWire = null;
   }
}
