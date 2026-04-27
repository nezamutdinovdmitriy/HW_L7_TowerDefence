namespace Assets._Project.Develop.Runtime.Gameplay.EntitiesCore
{
	public partial class Entity
	{
		public Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Team TeamC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Team>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.TeamType> Team => TeamC.Value;

		public bool TryGetTeam(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.TeamType> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Team component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.TeamType>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeam()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Team() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.TeamType>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTeam(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.TeamType> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.TeamsFeature.Team() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.BodyCollider BodyColliderC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.BodyCollider>();

		public UnityEngine.CapsuleCollider BodyCollider => BodyColliderC.Value;

		public bool TryGetBodyCollider(out UnityEngine.CapsuleCollider value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.BodyCollider component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.CapsuleCollider);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyCollider(UnityEngine.CapsuleCollider value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.BodyCollider() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.ContactsCollidersBuffer ContactsCollidersBufferC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.ContactsCollidersBuffer>();

		public Assets._Project.Develop.Runtime.Utilities.Pooling.Buffer<UnityEngine.Collider> ContactsCollidersBuffer => ContactsCollidersBufferC.Value;

		public bool TryGetContactsCollidersBuffer(out Assets._Project.Develop.Runtime.Utilities.Pooling.Buffer<UnityEngine.Collider> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.ContactsCollidersBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Pooling.Buffer<UnityEngine.Collider>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactsCollidersBuffer(Assets._Project.Develop.Runtime.Utilities.Pooling.Buffer<UnityEngine.Collider> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.ContactsCollidersBuffer() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.ContactsEntitiesBuffer ContactsEntitiesBufferC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.ContactsEntitiesBuffer>();

		public Assets._Project.Develop.Runtime.Utilities.Pooling.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> ContactsEntitiesBuffer => ContactsEntitiesBufferC.Value;

		public bool TryGetContactsEntitiesBuffer(out Assets._Project.Develop.Runtime.Utilities.Pooling.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.ContactsEntitiesBuffer component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Pooling.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactsEntitiesBuffer(Assets._Project.Develop.Runtime.Utilities.Pooling.Buffer<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.ContactsEntitiesBuffer() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.ContactsDetectingMask ContactsDetectingMaskC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.ContactsDetectingMask>();

		public UnityEngine.LayerMask ContactsDetectingMask => ContactsDetectingMaskC.Value;

		public bool TryGetContactsDetectingMask(out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.ContactsDetectingMask component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactsDetectingMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.ContactsDetectingMask() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.ContactsEntityTimers ContactsEntityTimersC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.ContactsEntityTimers>();

		public System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity, System.Single> ContactsEntityTimers => ContactsEntityTimersC.Value;

		public bool TryGetContactsEntityTimers(out System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity, System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.ContactsEntityTimers component);
			if(result)
				value = component.Value;
			else
				value = default(System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity, System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactsEntityTimers()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.ContactsEntityTimers() { Value = new System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity, System.Single>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactsEntityTimers(System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity, System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.ContactsEntityTimers() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.IsTouchDeathMask IsTouchDeathMaskC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.IsTouchDeathMask>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsTouchDeathMask => IsTouchDeathMaskC.Value;

		public bool TryGetIsTouchDeathMask(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.IsTouchDeathMask component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchDeathMask()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.IsTouchDeathMask() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchDeathMask(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.IsTouchDeathMask() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.IsTouchAnotherTeam IsTouchAnotherTeamC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.IsTouchAnotherTeam>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsTouchAnotherTeam => IsTouchAnotherTeamC.Value;

		public bool TryGetIsTouchAnotherTeam(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.IsTouchAnotherTeam component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchAnotherTeam()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.IsTouchAnotherTeam() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsTouchAnotherTeam(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.IsTouchAnotherTeam() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.DeathMask DeathMaskC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.DeathMask>();

		public UnityEngine.LayerMask DeathMask => DeathMaskC.Value;

		public bool TryGetDeathMask(out UnityEngine.LayerMask value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.DeathMask component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.LayerMask);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDeathMask(UnityEngine.LayerMask value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.DeathMask() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.CanStartDetecting CanStartDetectingC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.CanStartDetecting>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanStartDetecting => CanStartDetectingC.Value;

		public bool TryGetCanStartDetecting(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.CanStartDetecting component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanStartDetecting(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.CanStartDetecting() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.AreaContactDetectingRadius AreaContactDetectingRadiusC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.AreaContactDetectingRadius>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AreaContactDetectingRadius => AreaContactDetectingRadiusC.Value;

		public bool TryGetAreaContactDetectingRadius(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.AreaContactDetectingRadius component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAreaContactDetectingRadius()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.AreaContactDetectingRadius() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAreaContactDetectingRadius(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.SensorsFeature.AreaContactDetectingRadius() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.TargetRotation TargetRotationC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.TargetRotation>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Quaternion> TargetRotation => TargetRotationC.Value;

		public bool TryGetTargetRotation(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Quaternion> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.TargetRotation component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Quaternion>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTargetRotation()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.TargetRotation() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Quaternion>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTargetRotation(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Quaternion> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.TargetRotation() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationDirection RotationDirectionC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationDirection>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> RotationDirection => RotationDirectionC.Value;

		public bool TryGetRotationDirection(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationDirection component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationDirection()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationDirection() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationDirection(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationDirection() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationSpeed RotationSpeedC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationSpeed>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> RotationSpeed => RotationSpeedC.Value;

		public bool TryGetRotationSpeed(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationSpeed component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationSpeed() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationSpeed(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationSpeed() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.CanRotate CanRotateC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.CanRotate>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanRotate => CanRotateC.Value;

		public bool TryGetCanRotate(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.CanRotate component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanRotate(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.CanRotate() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationMode RotationModeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationMode>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationType> RotationMode => RotationModeC.Value;

		public bool TryGetRotationMode(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationType> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationMode component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationType>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationMode()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationMode() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationType>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddRotationMode(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationType> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.RotationFeature.RotationMode() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MovementDirection MovementDirectionC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MovementDirection>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> MovementDirection => MovementDirectionC.Value;

		public bool TryGetMovementDirection(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MovementDirection component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMovementDirection()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MovementDirection() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMovementDirection(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MovementDirection() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MovementSpeed MovementSpeedC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MovementSpeed>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> MovementSpeed => MovementSpeedC.Value;

		public bool TryGetMovementSpeed(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MovementSpeed component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMovementSpeed()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MovementSpeed() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMovementSpeed(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.MovementSpeed() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.IsMoving IsMovingC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.IsMoving>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsMoving => IsMovingC.Value;

		public bool TryGetIsMoving(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.IsMoving component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsMoving()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.IsMoving() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsMoving(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.IsMoving() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanMove CanMoveC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanMove>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanMove => CanMoveC.Value;

		public bool TryGetCanMove(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanMove component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanMove(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MovementFeature.CanMove() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature.IsMainHero IsMainHeroC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature.IsMainHero>();

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsMainHero()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature.IsMainHero() ); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature.BodyTransform BodyTransformC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature.BodyTransform>();

		public UnityEngine.Transform BodyTransform => BodyTransformC.Value;

		public bool TryGetBodyTransform(out UnityEngine.Transform value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature.BodyTransform component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Transform);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddBodyTransform(UnityEngine.Transform value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.MainHeroFeature.BodyTransform() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature.InputMovementDirection InputMovementDirectionC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature.InputMovementDirection>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> InputMovementDirection => InputMovementDirectionC.Value;

		public bool TryGetInputMovementDirection(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature.InputMovementDirection component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInputMovementDirection()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature.InputMovementDirection() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInputMovementDirection(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.InputFeature.InputMovementDirection() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.HealthFeature.MaxHealth MaxHealthC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.HealthFeature.MaxHealth>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> MaxHealth => MaxHealthC.Value;

		public bool TryGetMaxHealth(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.HealthFeature.MaxHealth component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxHealth()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.HealthFeature.MaxHealth() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMaxHealth(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.HealthFeature.MaxHealth() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.HealthFeature.CurrentHealth CurrentHealthC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.HealthFeature.CurrentHealth>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> CurrentHealth => CurrentHealthC.Value;

		public bool TryGetCurrentHealth(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.HealthFeature.CurrentHealth component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentHealth()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.HealthFeature.CurrentHealth() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentHealth(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.HealthFeature.CurrentHealth() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.HealthFeature.HealthBarPoint HealthBarPointC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.HealthFeature.HealthBarPoint>();

		public UnityEngine.Transform HealthBarPoint => HealthBarPointC.Value;

		public bool TryGetHealthBarPoint(out UnityEngine.Transform value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.HealthFeature.HealthBarPoint component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Transform);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddHealthBarPoint(UnityEngine.Transform value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.HealthFeature.HealthBarPoint() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.EnemiesFeature.AttackRange AttackRangeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.EnemiesFeature.AttackRange>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AttackRange => AttackRangeC.Value;

		public bool TryGetAttackRange(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.EnemiesFeature.AttackRange component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackRange()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.EnemiesFeature.AttackRange() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAttackRange(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.EnemiesFeature.AttackRange() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.IsDead IsDeadC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.IsDead>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> IsDead => IsDeadC.Value;

		public bool TryGetIsDead(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.IsDead component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsDead()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.IsDead() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddIsDead(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.IsDead() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.InDeathProcess InDeathProcessC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.InDeathProcess>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> InDeathProcess => InDeathProcessC.Value;

		public bool TryGetInDeathProcess(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.InDeathProcess component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInDeathProcess()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.InDeathProcess() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInDeathProcess(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.InDeathProcess() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.MustDie MustDieC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.MustDie>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition MustDie => MustDieC.Value;

		public bool TryGetMustDie(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.MustDie component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustDie(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.MustDie() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.MustSelfRelease MustSelfReleaseC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.MustSelfRelease>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition MustSelfRelease => MustSelfReleaseC.Value;

		public bool TryGetMustSelfRelease(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.MustSelfRelease component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddMustSelfRelease(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.MustSelfRelease() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.DisableCollidersOnDeath DisableCollidersOnDeathC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.DisableCollidersOnDeath>();

		public System.Collections.Generic.List<UnityEngine.Collider> DisableCollidersOnDeath => DisableCollidersOnDeathC.Value;

		public bool TryGetDisableCollidersOnDeath(out System.Collections.Generic.List<UnityEngine.Collider> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.DisableCollidersOnDeath component);
			if(result)
				value = component.Value;
			else
				value = default(System.Collections.Generic.List<UnityEngine.Collider>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.DisableCollidersOnDeath() { Value = new System.Collections.Generic.List<UnityEngine.Collider>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDisableCollidersOnDeath(System.Collections.Generic.List<UnityEngine.Collider> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.DisableCollidersOnDeath() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.ShouldForceDeath ShouldForceDeathC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.ShouldForceDeath>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> ShouldForceDeath => ShouldForceDeathC.Value;

		public bool TryGetShouldForceDeath(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.ShouldForceDeath component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddShouldForceDeath()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.ShouldForceDeath() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddShouldForceDeath(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.DeathFeature.ShouldForceDeath() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.TakeDamage.ContactDamage ContactDamageC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.TakeDamage.ContactDamage>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> ContactDamage => ContactDamageC.Value;

		public bool TryGetContactDamage(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.TakeDamage.ContactDamage component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactDamage()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.TakeDamage.ContactDamage() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddContactDamage(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.TakeDamage.ContactDamage() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.TakeDamage.CooldownTick CooldownTickC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.TakeDamage.CooldownTick>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> CooldownTick => CooldownTickC.Value;

		public bool TryGetCooldownTick(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.TakeDamage.CooldownTick component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCooldownTick()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.TakeDamage.CooldownTick() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCooldownTick(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.TakeDamage.CooldownTick() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.TakeDamage.DamageTick DamageTickC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.TakeDamage.DamageTick>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> DamageTick => DamageTickC.Value;

		public bool TryGetDamageTick(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.TakeDamage.DamageTick component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDamageTick()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.TakeDamage.DamageTick() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddDamageTick(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.TakeDamage.DamageTick() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.ApplyDamage.TakeDamageRequest TakeDamageRequestC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.ApplyDamage.TakeDamageRequest>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> TakeDamageRequest => TakeDamageRequestC.Value;

		public bool TryGetTakeDamageRequest(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.ApplyDamage.TakeDamageRequest component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageRequest()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.ApplyDamage.TakeDamageRequest() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageRequest(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.ApplyDamage.TakeDamageRequest() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.ApplyDamage.TakeDamageEvent TakeDamageEventC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.ApplyDamage.TakeDamageEvent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> TakeDamageEvent => TakeDamageEventC.Value;

		public bool TryGetTakeDamageEvent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.ApplyDamage.TakeDamageEvent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageEvent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.ApplyDamage.TakeDamageEvent() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTakeDamageEvent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveEvent<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.ApplyDamage.TakeDamageEvent() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.ApplyDamage.CanApplyDamage CanApplyDamageC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.ApplyDamage.CanApplyDamage>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanApplyDamage => CanApplyDamageC.Value;

		public bool TryGetCanApplyDamage(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.ApplyDamage.CanApplyDamage component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanApplyDamage(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.DamageFeature.ApplyDamage.CanApplyDamage() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.ShootPoint ShootPointC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.ShootPoint>();

		public UnityEngine.Transform ShootPoint => ShootPointC.Value;

		public bool TryGetShootPoint(out UnityEngine.Transform value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.ShootPoint component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Transform);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddShootPoint(UnityEngine.Transform value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.ShootPoint() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.InputAimPoint InputAimPointC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.InputAimPoint>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> InputAimPoint => InputAimPointC.Value;

		public bool TryGetInputAimPoint(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.InputAimPoint component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInputAimPoint()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.InputAimPoint() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddInputAimPoint(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.InputAimPoint() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.TargetAimPoint TargetAimPointC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.TargetAimPoint>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> TargetAimPoint => TargetAimPointC.Value;

		public bool TryGetTargetAimPoint(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.TargetAimPoint component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTargetAimPoint()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.TargetAimPoint() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTargetAimPoint(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<UnityEngine.Vector3> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.TargetAimPoint() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.AbilitiesEquipped AbilitiesEquippedC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.AbilitiesEquipped>();

		public System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilitySlotType, Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> AbilitiesEquipped => AbilitiesEquippedC.Value;

		public bool TryGetAbilitiesEquipped(out System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilitySlotType, Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.AbilitiesEquipped component);
			if(result)
				value = component.Value;
			else
				value = default(System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilitySlotType, Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilitiesEquipped()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.AbilitiesEquipped() { Value = new System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilitySlotType, Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilitiesEquipped(System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilitySlotType, Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.AbilitiesEquipped() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.AbilitiesStorage AbilitiesStorageC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.AbilitiesStorage>();

		public System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilitySlotType, System.Collections.Generic.List<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>> AbilitiesStorage => AbilitiesStorageC.Value;

		public bool TryGetAbilitiesStorage(out System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilitySlotType, System.Collections.Generic.List<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.AbilitiesStorage component);
			if(result)
				value = component.Value;
			else
				value = default(System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilitySlotType, System.Collections.Generic.List<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilitiesStorage()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.AbilitiesStorage() { Value = new System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilitySlotType, System.Collections.Generic.List<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilitiesStorage(System.Collections.Generic.Dictionary<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilitySlotType, System.Collections.Generic.List<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.AbilitiesStorage() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.AbilitySlotCurrent AbilitySlotCurrentC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.AbilitySlotCurrent>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilitySlotType> AbilitySlotCurrent => AbilitySlotCurrentC.Value;

		public bool TryGetAbilitySlotCurrent(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilitySlotType> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.AbilitySlotCurrent component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilitySlotType>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilitySlotCurrent()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.AbilitySlotCurrent() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilitySlotType>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilitySlotCurrent(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilitySlotType> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.AbilitySlotCurrent() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.ShouldCastAbility ShouldCastAbilityC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.ShouldCastAbility>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> ShouldCastAbility => ShouldCastAbilityC.Value;

		public bool TryGetShouldCastAbility(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.ShouldCastAbility component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddShouldCastAbility()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.ShouldCastAbility() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddShouldCastAbility(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Common.ShouldCastAbility() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastPerSecond AbilityCastPerSecondC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastPerSecond>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AbilityCastPerSecond => AbilityCastPerSecondC.Value;

		public bool TryGetAbilityCastPerSecond(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastPerSecond component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityCastPerSecond()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastPerSecond() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityCastPerSecond(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastPerSecond() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastInitialTime AbilityCastInitialTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastInitialTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AbilityCastInitialTime => AbilityCastInitialTimeC.Value;

		public bool TryGetAbilityCastInitialTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastInitialTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityCastInitialTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastInitialTime() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityCastInitialTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastInitialTime() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastModifiedTime AbilityCastModifiedTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastModifiedTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AbilityCastModifiedTime => AbilityCastModifiedTimeC.Value;

		public bool TryGetAbilityCastModifiedTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastModifiedTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityCastModifiedTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastModifiedTime() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityCastModifiedTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastModifiedTime() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastCurrentTime AbilityCastCurrentTimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastCurrentTime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AbilityCastCurrentTime => AbilityCastCurrentTimeC.Value;

		public bool TryGetAbilityCastCurrentTime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastCurrentTime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityCastCurrentTime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastCurrentTime() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityCastCurrentTime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastCurrentTime() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastSpawnEffectDelay AbilityCastSpawnEffectDelayC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastSpawnEffectDelay>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AbilityCastSpawnEffectDelay => AbilityCastSpawnEffectDelayC.Value;

		public bool TryGetAbilityCastSpawnEffectDelay(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastSpawnEffectDelay component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityCastSpawnEffectDelay()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastSpawnEffectDelay() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityCastSpawnEffectDelay(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastSpawnEffectDelay() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastSpawnEffectDelayModified AbilityCastSpawnEffectDelayModifiedC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastSpawnEffectDelayModified>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> AbilityCastSpawnEffectDelayModified => AbilityCastSpawnEffectDelayModifiedC.Value;

		public bool TryGetAbilityCastSpawnEffectDelayModified(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastSpawnEffectDelayModified component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityCastSpawnEffectDelayModified()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastSpawnEffectDelayModified() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityCastSpawnEffectDelayModified(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastSpawnEffectDelayModified() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.CanCastAbility CanCastAbilityC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.CanCastAbility>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanCastAbility => CanCastAbilityC.Value;

		public bool TryGetCanCastAbility(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.CanCastAbility component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanCastAbility(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.CanCastAbility() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastInProcess AbilityCastInProcessC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastInProcess>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> AbilityCastInProcess => AbilityCastInProcessC.Value;

		public bool TryGetAbilityCastInProcess(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastInProcess component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityCastInProcess()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastInProcess() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityCastInProcess(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastInProcess() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ShouldSpawnEffect ShouldSpawnEffectC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ShouldSpawnEffect>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> ShouldSpawnEffect => ShouldSpawnEffectC.Value;

		public bool TryGetShouldSpawnEffect(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ShouldSpawnEffect component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddShouldSpawnEffect()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ShouldSpawnEffect() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddShouldSpawnEffect(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ShouldSpawnEffect() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ShouldStartProcess ShouldStartProcessC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ShouldStartProcess>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> ShouldStartProcess => ShouldStartProcessC.Value;

		public bool TryGetShouldStartProcess(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ShouldStartProcess component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddShouldStartProcess()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ShouldStartProcess() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddShouldStartProcess(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ShouldStartProcess() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilitySlot AbilitySlotC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilitySlot>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilitySlotType> AbilitySlot => AbilitySlotC.Value;

		public bool TryGetAbilitySlot(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilitySlotType> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilitySlot component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilitySlotType>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilitySlot()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilitySlot() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilitySlotType>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilitySlot(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilitySlotType> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilitySlot() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Ability AbilityC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Ability>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityType> Ability => AbilityC.Value;

		public bool TryGetAbility(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityType> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Ability component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityType>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbility()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Ability() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityType>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbility(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityType> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Ability() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityAnimatorKey AbilityAnimatorKeyC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityAnimatorKey>();

		public System.String AbilityAnimatorKey => AbilityAnimatorKeyC.Value;

		public bool TryGetAbilityAnimatorKey(out System.String value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityAnimatorKey component);
			if(result)
				value = component.Value;
			else
				value = default(System.String);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityAnimatorKey(System.String value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityAnimatorKey() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCost AbilityCostC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCost>();

		public System.Int32 AbilityCost => AbilityCostC.Value;

		public bool TryGetAbilityCost(out System.Int32 value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCost component);
			if(result)
				value = component.Value;
			else
				value = default(System.Int32);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityCost(System.Int32 value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCost() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.CurrencyCost CurrencyCostC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.CurrencyCost>();

		public Assets._Project.Develop.Runtime.Meta.Features.WalletFeature.CurrencyType CurrencyCost => CurrencyCostC.Value;

		public bool TryGetCurrencyCost(out Assets._Project.Develop.Runtime.Meta.Features.WalletFeature.CurrencyType value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.CurrencyCost component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Meta.Features.WalletFeature.CurrencyType);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrencyCost(Assets._Project.Develop.Runtime.Meta.Features.WalletFeature.CurrencyType value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.CurrencyCost() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ShouldSpendCost ShouldSpendCostC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ShouldSpendCost>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> ShouldSpendCost => ShouldSpendCostC.Value;

		public bool TryGetShouldSpendCost(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ShouldSpendCost component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddShouldSpendCost()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ShouldSpendCost() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddShouldSpendCost(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ShouldSpendCost() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastKeyMapping AbilityCastKeyMappingC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastKeyMapping>();

		public Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities.AbilityToAnimatorKeyMapping AbilityCastKeyMapping => AbilityCastKeyMappingC.Value;

		public bool TryGetAbilityCastKeyMapping(out Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities.AbilityToAnimatorKeyMapping value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastKeyMapping component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities.AbilityToAnimatorKeyMapping);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddAbilityCastKeyMapping(Assets._Project.Develop.Runtime.Gameplay.Configs.Abilities.AbilityToAnimatorKeyMapping value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityCastKeyMapping() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.CurrentCastingAbility CurrentCastingAbilityC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.CurrentCastingAbility>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> CurrentCastingAbility => CurrentCastingAbilityC.Value;

		public bool TryGetCurrentCastingAbility(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.CurrentCastingAbility component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentCastingAbility()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.CurrentCastingAbility() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentCastingAbility(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.CurrentCastingAbility() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityEffects.ToxicPuddle.ToxicPuddleRadius ToxicPuddleRadiusC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityEffects.ToxicPuddle.ToxicPuddleRadius>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> ToxicPuddleRadius => ToxicPuddleRadiusC.Value;

		public bool TryGetToxicPuddleRadius(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityEffects.ToxicPuddle.ToxicPuddleRadius component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddToxicPuddleRadius()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityEffects.ToxicPuddle.ToxicPuddleRadius() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddToxicPuddleRadius(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.AbilityEffects.ToxicPuddle.ToxicPuddleRadius() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion.ExplosionRadius ExplosionRadiusC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion.ExplosionRadius>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> ExplosionRadius => ExplosionRadiusC.Value;

		public bool TryGetExplosionRadius(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion.ExplosionRadius component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddExplosionRadius()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion.ExplosionRadius() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddExplosionRadius(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion.ExplosionRadius() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion.ExplosionDamage ExplosionDamageC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion.ExplosionDamage>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> ExplosionDamage => ExplosionDamageC.Value;

		public bool TryGetExplosionDamage(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion.ExplosionDamage component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddExplosionDamage()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion.ExplosionDamage() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddExplosionDamage(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion.ExplosionDamage() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion.CanSpawnExplosion CanSpawnExplosionC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion.CanSpawnExplosion>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanSpawnExplosion => CanSpawnExplosionC.Value;

		public bool TryGetCanSpawnExplosion(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion.CanSpawnExplosion component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanSpawnExplosion(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion.CanSpawnExplosion() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion.ExplosionLifetime ExplosionLifetimeC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion.ExplosionLifetime>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> ExplosionLifetime => ExplosionLifetimeC.Value;

		public bool TryGetExplosionLifetime(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion.ExplosionLifetime component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddExplosionLifetime()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion.ExplosionLifetime() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddExplosionLifetime(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Single> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion.ExplosionLifetime() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion.ExplosionRequested ExplosionRequestedC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion.ExplosionRequested>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> ExplosionRequested => ExplosionRequestedC.Value;

		public bool TryGetExplosionRequested(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion.ExplosionRequested component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddExplosionRequested()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion.ExplosionRequested() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddExplosionRequested(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<System.Boolean> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.Explosion.ExplosionRequested() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ArcaneMine.CanUseArcaneMine CanUseArcaneMineC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ArcaneMine.CanUseArcaneMine>();

		public Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition CanUseArcaneMine => CanUseArcaneMineC.Value;

		public bool TryGetCanUseArcaneMine(out Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ArcaneMine.CanUseArcaneMine component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCanUseArcaneMine(Assets._Project.Develop.Runtime.Utilities.Conditions.ICompositeCondition value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.Features.CombatFeatures.Abilities.ArcaneMine.CanUseArcaneMine() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Common.TransfromComponent TransfromC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Common.TransfromComponent>();

		public UnityEngine.Transform Transfrom => TransfromC.Value;

		public bool TryGetTransfrom(out UnityEngine.Transform value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Common.TransfromComponent component);
			if(result)
				value = component.Value;
			else
				value = default(UnityEngine.Transform);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddTransfrom(UnityEngine.Transform value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Common.TransfromComponent() {Value = value}); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Common.CurrentTarget CurrentTargetC => GetComponent<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Common.CurrentTarget>();

		public Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> CurrentTarget => CurrentTargetC.Value;

		public bool TryGetCurrentTarget(out Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			bool result = TryGetComponent(out Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Common.CurrentTarget component);
			if(result)
				value = component.Value;
			else
				value = default(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>);
			return result;
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentTarget()
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Common.CurrentTarget() { Value = new Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity>() }); 
		}

		public Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity AddCurrentTarget(Assets._Project.Develop.Runtime.Utilities.Reactive.ReactiveVariable<Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Entity> value)
		{
			return AddComponent(new Assets._Project.Develop.Runtime.Gameplay.EntitiesCore.Common.CurrentTarget() {Value = value}); 
		}

	}
}
