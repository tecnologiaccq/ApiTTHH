//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ApiTTHH.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PermissionPolicyUser
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PermissionPolicyUser()
        {
            this.PermissionPolicyUserUsers_PermissionPolicyRoleRoles = new HashSet<PermissionPolicyUserUsers_PermissionPolicyRoleRoles>();
            this.SecuritySystemUserCustom = new HashSet<SecuritySystemUserCustom>();
            this.tGN_Personas = new HashSet<tGN_Personas>();
        }
    
        public System.Guid Oid { get; set; }
        public string StoredPassword { get; set; }
        public Nullable<bool> ChangePasswordOnFirstLogon { get; set; }
        public string UserName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> OptimisticLockField { get; set; }
        public Nullable<int> GCRecord { get; set; }
        public Nullable<int> IdCaja { get; set; }
        public Nullable<int> IdEmpresa { get; set; }
    
        public virtual tGN_Empresas tGN_Empresas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PermissionPolicyUserUsers_PermissionPolicyRoleRoles> PermissionPolicyUserUsers_PermissionPolicyRoleRoles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SecuritySystemUserCustom> SecuritySystemUserCustom { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tGN_Personas> tGN_Personas { get; set; }
    }
}
