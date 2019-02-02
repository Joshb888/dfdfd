﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework6;
using ProtoBuf;

namespace Resgrid.Model
{
	[ProtoContract]
	[Table("UserStates")]
	public class UserState : IEntity
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[ProtoMember(1)]
		public int UserStateId { get; set; }

		[Required]
		[ProtoMember(2)]
		public string UserId { get; set; }

		[ProtoMember(3)]
		public int DepartmentId { get; set; }

		[Required]
		[ProtoMember(4)]
		public int State { get; set; }

		[ProtoMember(5)]
		public DateTime Timestamp { get; set; }

		[MaxLength(3000)]
		[ProtoMember(6)]
		public string Note { get; set; }

		[ForeignKey("UserId")]
		public virtual IdentityUser User { get; set; }

		//[ForeignKey("DepartmentId")]
		//public virtual Department Department { get; set; }

		[NotMapped]
		public object Id
		{
			get { return UserStateId; }
			set { UserStateId = (int)value; }
		}

		[NotMapped]
		public bool AutoGenerated { get; set; }

		public string GetStaffingText()
		{
			switch (((UserStateTypes)State))
			{
				case UserStateTypes.Available:
					return "Available";
				case UserStateTypes.Delayed:
					return "Delayed";
				case UserStateTypes.Unavailable:
					return "Unavailable";
				case UserStateTypes.Committed:
					return "Committed";
				case UserStateTypes.OnShift:
					return "On Shift";
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public string GetStaffingCss()
		{
			switch (((UserStateTypes)State))
			{
				case UserStateTypes.Available:
					return "label-default";
				case UserStateTypes.Delayed:
					return "label-warning";
				case UserStateTypes.Unavailable:
					return "label-danger";
				case UserStateTypes.Committed:
					return "label-info";
				case UserStateTypes.OnShift:
					return "label-info";
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
	}

	public class UserState_Mapping : EntityTypeConfiguration<UserState>
	{
		public UserState_Mapping()
		{
			this.HasRequired(t => t.User).WithMany().HasForeignKey(t => t.UserId).WillCascadeOnDelete(false);
		}
	}
}