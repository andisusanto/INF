Imports System
Imports System.Security.Principal

Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Base.Security
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Security
Imports DevExpress.Xpo
Imports DevExpress.Data.Filtering

Public Class Updater
	Inherits DevExpress.ExpressApp.Updating.ModuleUpdater
    Public Sub New(ByVal objectSpace As IObjectSpace, ByVal currentDBVersion As Version)
        MyBase.New(objectSpace, currentDBVersion)
    End Sub

    Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
        Dim DefaultRoleName As String = "System Administrator"
        Dim DefaultAdministratorName As String = "Andi"
        Dim session = ObjectSpace
        Dim defaultrole As ApplicationRole = session.FindObject(Of ApplicationRole)(New BinaryOperator("RoleName", DefaultRoleName))
        If defaultrole Is Nothing Then
            defaultrole = session.CreateObject(Of ApplicationRole)()
            defaultrole.RoleName = DefaultRoleName
            Do While defaultrole.PersistentPermissions.Count > 0
                ObjectSpace.Delete(defaultrole.PersistentPermissions(0))
            Loop
            defaultrole.AddPermission(New ObjectAccessPermission(GetType(Object), ObjectAccess.AllAccess))
            defaultrole.AddPermission(New EditModelPermission(ModelAccessModifier.Allow))
            defaultrole.Save()
        End If
        Dim defaultuser As ApplicationUser = session.FindObject(Of ApplicationUser)(New BinaryOperator("UserName", DefaultAdministratorName))
        If defaultuser Is Nothing Then
            defaultuser = session.CreateObject(Of ApplicationUser)()
            defaultuser.ChangePasswordAfterLogon = False
            defaultuser.UserName = "Andi"
            defaultuser.SetPassword("123456")
            For i = 0 To defaultuser.Roles.Count - 1
                defaultuser.Roles.Remove(defaultuser.Roles(0))
            Next
            defaultuser.Roles.Add(defaultrole)
            defaultuser.Save()
        End If

        MyBase.UpdateDatabaseAfterUpdateSchema()
    End Sub
End Class
