﻿Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data.SqlClient
Imports System.Data

Public Class Abonnements
    Public Structure IxAbonnements
        Public Property Pk As Long
        Public Property Abonnement As String
        Public Property Prix As Integer
    End Structure

    Public Property Abonnment As New IxAbonnements
    Public Property PkAbonne As Long
    Public Property PkCategorieAbonnement As Integer
    Public Property DateDebut As DateTime
    Public Property DateFin As DateTime

    Public Shared Function getIxAbonnement() As List(Of IxAbonnements)
        Dim Abonnements As New List(Of IxAbonnements)
        Dim sql As New SqlCommand
        sql.CommandText = "SELECT * FROM IX_ABONNEMENTS"
        sql.CommandType = CommandType.Text
        sql.Connection = New SqlConnection(ConfigurationManager.ConnectionStrings("THYP_ConnectionString").ConnectionString)
        sql.Connection.Open()
        Dim reader As SqlDataReader = sql.ExecuteReader
        While reader.Read()
            Dim Abonnement As New IxAbonnements
            Abonnement.Pk = reader("PK_IX_ABONNEMENTS")
            Abonnement.Abonnement = reader("ABONNEMENT")
            Abonnement.Prix = reader("PRIX_ABONNEMENT")
            Abonnements.Add(Abonnement)
        End While
        sql.Connection.Close()

        Return Abonnements
    End Function

End Class

' Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante.
<System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class AbonnementsWebService
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function getIxAbonnement() As List(Of Abonnements.IxAbonnements)
        Return Abonnements.getIxAbonnement()
    End Function

End Class