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
    
    public partial class PermissionPolicyRole
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PermissionPolicyRole()
        {
            this.PermissionPolicyNavigationPermissionsObject = new HashSet<PermissionPolicyNavigationPermissionsObject>();
            this.PermissionPolicyTypePermissionsObject = new HashSet<PermissionPolicyTypePermissionsObject>();
            this.PermissionPolicyUserUsers_PermissionPolicyRoleRoles = new HashSet<PermissionPolicyUserUsers_PermissionPolicyRoleRoles>();
        }
    
        public System.Guid Oid { get; set; }
        public string Name { get; set; }
        public Nullable<bool> IsAdministrative { get; set; }
        public Nullable<bool> CanEditModel { get; set; }
        public Nullable<int> PermissionPolicy { get; set; }
        public Nullable<int> OptimisticLockField { get; set; }
        public Nullable<int> GCRecord { get; set; }
        public Nullable<int> ObjectType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PermissionPolicyNavigationPermissionsObject> PermissionPolicyNavigationPermissionsObject { get; set; }
        public virtual XPObjectType XPObjectType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PermissionPolicyTypePermissionsObject> PermissionPolicyTypePermissionsObject { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PermissionPolicyUserUsers_PermissionPolicyRoleRoles> PermissionPolicyUserUsers_PermissionPolicyRoleRoles { get; set; }
    }
}
