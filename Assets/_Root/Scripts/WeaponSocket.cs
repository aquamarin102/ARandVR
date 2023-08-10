using UnityEngine;
using System.Collections;
using Valve.VR.InteractionSystem;

namespace GeekBrains
{
    public class WeaponSocket : Socket
    {
        private Gun _gun;

        protected override void FixedUpdate()
        {
            if (_gun != null) return;
            
            base.FixedUpdate();
        }

        public override void PlaceObject(GameObject go)
        {            
            _gun = go.GetComponent<Gun>();

            if (_gun.TypeOfGun == _typeOfMagazine)
            {
                MyInteractable interactable = go.GetComponent<MyInteractable>();
                interactable.DetachFromHand();
                interactable.onPickUp.AddListener(TakeOffObject);
                _gun.GetComponent<Rigidbody>().isKinematic = true;

                go.transform.SetParent(gameObject.transform);

                if (smoothAttach) StartCoroutine(Attaching(go));
                else
                {
                    go.transform.localRotation = Quaternion.identity;
                    go.transform.localPosition = Vector3.zero;
                }
            }
        }

        protected override void TakeOffObject()
        {            
            _gun.GetComponent<MyInteractable>().onPickUp.RemoveListener(TakeOffObject);
            _lastMagazine = _gun.gameObject;
            _gun = null;
        }

        public override void Release()
        {
            if (_gun == null) return;

            _gun.transform.SetParent(null);
            _gun.GetComponent<Rigidbody>().isKinematic = false;
            TakeOffObject();
        }
    }
}