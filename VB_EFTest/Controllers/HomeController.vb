Imports System.Collections.Generic
Imports System.Data.Entity


Imports VB_EFTest
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Private _FPC_DBEntities As FPC_DBEntities = New FPC_DBEntities()

    Function Index() As ActionResult
       Dim _deps As List(Of FPC_Departments) = _FPC_DBEntities.FPC_Departments.ToList
       
        Dim Deps As List(Of SelectListItem) = New List(Of SelectListItem)
        Dim c=0
       For Each Item As  FPC_Departments In _deps
            Deps.Add(New SelectListItem With {.Text = _deps(c).DepartmentName, .Value =  _deps(c).ID})  
            c = c + 1
        Next
        Dim SelList As SelectList = New SelectList(Deps,"Value", "Text")
        ViewBag.Deps = SelList
     Return View() 
    End Function

    Private sub DoLidtAfHvert(ByVal Work As LaHv)
        Work.Name = "Carlo"
        Work.Occupied  = True
        Work.ListBoxItems = New MyListBoxItems()
        Work.ListBoxItems.Color1 = "Red"
        Work.ListBoxItems.Color2 = "Rosa"
        Work.ListBoxItems.Color3 = "Blue"
        Work.ListBoxItems.Color4 = "LightCyan"
        Work.ListBoxItems.Color5 = "CadetBlue"
        Work.ListBoxItems.Color6 = "Orange"

    End sub
    Function LidtAfHvert() As ActionResult
        Dim Work As New LaHv()
        DoLidtAfHvert(Work)
        ViewBag.Result =""
        Return View(Work)

    End Function

    <HttpPost>
     Function LidtAfHvert(ByVal collection As FormCollection) As ActionResult
        Dim Work As New LaHv()
        DoLidtAfHvert(Work)
        
        ViewBag.Result = "Saved... OK. !!!"
        Return View(Work)

    End Function

    Public Function GetEmployees(Optional ByVal ID As String = "1") As JsonResult
    Dim num As Integer = Convert.ToInt32(ID)
    'Dim emps  = Me._FPC_DBEntities.FPC_Employees.Where(Function(e) ID = e.DepID _
    '                                    And e.Valid =True AndAlso e.JobStatus=1  )
    Dim emps = From e In _FPC_DBEntities.FPC_Employees
                Where e.DepID =ID And e.Valid = True AndAlso  e.JobStatus =1
    Select New Employee With _
        {
            .ID = e.ID ,
            .[Alias] = e.Alias,
            .Name =e.Name,
            .HomeEmail = e.HomeEmail,
            .Remarks = e.Remarks,
            .Mobile = e.Mobile
        }

    Dim ecount = emps.Count

    Return MyBase.Json(emps, JsonRequestBehavior.AllowGet)
End Function



    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class
