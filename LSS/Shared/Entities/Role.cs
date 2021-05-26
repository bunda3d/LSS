using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LSS.Shared.Entities
{
  public class Role
	{
		public int Id { get; set; }

		//abbr. version to represent Role. 
		//should add regex here to make code entry consistent
		[Column(TypeName = "varchar(10)")]
		public string RoleCode { get; set; }


		[Required(ErrorMessage = "Required Field: Enter short " +
			"Role Name description, similar to 'Job Title'.")]
		[Column(TypeName = "varchar(50)")]
		public int RoleName { get; set; }


		[Column(TypeName = "varchar(240)")]
		public int RoleDescription { get; set; }


	}
}
